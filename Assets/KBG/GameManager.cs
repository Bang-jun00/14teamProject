using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player; //Player class에서 호출

    public static GameManager Instance; //GameManager Instance 선언

    public UnityEvent OnGameClear = new UnityEvent(); // OnGameClear라는 UnityEvent를 생성 후
    public UnityEvent OnPlayerDied = new UnityEvent(); // OnPlayerDied라는 UnityEvent를 생성 후

    [SerializeField] private GameObject Player0; // Player라는 게임오브젝트 추가기능
    [SerializeField] private Transform respawnPoint; // respawnPoint라는 좌표값 추가기능
    //[SerializeField] private GameObject Mon;
    //[SerializeField] private Transform spawnPoint;

    public bool IsGameCleared; // 클리어 bool함수
    public bool IsGameOvered; // 실패 bool함수

    [SerializeField] private GameObject GameClearPanel; // 게임클리어 패널 추가기능
    [SerializeField] private GameObject PlayerDiedPanel; // 게임실패 패널 추가기능
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Instance가 null이면 GameManager Instance 동작
            DontDestroyOnLoad(gameObject); // Instance가 동작중일땐 유지한다
        }
        else
        {
            Destroy(gameObject); // Instance가 동작중이 아닐땐 파괴한다
        }
    }
    void Update()
    {
        if (IsGameCleared)
        {
            IsGameCleared = false;
            GameClear.Instance.MissionComplete();
        }
        if (IsGameOvered)
        {
            IsGameOvered = false;
            GameOver.Instance.PlayerDied();
        }
    }

    public void GameStart()
    {
        GameClearPanel.SetActive(false);
        PlayerDiedPanel.SetActive(false);
        IsGameOvered = false;
        IsGameCleared = false;
        player.ResetPlayerHealth(); //플레이어를 초기화해야 기능이 돌아온다. ex:도끼기능
        Player0.transform.position = respawnPoint.position;
        Player0.SetActive(true);

        Player0.GetComponent<Axeskill>().Start();
        //Player.GetComponent<PlayerStats>().isInvincible = false;

        //Mon.transform.position = spawnPoint.position;
        //Mon.SetActive(true);
    }
}
