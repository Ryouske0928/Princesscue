using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffStatus : MonoBehaviour
{
    [SerializeField] List<Image> buffs = new List<Image>();   �@�@�@�@//�o�t�X�e�[�^�X�摜�̃��X�g
    [SerializeField] List<Image> currentBuffs = new List<Image>();�@�@//UI�Ƃ��ĕ\������p�̃o�t���X�g
    
    public void AddBuffStatus(Image setBuff)�@�@//�v���C���[�Ƀo�t�K�p���鎞�̊֐�
    {
        currentBuffs.Add(setBuff);
    }

    public void DeleteBuff(Image currentBuff)
    {
        currentBuffs.Remove(currentBuff);  //���ꂶ�Ⴞ�߂Ȃ͂��E�E�E�@���ƂŌ�����
    }
}
