using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    [SerializeField] GameClear gameClear;
    private float _attackTimer = 0;
    [Header("攻撃の間隔")]
    [SerializeField] private float _attackCooldown;
    private Health health;
    private Animator anime;
    [Header("プレイヤーからの攻撃判定コライダーのTag")]
    [SerializeField] string WeaponTag = "Sword";
    [Header("被ダメージ参照元")]
    [SerializeField] private PlayerCtrl playerCtrl; //プレイヤーのスクリプト
    [Header("敵武器用コライダー")]
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
