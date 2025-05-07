using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    //public GameManager gameManager;

    public static GameClear Instance;
    // 
    //public UnityEvent OnGameClear = new UnityEvent();
    // 
    //public bool IsGameCleared;
    // 
    [SerializeField] private GameObject Player;
    //[SerializeField] private GameObject Mon;

    [Header("UI")]
    [SerializeField] private GameObject GameClearPanel;
    [SerializeField] private Button nextStageBtn;
    [SerializeField] private Button retryBtn;
    // 
    private void Awake()
    {
        
        //if (Instance == null)
        //{
        //    Debug.LogError("GameManager.Instance가 null입니다!");
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnEnable()
    {
        StartCoroutine(WaitForGameManager());
    }

    private IEnumerator WaitForGameManager()
    {
        while (GameManager.Instance == null)
            yield return null;

        if (GameManager.Instance != null)
        {
            Instance = this;

            GameManager.Instance.OnGameClear.AddListener(MissionComplete);
            retryBtn.onClick.AddListener(GameManager.Instance.GameStart);
            nextStageBtn.onClick.AddListener(GameManager.Instance.GameStart);
        }
    }
    // private void Start()
    // {
    //     Instance = this;
    // 
    //     GameManager.Instance.OnGameClear.AddListener(MissionComplete);
    //     retryBtn.onClick.AddListener(GameManager.Instance.GameStart);
    // }

    public void MissionComplete()
    {
        Player.SetActive(false);
        GameManager.Instance.DeactivateWeapon();
        //GameManager.Instance.DeactivateExpOrb();
        //Mon.SetActive(false);
        GameManager.Instance.IsGameCleared = true;
        GameClearPanel.SetActive(true);
    }
    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameClear.RemoveListener(MissionComplete);
            retryBtn.onClick.RemoveListener(GameManager.Instance.GameStart);
            nextStageBtn.onClick.RemoveListener(GameManager.Instance.GameStart);
        }
    }

}
