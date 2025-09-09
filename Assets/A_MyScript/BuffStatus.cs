using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffStatus : MonoBehaviour
{
    [SerializeField] List<Image> buffs = new List<Image>();   　　　　//バフステータス画像のリスト
    [SerializeField] List<Image> currentBuffs = new List<Image>();　　//UIとして表示する用のバフリスト
    
    public void AddBuffStatus(Image setBuff)　　//プレイヤーにバフ適用する時の関数
    {
        currentBuffs.Add(setBuff);
    }

    public void DeleteBuff(Image currentBuff)
    {
        currentBuffs.Remove(currentBuff);  //これじゃだめなはず・・・　あとで見直し
    }
}
