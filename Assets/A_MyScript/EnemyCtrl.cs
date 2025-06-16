using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] Transform player;
    [SerializeField] GameClear gameClear;
    [SerializeField] float _chaseOnDistance;  //索敵距離
    [SerializeField] float _chaseOffDistance; //索敵解除距離
    [SerializeField] float _attackOnDistance; //攻撃開始距離
    [SerializeField] float _moveSpeed;//移動速度
    [SerializeField] Transform[] enemyPoint;
    private int _pointNum;
    private NavMeshAgent agent;
    enum EnemyState
    {
        Patrol,
        Chase
    }
    private EnemyState _enemyState;
    private void Start()
    {
        _pointNum = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = enemyPoint[_pointNum].position;

        Debug.Log(enemyPoint.Length);
    }
    private void OnTriggerEnter(Collider other)  //どっちでも反応するように,EnterとStay
    {
        Damage(other.tag);
    }

    private void OnTriggerStay(Collider other)
    {
        Damage(other.tag);
    }

    private void Damage(string tag)　  //ダメージ判定
    {
        if (tag == WeaponTag)
        {
            gameClear.DefeatBoss = true;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //プレイヤーとの距離検知で索敵
        float _distance = Vector3.Distance(transform.position, player.position);

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

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetNextPoint();
        }
    }

    void ChaseAndAttack(float _distance)
    {
        if (!agent.pathPending)
        {
            agent.destination = player.position;
        }
        if (_distance <= _attackOnDistance)
        {
            Debug.Log("スライム攻撃");
        }
    }
    void SetNextPoint()
    {
        _pointNum = Random.Range(0, enemyPoint.Length);
        agent.destination = enemyPoint[_pointNum].position;
    }
}
