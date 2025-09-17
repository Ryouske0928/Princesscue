using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHp;
    private int currentHp;
    public Image HPGage;
    public int CurrentHp
    {
        get => currentHp;

        set
        {
            currentHp = Mathf.Clamp(value, 0, maxHp); //0～maxHpの間で値を制限

            if (currentHp <= 0)
            {
                Die();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        float percent = (float)CurrentHp / maxHp;
        HPGage.fillAmount = percent;
        Debug.Log(currentHp);
    }

    public void Heal(int amount)
    {
        CurrentHp += amount;
        float percent = (float)CurrentHp / maxHp;
        HPGage.fillAmount = percent;
        AudioManager.Instance.IsPlaySE("回復ポーション");
    }

    public void Die()
    {
        Debug.Log("死亡");
        Destroy(gameObject);
    }
}
