using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    [SerializeField] GameClear gameClear;
    private float _attackTimer = 0;
    [Header("�U���̊Ԋu")]
    [SerializeField] private float _attackCooldown;
    private Health health;
    private Animator anime;
    [Header("�v���C���[����̍U������R���C�_�[��Tag")]
    [SerializeField] string WeaponTag = "Sword";
    [Header("��_���[�W�Q�ƌ�")]
    [SerializeField] private PlayerCtrl playerCtrl; //�v���C���[�̃X�N���v�g
    [Header("�G����p�R���C�_�[")]
    [SerializeField] Collider _enemyWeapon;
    [Header("�G�U����")]
    public int enemyATK;
    // Start is called before the first frame update
    void Start()
    {
        _attackTimer = 0;
        health = GetComponent<Health>();
        anime = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)  //Enemy���󂯂�_���[�W������p
    {
        Damage(other.tag);
    }
    private void Damage(string tag)
    {
        if(tag == WeaponTag)
        {
            health.TakeDamage(playerCtrl.ATK);
            if(health.CurrentHp <= 0)
            {
                gameClear.DefeatBoss = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        _attackTimer += Time.deltaTime;
    }

    private void BAttack()�@�@�@�@//�{�X�ʏ�U��
    {
        if(_attackTimer >= _attackCooldown)
        {
            //anime.SetBool("isAttack",true);
            Debug.Log("�{�X�U��");
            _attackTimer = 0;
        }
    }
}
