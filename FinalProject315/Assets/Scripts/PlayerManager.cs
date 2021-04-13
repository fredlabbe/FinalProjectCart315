using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton  

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion 

    public GameObject player;
    public Camera mainCamera;

    private float range = 3f;

    int delay = 50;

    // Update is called once per frame
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetButtonDown("Fire1"))
        {
            
            delay += 1;
            if (delay >= 15)
            {
                delay = 0;
                Ray clickRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit result;
                if (Physics.Raycast(clickRay, out result) && result.collider.tag == "Enemy")
                { 
                    if(result.distance > 1.5)
                    {
                        //GameObject.Instantiate(player, result.point, Quaternion.identity); 
                        //Attack enemy  
                        Debug.Log("Plyaer Attacking");
                    }
                    
                }
            }

        }
        else
        {
            delay = 50;
        }
    }
}
