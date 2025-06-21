using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    [Header("プレイヤーからの攻撃判定コライダーのTag")]
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] Transform player;
    [SerializeField] GameClear gameClear;
    [SerializeField] float _chaseOnDistance;  //索敵距離
    [SerializeField] float _chaseOffDistance; //索敵解除距離
    [SerializeField] float _attackOnDistance; //攻撃開始距離
    [SerializeField] float _moveSpeed;//移動速度
    [Header("巡回先の座標")]
    [SerializeField] Transform[] enemyPoint;　//巡回先の座標取得用
    private int _pointNum;                //巡回座標の要素用
    private float _attackTimer = 0;
    [SerializeField]private float _attackCooldown;
    [Header("敵攻撃判定コライダー")]
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
    private void OnTriggerEnter(Collider other)  //どっちでも反応するように,EnterとStay
    {
        Damage(other.tag);
    }

    private void Damage(string tag)　  //プレイヤーからのダメージ判定
    {
        if (tag == WeaponTag)
        {
            health.TakeDamage(10);
        }
    }

    private void Update()
    {
        _attackTimer += Time.deltaTime;
        //プレイヤーとの距離検知で索敵
        float _distance = Vector3.Distance(transform.position, player.position);
        //巡回と追跡の切り替え処理
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

    void Patrol()　　//巡回処理
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetNextPoint();
        }
    }

    void ChaseAndAttack(float _distance)　//追跡と攻撃処理
    {
        if (!agent.pathPending)
        {
            if(_distance > _attackOnDistance)
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

                if(_attackTimer >= _attackCooldown)
                {
                    Debug.Log("スライム攻撃");
                    _attackTimer = 0;
                }
            }
        }
    }
    void SetNextPoint()　//巡回ルートのセッティング処理
    {
        _pointNum = Random.Range(0, enemyPoint.Length);
        agent.destination = enemyPoint[_pointNum].position;
    }

    //アニメーションイベントで当たり判定 ON & OFF
    void OnEnemyAttack()
    {
        _enemyWeapon.enabled = true;
    }

    void OffEnemyAttack()
    {
        _enemyWeapon.enabled = false;
    }
}
