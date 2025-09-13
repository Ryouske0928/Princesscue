using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public  bool DefeatBoss;
    [Header("���[�h��V�[��")]
    [SerializeField] private string LoadScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && DefeatBoss)
        {
            Debug.Log("�X�e�[�W�N���A");
            SceneManager.LoadScene(LoadScene);
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
