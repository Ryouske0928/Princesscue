using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHp;
    private int currentHp;
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
        currentHp -= damage;
    }

    public void Heal(int amount)
    {
        currentHp += amount;
    }

    public void Die()
    {
        Debug.Log("€–S");
        Destroy(gameObject);
    }
}
