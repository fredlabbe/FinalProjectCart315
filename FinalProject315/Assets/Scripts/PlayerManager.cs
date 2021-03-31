using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    #region Singleton 

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion 

    public GameObject player;
}
