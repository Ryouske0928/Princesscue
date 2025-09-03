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

    // Start is called before the first frame update
    void Start()
    {
        _attackTimer = 0;
        health = GetComponent<Health>();
        anime = GetComponent<Animator>();
    }

    private void Damege(string tag)
    {
        if(tag == WeaponTag)
        {
            health.TakeDamage(playerCtrl.ATK);
        }
    }
    // Update is called once per frame
    void Update()
    {
        _attackTimer += Time.deltaTime;
    }
}
