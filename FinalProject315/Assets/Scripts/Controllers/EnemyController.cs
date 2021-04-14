using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    static Animator animator;
    bool animationPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(animator.GetBool("isAttack1"));
        float distance = Vector3.Distance(target.position, transform.position);

        //if is inside the lookRadius moves it
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position); 

            
            //Debug.Log("Aware true");

            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                
                if (targetStats != null)
                {
                    //Attack Target 
                    //Debug.Log("Attacking target");   
                    
                    if (animator.GetBool("Aware") == true)
                    {
                        animator.SetBool("Aware", false);
                    } 
                    animator.SetBool("isAttack1", true);

                    //animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") 
                    //animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0)

                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
                    {
                        // Avoid any reload.
                        animationPlaying = true;
                    }
                    else if (animationPlaying)
                    {
                        combat.Attack(targetStats);

                        Debug.Log("Finished Attacking right now");
                        animationPlaying = false;
                        // You have just leaved your state!
                    }

                    //if (AnimatorIsPlaying("Attack1"))
                    //{
                        
                    //    combat.Attack(targetStats);
                        
                    //    Debug.Log("Finished Attacking right now");
                   // }
                    
                }
                FaceTarget();
                //animator.SetBool("Attack", true);
            }
            else
            {
                animator.SetBool("isAttack1", false);
                animator.SetBool("Aware", true);
            }
        }
        else
        {
            animator.SetBool("Aware", false);
        }
    } 

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius); 

    }

    bool AnimatorIsPlaying(string stateName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
