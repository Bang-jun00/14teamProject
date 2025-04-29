using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 100;
    public int killCount = 0;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (playerHealth <= 0)
        {
            GameOverCL.Instance.OnPlayerDied.Invoke();
        }
        if (killCount == 100)
        {
            GameOverCL.Instance.OnGameClear.Invoke();
        }
        
    }
    
}
