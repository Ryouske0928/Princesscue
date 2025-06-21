using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    [Header("�v���C���[����̍U������R���C�_�[��Tag")]
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] Transform player;
    [SerializeField] GameClear gameClear;
    [SerializeField] float _chaseOnDistance;  //���G����
    [SerializeField] float _chaseOffDistance; //���G��������
    [SerializeField] float _attackOnDistance; //�U���J�n����
    [SerializeField] float _moveSpeed;//�ړ����x
    [Header("�����̍��W")]
    [SerializeField] Transform[] enemyPoint;�@//�����̍��W�擾�p
    private int _pointNum;                //������W�̗v�f�p
    private float _attackTimer = 0;
    [SerializeField]private float _attackCooldown;
    [Header("�G�U������R���C�_�[")]
    [SerializeField] Collider _enemyWeapon;
    private Health health;

    private NavMeshAgent agent;
    enum EnemyState
    {
        Patrol,
        Chase
    }
    private EnemyState _enemyState;

    private void Start()
    {
        _attackTimer = 0;
        _pointNum = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = enemyPoint[_pointNum].position;
        health = GetComponent<Health>();
    }
    private void OnTriggerEnter(Collider other)  //�ǂ����ł���������悤��,Enter��Stay
    {
        Damage(other.tag);
    }

    private void Damage(string tag)�@  //�v���C���[����̃_���[�W����
    {
        if (tag == WeaponTag)
        {
            health.TakeDamage(10);
        }
    }

    private void Update()
    {
        _attackTimer += Time.deltaTime;
        //�v���C���[�Ƃ̋������m�ō��G
        float _distance = Vector3.Distance(transform.position, player.position);
        //����ƒǐՂ̐؂�ւ�����
        switch (_enemyState)
        {
            case EnemyState.Patrol:
                if (_distance < _chaseOnDistance)
                {
                    _enemyState = EnemyState.Chase;
                }
                Patrol();
                break;

            case EnemyState.Chase:
                if(_distance > _chaseOffDistance)
                {
                    _enemyState = EnemyState.Patrol;
                }
                ChaseAndAttack(_distance);
                break;
        }

    }

    void Patrol()�@�@//���񏈗�
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetNextPoint();
        }
    }

    void ChaseAndAttack(float _distance)�@//�ǐՂƍU������
    {
        if (!agent.pathPending)
        {
            if(_distance > _attackOnDistance)
            {
                //�v���C���[�Ƃ̕������K��
                Vector3 dir = (player.position - transform.position).normalized;

                //�v���C���[�̎�O�ɂȂ�悤�ɒ���
                Vector3 _stopPosition = player.position - dir * (_attackOnDistance * 0.9f); //���̂܂�_attackOnDistance���ƍU�����Ȃ��o�O��������̂���

                //�ړ���𒲐������ʒu�ɐݒ�
                agent.destination = _stopPosition;
            }
            else
            {
                agent.ResetPath();

                if(_attackTimer >= _attackCooldown)
                {
                    Debug.Log("�X���C���U��");
                    _attackTimer = 0;
                }
            }
        }
    }
    void SetNextPoint()�@//���񃋁[�g�̃Z�b�e�B���O����
    {
        _pointNum = Random.Range(0, enemyPoint.Length);
        agent.destination = enemyPoint[_pointNum].position;
    }

    //�A�j���[�V�����C�x���g�œ����蔻�� ON & OFF
    void OnEnemyAttack()
    {
        _enemyWeapon.enabled = true;
    }

    void OffEnemyAttack()
    {
        _enemyWeapon.enabled = false;
    }
}
