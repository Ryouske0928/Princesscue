using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnime : MonoBehaviour
{
    //����U��A�j���[�V�����ŌĂяo���Ă�֐�
    [SerializeField] Collider SwordCol;
    [SerializeField] PlayerCtrl playerCtrl;
    void SwordOnEvent()�@//���̓����蔻��On & �U�����͈ړ��s��
    {
        SwordCol.enabled = true;
        playerCtrl.hasHitE = false;
    }

    void SwordOffEvent()�@//���̓����蔻��Off & �ēx�ړ��\��
    {
        SwordCol.enabled = false;
    }
}
