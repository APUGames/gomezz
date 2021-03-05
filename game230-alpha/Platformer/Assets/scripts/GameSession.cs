using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;

    [SerializeField] Text lives;
    [SerializeField] Text score;



    private void Awake()
    {
        //will find # of occurences of this game object
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        lives.text = playerLives.ToString();
        score.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            SubtractLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void ProcessPlayerScore(int points)
    {
        score += points;
        score.text = points.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);

        Destroy(gameObject);
    }

    private void SubtractLife()
    {
        playerLives--;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        lives.text = playerLives.ToString();
    }
}