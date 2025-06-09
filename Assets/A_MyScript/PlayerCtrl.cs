using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveVelocity;
    private Animator anime;
    [SerializeField] float _moveSpeed;
    private Quaternion targetRotation;
    

    private void Awake()
    {
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
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y,Vector3.up);
        Vector3 moveDirection = horizontalRotation * new Vector3(horizon, 0, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 600 * Time.deltaTime);

            characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);

            anime.SetBool("isRun", true);
        }
        else
        {
            anime.SetBool("isRun", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            anime.SetBool("isAttack", true);
        }
        else
        {
            anime.SetBool("isAttack", false);
        }
    }
}
