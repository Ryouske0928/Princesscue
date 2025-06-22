using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();　//データのリスト化
}

//アイテムのデータ
[System.Serializable]
public class ItemData
{
    public string _name;
    public int _Num;
    public GameObject _itemPrefab;
    [TextArea]
    public string _description;
}