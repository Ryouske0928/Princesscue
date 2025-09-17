using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffStatus : MonoBehaviour
{
    [SerializeField] public GameObject buffIconPref;  　　　　//バフステータス画像のリスト
    [SerializeField] private Transform buffPanel; 　　//UIとして表示する用のバフリスト

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

    public void AddBuffStatus(string buffName)　　//プレイヤーにバフ適用する時の関数
    {
        if(activeBuffs.ContainsKey(buffName)) return;  //同じバフなら２重にしない

        if(buffSprites.ContainsKey(buffName))
        {
            GameObject newBuff = Instantiate(buffIconPref, buffPanel);
            newBuff.GetComponent<Image>().sprite = buffSprites[buffName];
            activeBuffs.Add(buffName, newBuff);
            AudioManager.Instance.IsPlaySE("火力UP");
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
