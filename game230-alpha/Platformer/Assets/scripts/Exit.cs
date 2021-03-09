using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2.0f;
    [SerializeField] float slowMoFactor = 0.2f;
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {

        Time.timeScale = slowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);


        Time.timeScale = 1.0f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        Destroy(FindObjectOfType<ScenePersist>().gameObject);
    }
}
