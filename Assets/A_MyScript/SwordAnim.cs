using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnim : MonoBehaviour
{
    [SerializeField] Collider SwordCol;

    void SwordOnEvent()
    {
        SwordCol.enabled = true;
    }

    void SwordOffEvent()
    {
        SwordCol.enabled = false;
    }
}
