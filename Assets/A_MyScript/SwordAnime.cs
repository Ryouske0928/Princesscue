using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnime : MonoBehaviour
{
    //����U��A�j���[�V�����ŌĂяo���Ă�֐�
    [SerializeField] Collider SwordCol;
    void SwordOnEvent()�@//���̓����蔻��On & �U�����͈ړ��s��
    {
        SwordCol.enabled = true;
    }

    void SwordOffEvent()�@//���̓����蔻��Off & �ēx�ړ��\��
    {
        SwordCol.enabled = false;
    }
}
