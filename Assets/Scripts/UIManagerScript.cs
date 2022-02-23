using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManagerScript : MonoBehaviour
{
    
    public GameObject PrepareScene;
    public GameObject endGameUI;
    public GameObject gameOverUI;
    public GameObject startingGameUI;
    public GameObject DistanceText;
    public GameObject PrepareStartButton;
    public GameObject healthText;

    public static int playerHealth = 2;

    GameObject player;
    [SerializeField]
    float distance = 200;
    Text distanceText;

    RoadSpawner roadSpawner;

    public bool isGameStarting = false;

    void Start()
    {
        isGameStarting = false;
        roadSpawner = GameObject.Find("SpawnManager").GetComponent<RoadSpawner>();
        player = GameObject.Find("Limo");
        playerHealth = 2;
        healthText.GetComponent<Text>().text = "Health: " + playerHealth; 
  
        distanceText = DistanceText.GetComponent<Text>();
        distanceText.text = "Distance: " + distance;
        
    }

    void Update()
    {      

        if (isGameStarting)
        {
            distance -= 10 * Time.deltaTime;

            distanceText.text = "Distance: " + distance;

            healthText.GetComponent<Text>().text = "Health: " + playerHealth;

            if (playerHealth == 0)
            {
                isGameStarting = false;
                StartCoroutine(RestartLevel());
            }
            if (distance <= 1)
            {                        
                isGameStarting = false;
                StartCoroutine(EndLevel());
            }
        }
    }

    public void StartButton()
    {
        PrepareStartButton.SetActive(false);
        StartGame();
        PrepareScene.SetActive(false);
    }

    void StartGame()
    {
        isGameStarting = true;
  
    }
    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(0.5f);  
        endGameUI.SetActive(true);
        startingGameUI.SetActive(false);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(0.5f);
        startingGameUI.SetActive(false);
        gameOverUI.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameScene");
    }
}

