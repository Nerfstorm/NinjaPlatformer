using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject RectMenuPanel;
    public GameObject RectQuestPanel;
    bool Open1 = false;

    void Start()
    {
        Time.timeScale = 1;
        Open1 = false;
    }
    public void MenuPanel()
    {
        if (Open1 == false)
        {
            LeanTween.moveX(RectMenuPanel, -228f, speed);
            Open1 = true;
        }
        else
        {
            LeanTween.moveX(RectMenuPanel, -311.5f, speed);
            Open1 = false;
        }
    }

    public void QuestPanel()
    {
            LeanTween.moveX(RectQuestPanel, 160f, speed);
    }

    public void CloseQuestPanel()
    {
            LeanTween.moveX(RectQuestPanel, 320f, speed);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Select(string levelName)
    {
        Time.timeScale = 1f;
        // rezolvare eroare freeze 
        SceneManager.LoadScene(levelName);
    }
}
