using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossCtrl : MonoBehaviour
{
    [SerializeField] GameClear gameClear; //ステージクリア用フラグ
    private float _attackTimer = 0;
    [SerializeField] Transform player;  //追跡対象のプレイヤー位置取得用
    [Header("攻撃の間隔")]
    [SerializeField] private float _attackCooldown;
    [SerializeField] float _battleOnDistance; //ボスバトル開始距離
    [SerializeField] float _attackOnDistance; //攻撃繰り出し距離
    [SerializeField] private float lookSpeed;　　　//敵回転速度
    private Health health;
    private Animator anime;
    [Header("プレイヤーからの攻撃判定コライダーのTag")]
    [SerializeField] string WeaponTag = "Sword";
    [Header("被ダメージ参照元")]
    [SerializeField] private PlayerCtrl playerCtrl; //プレイヤーのスクリプト
    [Header("ボス武器用コライダー")]
    [SerializeField] Collider _enemyWeapon1;
    [Header("ボス武器用コライダー")]
    [SerializeField] Collider _enemyWeapon2;
    [Header("ボス攻撃力")]
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
    private void OnTriggerEnter(Collider other)  //Bossが受けるダメージ判定取る用
    {
        Damage(other.tag);
    }
    private void Damage(string tag)
    {
        if(tag == WeaponTag && !playerCtrl.hasHitE)
        {
            health.TakeDamage(playerCtrl.ATK);
            playerCtrl.hasHitE = true;
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
        //プレイヤーとの距離検知で索敵
        float _distance = Vector3.Distance(transform.position, player.position);
        if(_distance < _battleOnDistance)
        {
            anime.SetBool("isBattle",true);
            ChaseAndAttack(_distance);
        }
    }

    void ChaseAndAttack(float _distance)　//追跡と攻撃処理
    {
        if (!agent.pathPending)
        {
            if (_distance > _attackOnDistance)
            {
                //プレイヤーとの方向正規化
                Vector3 dir = (player.position - transform.position).normalized;

                //プレイヤーの手前になるように調整
                Vector3 _stopPosition = player.position - dir * (_attackOnDistance * 0.9f); //そのまま_attackOnDistanceだと攻撃しないバグ発生回避のため

                //移動先を調整した位置に設定
                agent.destination = _stopPosition;
            }
            else
            {
                agent.ResetPath();

                //方向をプレイヤーの方へ向ける処理
                Vector3 lookDir = (player.position - transform.position).normalized;
                lookDir.y = 0f;

                if (lookDir != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(lookDir);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * lookSpeed);
                }

                if (_attackTimer >= _attackCooldown)
                {
                    float _attackNum = Random.Range(1, 3);
                    if(_attackNum == 1)
                    {
                        anime.SetBool("isAttack1", true);
                        Debug.Log("1攻撃");
                    }
                    else
                    {
                        anime.SetBool("isAttack2",true);
                        Debug.Log("2攻撃");
                    }
                    _attackTimer = 0;
                }
            }
        }
    }

    void OnBossAttack1()                   //ボス攻撃パターン１のコライダーオンオフ処理（アニメーションイベントで呼び出し）
    {
        _enemyWeapon1.enabled = true;
        onceDamage.hasHitP = false;
    }
    void OffBossAttack1()
    {
        _enemyWeapon1.enabled = false;
        anime.SetBool("isAttack1", false);
    }

    void OnBossAttack2()                    //ボス攻撃パターン２のコライダーオンオフ処理（アニメーションイベントで呼び出し）
    {
        _enemyWeapon2.enabled = true;
        onceDamage.hasHitP = false;
    }
    void OffBossAttack2()
    {
        _enemyWeapon2.enabled = false;
        anime.SetBool("isAttack2",false);
    }
}
