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
    [Header("敵攻撃力")]
    public int enemyATK;
    // Start is called before the first frame update
    void Start()
    {
        _attackTimer = 0;
        health = GetComponent<Health>();
        anime = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)  //Enemyが受けるダメージ判定取る用
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

    private void BAttack()　　　　//ボス通常攻撃
    {
        if(_attackTimer >= _attackCooldown)
        {
            //anime.SetBool("isAttack",true);
            Debug.Log("ボス攻撃");
            _attackTimer = 0;
        }
    }
}
