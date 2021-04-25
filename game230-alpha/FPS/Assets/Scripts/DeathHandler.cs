using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverUi;
    [SerializeField] Canvas gunReticle;

    void Start()
    {
        gameOverUi.enabled = false;
        gunReticle.enabled = true;
    }

    public void ProcessDeath()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject tagged in taggedObjects)
        {
            tagged.SetActive(false); // o r true
        }
        gameOverUi.enabled = true;
        gunReticle.enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
