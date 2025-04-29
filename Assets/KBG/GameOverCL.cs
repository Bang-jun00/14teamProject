using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverCL : MonoBehaviour
{
    public static GameOverCL Instance;

    public UnityEvent OnPlayerDied = new UnityEvent();

    public UnityEvent OnGameClear = new UnityEvent();

    public bool IsGameOvered;
    public bool IsGameCleared;

    [SerializeField] private GameObject Player;

    [Header("UI")]
    [SerializeField] private GameObject PlayerDiedPanel;
    [SerializeField] private GameObject GameClearPanel;

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
        OnGameClear.AddListener(GameOver);
        OnPlayerDied.AddListener(GameOver);
    }
    
    public void GameOver()
    {
        Clear();
        Fail();
        
    }
    private void OnDisable()
    {
        OnGameClear.RemoveListener(GameOver);
        OnPlayerDied.RemoveListener(GameOver);
    }
    public void Fail()
    {
        Player.SetActive(false);
        IsGameOvered = true;
        PlayerDiedPanel.SetActive(true);
    }
    public void Clear()
    {
        Player.SetActive(false);
        IsGameCleared = true;
        GameClearPanel.SetActive(true);
    }
}
