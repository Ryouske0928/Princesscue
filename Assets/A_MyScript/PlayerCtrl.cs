using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{
    private CharacterController characterController;
    private Animator anime;
    [SerializeField] float _moveSpeed;�@//�ړ����x
    private Quaternion targetRotation;�@//�v���C���[�̉�]�擾�p
    public bool canMove = true;�@�@�@�@//
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
        //�v���C���[�̈ړ�����
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var rotationSpeed = 600 * Time.deltaTime;�@//��]���x

        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);�@//�J����y���̊p�x�擾�Ɖ�]�쐬
        Vector3 moveDirection = horizontalRotation * new Vector3(horizon, 0, vertical).normalized; //�v���C���[�̈ړ��������J������ɉ�]���Ĉړ�

        //�W�����v���̏���
        if(characterController.isGrounded)
        {
            velocityY.y = -0.5f;�@�@�@//�n�ʂɉ����t�����
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
        //�d�͓K��
        velocityY.y += _gravity * Time.deltaTime;

        //�ړ������������Ă��ǂ��@�@�A�j���[�V��������
        Vector3 combinedMove = Vector3.zero;                       //���� combinedMove�ōŏI�I�ɏd�͂ƈړ��x�N�g�������킹��
        if (moveDirection.magnitude >= 0.1f && canMove)
        {
            targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);

            combinedMove = moveDirection * _moveSpeed;
            anime.SetBool("isRun", true);
        }

        //�󒆂ōU�����͂��̂܂܈ړ�����悤�ɏ���
        else if(anime.GetBool("isAttack") && !canMove && !characterController.isGrounded)
        {
            combinedMove = moveDirection * _moveSpeed;
        }

        else
        {
            anime.SetBool("isRun", false);
        }

        //combinedMove�ňړ��ƃW�����v�̃x�N�g�������킹�Ď��ۂɃL�����ړ�
        combinedMove.y = velocityY.y;
        characterController.Move(combinedMove * Time.deltaTime);

        //�U���A�j���[�V����(��)
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            anime.SetBool("isAttack", true);
            canMove = false;
        }


        //���̃A�j���[�V�����I��������m���Ĉړ��\��
        AnimatorStateInfo attackAnime = anime.GetCurrentAnimatorStateInfo(0);
        if (attackAnime.IsName("HumanM@Attack1H01_R") && attackAnime.normalizedTime >= 1 && !canMove)
        {
            anime.SetBool("isAttack", false);
            canMove = true;
        }
    }
}
