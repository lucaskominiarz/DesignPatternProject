using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action onCatch;
    
    public void Catch()
    {
        onCatch.Invoke();
    }
    
}
