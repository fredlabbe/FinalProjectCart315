using UnityEngine;

public class CharacterStats : MonoBehaviour
{ 
    public int maxHealth = 1000; 
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(100);
        }*/
        Debug.Log(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        
        currentHealth -= damage;
        Debug.Log(transform.name + " takes" + damage + " damage."); 

        if(currentHealth <= 0)
        {
            Die();
        } 
    } 

    public virtual void Die()
    {
        // Die in some way 
        // This method is meant to be overidden 
        Debug.Log(transform.name + " died.");
    }
}