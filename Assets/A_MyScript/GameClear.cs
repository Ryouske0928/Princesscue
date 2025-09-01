using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public  bool DefeatBoss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && DefeatBoss)
        {
            Debug.Log("姫救出！！結婚！");

            //if(yPoint > 40) ～～　シーンロード先変更処理
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DefeatBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
