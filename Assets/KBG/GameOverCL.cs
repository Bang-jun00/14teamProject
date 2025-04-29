using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverCL : MonoBehaviour
{
    public static GameOverCL Instance;

    public UnityEvent OnPlayerDied = new UnityEvent();

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
    private void OnEnable()
    {
        OnPlayerDied.AddListener(GameOver);
    }
    void Update()
    {
        
    }
    public void GameOver()
    {

    }
    private void OnDisable()
    {
        OnPlayerDied.RemoveListener(GameOver);
    }

}
