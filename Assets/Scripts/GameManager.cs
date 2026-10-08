using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text; 
    private int coin = 0; 

    [SerializeField]
    private GameObject gameOverPanel; 

    [HideInInspector]
    public bool isGameOver = false; 
    private int score = 0;

    public bool IsGameOver => isGameOver;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        if (text != null)
        {
            text.SetText("0");
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        if (text != null)
        {
            text.SetText(coin.ToString());
        }

        if (coin % 30 ==0)
        {
            Player player = FindObjectOfType<Player>(); 
            if (player != null)
            {
                player.Upgrade();
            }
        }
        
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public void SetGameOver()
    {
        isGameOver = true; 

        EnemySpawner enemySpawner= FindObjectOfType<EnemySpawner> ();
        if (enemySpawner != null )
        {
            enemySpawner.StopEnemyRoutine();
        }

    Invoke("ShowGameOverPanel", 1f); 
    }

    private void ShowGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
}
