using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeHit()
    {
        playerHealth--;

        if (playerHealth <= 0)
        {
            GameOverCL.Instance.OnPlayerDied.Invoke();
        }
    }
}
