using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextureScroll[] scrolls;
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        scrolls = FindObjectsOfType<TextureScroll>();
    }
    public void GameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        StopScrolling();
        FreezeObjects();
        gameOverPanel.SetActive(true);
    }
    private void StopScrolling()
    {
        foreach (TextureScroll script in scrolls)
        {
            script.scroll = false;
        }
    }
    private void FreezeObjects() //works but not sure if I like it
    {
        ObstacleSpawner obj = FindObjectOfType<ObstacleSpawner>();
        Obstacle[] objs = obj.GetComponentsInChildren<Obstacle>();

        foreach (Obstacle os in objs)
        {
            os.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void  IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
