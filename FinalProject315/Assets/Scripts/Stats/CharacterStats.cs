using UnityEngine;

public class CharacterStats : MonoBehaviour
{ 
    public int maxHealth = 200; 
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    public event System.Action<int, int> OnHealthChanged;

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
        //Debug.Log(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        
        currentHealth -= damage;
        Debug.Log(transform.name + " takes" + damage + " damage.");
        Debug.Log(currentHealth);

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
            Debug.Log("In CharacterStats' OnHealthChanged");
        }

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
