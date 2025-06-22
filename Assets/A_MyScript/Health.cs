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
            currentHp = Mathf.Clamp(value, 0, maxHp); //0`maxHp‚ÌŠÔ‚Å’l‚ğ§ŒÀ

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
        Debug.Log(CurrentHp);
    }

    public void Heal(int amount)
    {
        CurrentHp += amount;
        float percent = (float)CurrentHp / maxHp;
        HPGage.fillAmount = percent;
        Debug.Log(CurrentHp);
    }

    public void Die()
    {
        Debug.Log("€–S");
        Destroy(gameObject);
    }
}
