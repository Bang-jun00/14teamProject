using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;

    public UnityEvent OnPlayerDied = new UnityEvent();

    public bool IsGameOvered;

    [SerializeField] private GameObject Player;

    [Header("UI")]
    [SerializeField] private GameObject PlayerDiedPanel;

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
        OnPlayerDied.AddListener(PlayerDied);
    }

    public void PlayerDied()
    {
        Player.SetActive(false);
        IsGameOvered = true;
        PlayerDiedPanel.SetActive(true);
    }
    private void OnDisable()
    {
        OnPlayerDied.RemoveListener(PlayerDied);
    }

}
