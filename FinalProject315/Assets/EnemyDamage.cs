using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update 
    public float Health = 100f;
    //public Animator sword;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Health);

        if (Health <= 0)
        {
            Destroy(gameObject); 
            
        }
    } 
    private void OnTriggerEnter(Collider other)
    {
        //other.GetComponent.< Animation > ().animator.GetCurrentAnimatorStateInfo(0).IsName("attacking")
        if (other.tag == "Melee")
        {
            Debug.Log("hit target");
            Destroy(gameObject);
            //Health -= 20f;
        } 
    }
}
