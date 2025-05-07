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
    // public Player player; //Player class���� ȣ��
    

    public static GameManager Instance; //GameManager Instance ���� //gamemanager�� null�ϋ� gamemanager�� ���� or title scene

    public UnityEvent OnGameClear = new UnityEvent(); // OnGameClear��� UnityEvent�� ���� ��
    public UnityEvent OnPlayerDied = new UnityEvent(); // OnPlayerDied��� UnityEvent�� ���� ��

    [SerializeField] private GameObject Player; // Player��� ���ӿ�����Ʈ �߰����
    //[SerializeField] private Transform respawnPoint; // respawnPoint��� ��ǥ�� �߰����
    //[SerializeField] private GameObject Mon;
    //[SerializeField] private Transform spawnPoint;

    public bool IsGameCleared; // Ŭ���� bool�Լ�
    public bool IsGameOvered; // ���� bool�Լ�

    public int killCount = 0;

    [SerializeField] private GameObject GameClearPanel; // ����Ŭ���� �г� �߰����
    [SerializeField] private GameObject PlayerDiedPanel; // ���ӽ��� �г� �߰����
    

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
        ResetPlayerHealth(); //�÷��̾ �ʱ�ȭ�ؾ� ����� ���ƿ´�. ex:�������
        ResetKillCount();
        
        //Player0.transform.position = respawnPoint.position;
        Player.SetActive(true);

        Player.GetComponent<Axeskill>().Start();
        //Player0.GetComponent<PlayerStats>().isInvincible = false; // �÷��̾� �������� ����

        //Mon.transform.position = spawnPoint.position;
        //Mon.SetActive(true);
    }

    public void DeactivateWeapon() // ���� ȸ��
    {
        GameObject[] objAxes = GameObject.FindGameObjectsWithTag("Weapon");

        foreach (GameObject objAxe in objAxes)
        {
            objAxe.SetActive(false);
        }
    }
    // public void DeactivateExpOrb() // ����ġ���� ���ֱ�
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
        Debug.Log("���� ���� �� : " + killCount);
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
