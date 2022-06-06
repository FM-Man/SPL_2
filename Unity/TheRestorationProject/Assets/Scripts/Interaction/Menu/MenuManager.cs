using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class MenuManager : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject startMenuUI;
    public StarterAssetsInputs inputSystem;
    //int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        startMenuUI.SetActive(true);
        GameIsPaused = true;
        inputSystem = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameIsPaused && inputSystem.pause)
        {
            Pause();
            inputSystem.pause = false;
        }
    }

    public void Pause()
    {
        if (!GameIsPaused)
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
            GameIsPaused = true;
        }
    }

    public void Resume()
    {
        if (GameIsPaused)
        {
            GameIsPaused = false;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Play()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 1f;
            startMenuUI.SetActive(false);
            GameIsPaused = false;
        }
    }

}
