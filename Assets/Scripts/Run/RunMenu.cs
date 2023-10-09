using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject deathMenuUI;
    public GameObject winMenuUI;
    public GameObject pauseMenuUI;

    void Start()
    {
        deathMenuUI.SetActive(false);
        winMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (RunCharacterMovement.isLost == true)
        {
            Lose();
        }

        if (RunCharacterMovement.isWon == true)
        {
            Win();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Lose()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        deathMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        deathMenuUI.SetActive(false);
    }

    void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
