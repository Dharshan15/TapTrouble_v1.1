using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public TextMeshProUGUI winText;
    public List<GameObject> livesList;

    float[] leftXPos ={ -1.875f, -0.625f };
    float[] rightXPos = { 1.875f, 0.625f };
    public int score = 0;
    public bool isGameOver = false;

    

    private void Awake()
    {
        EnemyController.speed = 1f;
    }
    void Start()
    {
        StartCoroutine(SpawnLeft());
        StartCoroutine(SpawnRight());
        StartCoroutine(Timer());
    }

    
    void Update()
    {
        scoreText.text = score.ToString();
        if (score == 200)
        {
            GameOver();
            winText.gameObject.SetActive(true);
        }
    }

    IEnumerator SpawnLeft()
    {
        while(true)
        {
            int randomIndexForX = Random.Range(0, 2);
            int randomIndexForEnemy = Random.Range(0, 2);
            GameObject randomEnemy = enemiesList[randomIndexForEnemy];
            float waitTime = Random.Range(2f, 4f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(randomEnemy,  new Vector2(leftXPos[randomIndexForX],5.6f), Quaternion.identity);                
        }
    }
    IEnumerator SpawnRight()
    {
        while (true)
        {
            int randomIndexForX = Random.Range(0, 2);
            int randomIndexForEnemy = Random.Range(0, 2);
            GameObject randomEnemy = enemiesList[randomIndexForEnemy];
            float waitTime = Random.Range(2f, 4f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(randomEnemy, new Vector2(rightXPos[randomIndexForX], 5.6f), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            score += 1;
        }
    }
}
