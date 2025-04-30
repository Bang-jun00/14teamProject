using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player; //Player class���� ȣ��

    public static GameManager Instance; //GameManager Instance ����

    public UnityEvent OnGameClear = new UnityEvent(); // OnGameClear��� UnityEvent�� ���� ��
    public UnityEvent OnPlayerDied = new UnityEvent(); // OnPlayerDied��� UnityEvent�� ���� ��

    [SerializeField] private GameObject Player0; // Player��� ���ӿ�����Ʈ �߰����
    [SerializeField] private Transform respawnPoint; // respawnPoint��� ��ǥ�� �߰����
    //[SerializeField] private GameObject Mon;
    //[SerializeField] private Transform spawnPoint;

    public bool IsGameCleared; // Ŭ���� bool�Լ�
    public bool IsGameOvered; // ���� bool�Լ�

    [SerializeField] private GameObject GameClearPanel; // ����Ŭ���� �г� �߰����
    [SerializeField] private GameObject PlayerDiedPanel; // ���ӽ��� �г� �߰����
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Instance�� null�̸� GameManager Instance ����
            DontDestroyOnLoad(gameObject); // Instance�� �������϶� �����Ѵ�
        }
        else
        {
            Destroy(gameObject); // Instance�� �������� �ƴҶ� �ı��Ѵ�
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
        player.ResetPlayerHealth(); //�÷��̾ �ʱ�ȭ�ؾ� ����� ���ƿ´�. ex:�������
        Player0.transform.position = respawnPoint.position;
        Player0.SetActive(true);

        Player0.GetComponent<Axeskill>().Start();
        //Player.GetComponent<PlayerStats>().isInvincible = false;

        //Mon.transform.position = spawnPoint.position;
        //Mon.SetActive(true);
    }
}
