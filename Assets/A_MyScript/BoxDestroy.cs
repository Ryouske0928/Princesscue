using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    private void OnTriggerEnter(Collider other)  //�ǂ����ł���������悤��,Enter��Stay
    {
        BoxDamage(other.tag);
    }

    private void OnTriggerStay(Collider other)
    {
        BoxDamage(other.tag);
    }

    private void BoxDamage(string tag)�@  //�A�C�e��Box�j�󔻒�
    {
        Debug.Log("���j��I" + tag);
        if (tag == WeaponTag)
        {
            Destroy(gameObject);

        }
    }
}
