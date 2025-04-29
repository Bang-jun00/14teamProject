using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats stats;

    public int killCount = 0;

  
    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            GameOver.Instance.OnPlayerDied.Invoke();
        }
        if (killCount == 100)
        {
            GameClear.Instance.OnGameClear.Invoke();
        }
        
    }
    
}
