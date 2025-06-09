using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    private void OnTriggerEnter(Collider other)
    {
        Damage(other.tag);
    }

    private void OnTriggerStay(Collider other)
    {
        Damage(other.tag);
    }

    private void Damage(string tag)
    {
        Debug.Log("“–‚½‚Á‚½" + tag);
        if (tag == WeaponTag)
        {
            Destroy(gameObject);
        }
    }
}
