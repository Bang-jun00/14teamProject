using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats stats;

    public int killCount = 0;

    public void ResetPlayerHealth()
    {
        stats.currentHealth = stats.currentMaxHealth;
    }
    public void ResetKillCount()
    {
        killCount = 0;
    }
    

  
    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            GameManager.Instance.OnPlayerDied.Invoke();
        }
        if (killCount == 100)
        {
            GameManager.Instance.OnGameClear.Invoke();
        }
        
    }
    
}
