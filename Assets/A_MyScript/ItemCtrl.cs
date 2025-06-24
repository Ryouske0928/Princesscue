using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    private enum ItemType
    {
        Potion,
        AttackUp,
        Coin
    }
    [Header("�A�C�e������")]
    [SerializeField] private ItemType itemType;
    [Header("�񕜗�")]
    [SerializeField] private int _healAmount;
    [Header("�U��up�̒l")]
    [SerializeField] private int _attackUp;

    //�A�C�e���̎擾�����蔻��
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            PlayerCtrl power = other.GetComponentInParent<PlayerCtrl>();
            Health hp = other.GetComponentInParent<Health>();
            GetItem(power, hp);
            Destroy(gameObject);
        }
    }
    
    //�A�C�e���擾���̏���
    void GetItem(PlayerCtrl power, Health hp)
    {
        switch (itemType)
        {
            case ItemType.Potion:�@�@�@�@�@�@�@�@//�q�[���|�[�V����
                hp.Heal(_healAmount);
                break;

            case ItemType.AttackUp:�@�@�@�@�@�@�@//�Η�UP�A�C�e��
                power.OnAttackUp(_attackUp);
                break;
            case ItemType.Coin:�@�@�@�@�@�@�@�@�@//���Ȗ��R�C��

                break;
        }
    }
    
}
