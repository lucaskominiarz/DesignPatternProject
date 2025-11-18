using System;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager INSTANCE;

    private void Start()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
