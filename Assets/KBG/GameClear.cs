using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameClear : MonoBehaviour
{
    public static GameClear Instance;

    public UnityEvent OnGameClear = new UnityEvent();

    public bool IsGameCleared;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Mon;

    [Header("UI")]
    [SerializeField] private GameObject GameClearPanel;

    private void Awake()
    {
        if (Instance == null)
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
        OnGameClear.AddListener(MissionComplete);
    }

    public void MissionComplete()
    {
        Player.SetActive(false);
        Mon.SetActive(false);
        IsGameCleared = true;
        GameClearPanel.SetActive(true);
    }
    private void OnDisable()
    {
        OnGameClear.RemoveListener(MissionComplete);
    }
    
}
