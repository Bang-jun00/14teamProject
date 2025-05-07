using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerStats stats;
    // public Player player; //Player class에서 호출
    

    public static GameManager Instance; //GameManager Instance 선언 //gamemanager이 null일떄 gamemanager을 생성 or title scene

    public UnityEvent OnGameClear = new UnityEvent(); // OnGameClear라는 UnityEvent를 생성 후
    public UnityEvent OnPlayerDied = new UnityEvent(); // OnPlayerDied라는 UnityEvent를 생성 후

    [SerializeField] private GameObject Player; // Player라는 게임오브젝트 추가기능
    //[SerializeField] private Transform respawnPoint; // respawnPoint라는 좌표값 추가기능
    //[SerializeField] private GameObject Mon;
    //[SerializeField] private Transform spawnPoint;

    public bool IsGameCleared; // 클리어 bool함수
    public bool IsGameOvered; // 실패 bool함수

    public int killCount = 0;

    [SerializeField] private GameObject GameClearPanel; // 게임클리어 패널 추가기능
    [SerializeField] private GameObject PlayerDiedPanel; // 게임실패 패널 추가기능
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        PlayerHp0();

        killCountMax();
    }

    public void GameStart()
    {
        GameClearPanel.SetActive(false);
        PlayerDiedPanel.SetActive(false);
        IsGameOvered = false;
        IsGameCleared = false;
        ResetPlayerHealth(); //플레이어를 초기화해야 기능이 돌아온다. ex:도끼기능
        ResetKillCount();
        
        //Player0.transform.position = respawnPoint.position;
        Player.SetActive(true);

        Player.GetComponent<Axeskill>().Start();
        //Player0.GetComponent<PlayerStats>().isInvincible = false; // 플레이어 무적상태 해제

        //Mon.transform.position = spawnPoint.position;
        //Mon.SetActive(true);
    }

    public void DeactivateWeapon() // 무기 회수
    {
        GameObject[] objAxes = GameObject.FindGameObjectsWithTag("Weapon");

        foreach (GameObject objAxe in objAxes)
        {
            objAxe.SetActive(false);
        }
    }
    // public void DeactivateExpOrb() // 경험치구슬 없애기
    // {
    //     GameObject[] objOrbs = GameObject.FindGameObjectsWithTag("Exp");
    // 
    //     foreach (GameObject objOrb in objOrbs)
    //     {
    //         objOrb.SetActive(false);
    //     }
    // }
    public void PlayerHp0()
    {
        if (stats.currentHealth <= 0)
        {
            OnPlayerDied.Invoke();

            if (IsGameOvered)
            {
                IsGameOvered = false;
                GameOver.Instance.PlayerDied();
            }
        }
    }
    public void AddKillCount()
    {
        killCount++;
        Debug.Log("잡은 몬스터 수 : " + killCount);
    }
    public void killCountMax()
    {
        if(killCount >= 1)
        {
            OnGameClear.Invoke();

            if (IsGameCleared)
            {
                IsGameCleared = false;
                GameClear.Instance.MissionComplete();
            }
        }
    }
    
    public void ResetPlayerHealth()
    {
        stats.currentHealth = stats.currentMaxHealth;
    }
    public void ResetKillCount()
    {
        killCount = 0;
    }
    
}
