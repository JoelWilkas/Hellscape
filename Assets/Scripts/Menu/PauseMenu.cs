using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;

    [SerializeField] private GameObject pauseMenuUi;






    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused) Resume();
            else Pause();
        }
    }




    private void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

}
