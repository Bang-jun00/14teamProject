using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //public GameManager gameManager;

    public static GameOver Instance;

    //public UnityEvent OnPlayerDied = new UnityEvent();

    //public bool IsGameOvered;

    [SerializeField] private GameObject Player;
    //[SerializeField] private GameObject Mon;

    [Header("UI")]
    [SerializeField] private GameObject PlayerDiedPanel;
    [SerializeField] private Button retryBtn;

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

            GameManager.Instance.OnPlayerDied.AddListener(PlayerDied);
            retryBtn.onClick.AddListener(GameManager.Instance.GameStart);
        }
    }


    // private void Start()
    // {
    //     Instance = this;
    // 
    //     GameManager.Instance.OnPlayerDied.AddListener(PlayerDied);
    //     retryBtn.onClick.AddListener(GameManager.Instance.GameStart);
    // }

    public void PlayerDied()
    {
        Player.SetActive(false);
        GameManager.Instance.DeactivateWeapon();
        //GameManager.Instance.DeactivateExpOrb();
        //Mon.SetActive(false);
        GameManager.Instance.IsGameOvered = true;
        PlayerDiedPanel.SetActive(true);
    }
    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPlayerDied.RemoveListener(PlayerDied);
            retryBtn.onClick.RemoveListener(GameManager.Instance.GameStart);
        }
    }
    
}
    
