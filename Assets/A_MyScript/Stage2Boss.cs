using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stage2Boss : MonoBehaviour
{
    [SerializeField] GameClear gameClear; //�X�e�[�W�N���A�p�t���O
    private float _attackTimer = 0;
    [SerializeField] Transform player;  //�ǐՑΏۂ̃v���C���[�ʒu�擾�p
    [Header("�U���̊Ԋu")]
    [SerializeField] private float _attackCooldown;
    [SerializeField] float _battleOnDistance; //�{�X�o�g���J�n����
    [SerializeField] float _attackOnDistance; //�U���J��o������
    [SerializeField] private float lookSpeed;�@�@�@//�G��]���x
    private Health health;
    private Animator anime;
    [Header("�v���C���[����̍U������R���C�_�[��Tag")]
    [SerializeField] string WeaponTag = "Sword";
    [Header("��_���[�W�Q�ƌ�")]
    [SerializeField] private PlayerCtrl playerCtrl; //�v���C���[�̃X�N���v�g
    [Header("�{�X����p�R���C�_�[")]
    [SerializeField] Collider _enemyWeapon1;
    [Header("�{�X����p�R���C�_�[")]
    [SerializeField] Collider _enemyWeapon2;
    [Header("�{�X�U����")]
    public int _bossATK1;
    public int _bossATK2;
    private NavMeshAgent agent;
    [SerializeField] private DamagePlayerBody onceDamage;
    // Start is called before the first frame update
    void Start()
    {
        _attackTimer = 0;
        health = GetComponent<Health>();
        anime = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)  //Boss���󂯂�_���[�W������p
    {
        Damage(other.tag);
    }
    private void Damage(string tag)
    {
        if (tag == WeaponTag && !playerCtrl.hasHitE)
        {
            health.TakeDamage(playerCtrl.ATK);
            playerCtrl.hasHitE = true;
            if (health.CurrentHp <= 0)
            {
                gameClear.DefeatBoss = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        _attackTimer += Time.deltaTime;
        //�v���C���[�Ƃ̋������m�ō��G
        float _distance = Vector3.Distance(transform.position, player.position);
        if (_distance < _battleOnDistance)
        {
            RotateAndAttack(_distance);
        }
    }

    void RotateAndAttack(float _distance)�@//�ǐՂƍU������
    {
        if (!agent.pathPending)
        {
            // �v���C���[�����x�N�g��
            Vector3 lookDir = (player.position - transform.position).normalized;
            lookDir.y = 0f;

            if (lookDir != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * lookSpeed);

                // ���݂̌����Ƃ̊p�x�����v�Z
                float angle = Quaternion.Angle(transform.rotation, targetRotation);

                if (angle > 2f) // �� 2�x�ȏジ��Ă������]����Walk
                {
                    anime.SetBool("isWalk", true);
                    anime.SetBool("isIdle", false);
                }
                else // �� �p�x���قڈ�v������Idle
                {
                    anime.SetBool("isWalk", false);
                    anime.SetBool("isIdle", true);
                }
            }

            if (_distance <= _attackOnDistance)  //�U���͈͓��Ȃ�U��
            {
                if (_attackTimer >= _attackCooldown)
                {
                    int _attackNum = Random.Range(1, 3);
                    if (_attackNum == 1)
                    {
                        anime.SetBool("isAttack1", true);
                        Debug.Log("1�U��");
                    }
                    else
                    {
                        anime.SetBool("isAttack2", true);
                        Debug.Log("2�U��");
                    }
                    _attackTimer = 0;
                }
            }
        }
    }

    void OnBossAttack1()                   //�{�X�U���p�^�[���P�̃R���C�_�[�I���I�t�����i�A�j���[�V�����C�x���g�ŌĂяo���j
    {
        _enemyWeapon1.enabled = true;
        onceDamage.hasHitP = false;
    }
    void OffBossAttack1()
    {
        _enemyWeapon1.enabled = false;
        anime.SetBool("isAttack1", false);
    }

    void OnBossAttack2()                    //�{�X�U���p�^�[���Q�̃R���C�_�[�I���I�t�����i�A�j���[�V�����C�x���g�ŌĂяo���j
    {
        _enemyWeapon2.enabled = true;
        onceDamage.hasHitP = false;
    }
    void OffBossAttack2()
    {
        _enemyWeapon2.enabled = false;
        anime.SetBool("isAttack2", false);
    }
}
