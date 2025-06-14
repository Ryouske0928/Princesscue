using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{
    private CharacterController characterController;
    private Animator anime;
    [SerializeField] float _moveSpeed;
    private Quaternion targetRotation;
    public bool canMove = true;
    [SerializeField]private float _jumpPower;
    private float _gravity = -9.8f;
    private Vector3 velocityY;
    private GameClear GameClear;

    private void Awake()
    {
        GameClear = GetComponent<GameClear>();
        targetRotation = transform.rotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anime = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //プレイヤーの移動処理
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var rotationSpeed = 600 * Time.deltaTime;

        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);　//カメラy軸の角度取得と回転作成
        Vector3 moveDirection = horizontalRotation * new Vector3(horizon, 0, vertical).normalized; //プレイヤーの移動方向をカメラ基準に回転して移動

        //ジャンプ時の処理
        if(characterController.isGrounded)
        {
            velocityY.y = -0.5f;　　　//地面に押し付ける力
            if (Input.GetButtonDown("Jump"))
            {
                velocityY.y = _jumpPower;
                anime.SetBool("isJump",true);
            }
            else
            {
                anime.SetBool("isJump",false);
            }
        }
        //重力適応
        velocityY.y += _gravity * Time.deltaTime;

        //移動方向を向いていどう　　アニメーション処理
        Vector3 combinedMove = Vector3.zero;
        if (moveDirection.magnitude >= 0.1f && canMove)
        {
            targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);

            combinedMove = moveDirection * _moveSpeed;
            anime.SetBool("isRun", true);
        }

        //空中で攻撃時はそのまま移動するように処理
        else if(anime.GetBool("isAttack") && !canMove && !characterController.isGrounded)
        {
            Debug.Log("わたしが呼ばれた！");
            combinedMove = moveDirection * _moveSpeed;
        }

        else
        {
            anime.SetBool("isRun", false);
        }

        //移動とジャンプのベクトルを合わせて実際にキャラ移動
        combinedMove.y = velocityY.y;
        characterController.Move(combinedMove * Time.deltaTime);

        //攻撃アニメーション(剣)
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            anime.SetBool("isAttack", true);
            canMove = false;
        }


        //剣のアニメーション終了後を検知して移動可能に
        AnimatorStateInfo attackAnime = anime.GetCurrentAnimatorStateInfo(0);
        if (attackAnime.IsName("HumanM@Attack1H01_R") && attackAnime.normalizedTime >= 1 && !canMove)
        {
            Debug.Log("振り終わった！");
            anime.SetBool("isAttack", false);
            canMove = true;
        }
    }
}
