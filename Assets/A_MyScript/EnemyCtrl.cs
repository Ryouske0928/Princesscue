using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    [Header("�v���C���[����̍U������R���C�_�[��Tag")]
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] Transform player;
    [SerializeField] float _chaseOnDistance;  //���G����
    [SerializeField] float _chaseOffDistance; //���G��������
    [SerializeField] float _attackOnDistance; //�U���J�n����
    [SerializeField] float _moveSpeed;//�ړ����x
    [Header("�����̍��W")]
    [SerializeField] Transform[] enemyPoint;�@//�����̍��W�擾�p
    private int _pointNum;                //������W�̗v�f�p
    private float _attackTimer = 0;
    [Header("�U���̊Ԋu")]
    [SerializeField]private float _attackCooldown;
    [Header("�G����p�R���C�_�[")]
    [SerializeField] Collider _enemyWeapon;
    private Health health;
    [Header("��_���[�W�Q�ƌ�")]
    [SerializeField]private PlayerCtrl playerCtrl; //�v���C���[�̃X�N���v�g
    [Header("�G�U����")]
    public int enemyATK;                         //�U����
    private Animator anime;
    [SerializeField]private float lookSpeed;�@�@�@//�G��]���x
    [Header("�A�C�e���h���b�v�m��")]
    [SerializeField] private int _dropPercent;   //�h���b�v�m��
    [SerializeField] ItemDatabaseSO DropItem;
    [Header("���񎞂̋x�e����")]
    [SerializeField] private float _waitTime;
    private float _waitTimer;

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
        _waitTimer = 0;
        _pointNum = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = enemyPoint[_pointNum].position;
        health = GetComponent<Health>();
        anime = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)  //Enemy���󂯂�_���[�W������p
    {
        Damage(other.tag);
    }

    private void Damage(string tag)�@  //�v���C���[����̃_���[�W����
    {
        if (tag == WeaponTag)
        {
            health.TakeDamage(playerCtrl.ATK);
            if(health.CurrentHp <= 0)�@�@�@�@//���S���Ɋm���ŃA�C�e���h���b�v�����鏈��
            {
                int _num = Random.Range(1, 101);
                Debug.Log(_num);
                if(_num < _dropPercent)
                {
                    Debug.Log("yobareta");
                    Vector3 position = transform.position;
                    position.y += 1.75f;   //�����炭Rb�̂����H�Œn�ʂɂ��܂邽�߁Ay������
                    Instantiate(DropItem.items[0]._itemPrefab, position, Quaternion.identity);�@�@//�����_�ŉ񕜃|�[�V���������h���b�v�����Ȃ�
                }
            }
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
            anime.SetBool("isSearch",true);
            _waitTimer += Time.deltaTime;
            if(_waitTimer > _waitTime)�@�@�@//���񎞂ɂ�����x�ҋ@�����Ă���A���̒n�_�Ɉړ�
            {
                SetNextPoint();
                anime.SetBool("isSearch",false);
                _waitTimer = 0;
            }
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

                //�������v���C���[�̕��֌����鏈��
                Vector3 lookDir = (player.position - transform.position).normalized;
                lookDir.y = 0f;

                if(lookDir != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(lookDir);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * lookSpeed);
                }

                if(_attackTimer >= _attackCooldown)
                {
                    anime.SetBool("isAttack",true);
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
        anime.SetBool("isAttack",false);
    }
}
