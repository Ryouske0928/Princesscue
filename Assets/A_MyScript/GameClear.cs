using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    public  bool DefeatBoss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && DefeatBoss)
        {
            Debug.Log("�P�~�o�I�I�����I");
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
