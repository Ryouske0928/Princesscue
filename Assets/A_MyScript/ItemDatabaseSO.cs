using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();
}
[System.Serializable]
public class ItemData
{
    public string _name;
    public int _itemNum;
    public GameObject _itemPrefab;
    [TextArea]
    public string _description;
}