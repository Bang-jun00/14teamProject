using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCL : MonoBehaviour
{
    public static GameOverCL Instance;

    int playerHealth;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void GameOver()
    {

    }

    public void TakeHit()
    {
        playerHealth--;

        if (playerHealth <= 0)
        {
            GameOverCL.Instance.GameOver();
        }
    }
}
