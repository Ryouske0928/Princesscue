using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffStatus : MonoBehaviour
{
    [SerializeField] public GameObject buffIconPref;  �@�@�@�@//�o�t�X�e�[�^�X�摜�̃��X�g
    [SerializeField] private Transform buffPanel; �@�@//UI�Ƃ��ĕ\������p�̃o�t���X�g

    [SerializeField]private Sprite attackUpSprite;

    private Dictionary<string, Sprite> buffSprites;
    private Dictionary<string, GameObject> activeBuffs = new Dictionary<string, GameObject>();

    private void Start()
    {
        buffSprites = new Dictionary<string, Sprite>()
        {
            {"AttackUp", attackUpSprite }
        };
    }

    public void AddBuffStatus(string buffName)�@�@//�v���C���[�Ƀo�t�K�p���鎞�̊֐�
    {
        if(activeBuffs.ContainsKey(buffName)) return;  //�����o�t�Ȃ�Q�d�ɂ��Ȃ�

        if(buffSprites.ContainsKey(buffName))
        {
            GameObject newBuff = Instantiate(buffIconPref, buffPanel);
            newBuff.GetComponent<Image>().sprite = buffSprites[buffName];
            activeBuffs.Add(buffName, newBuff);
            AudioManager.Instance.IsPlaySE("�Η�UP");
        }
    }

    public void DeleteBuff(string buffName)
    {
        if (activeBuffs.ContainsKey(buffName))
        {
            Destroy(activeBuffs[buffName]);
            activeBuffs.Remove(buffName);
        }

    }
}
