using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    //Script para el menú de pausa

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) //Se activa al apretar escape y desactiva de la misma forma
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

	}

    //El botón de resume hace la misma función que pulsa escape

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;


    }

    //Para el juego al estar en pausa
    void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    //Nos lleva al main menu
    public void LoadMenu()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


    //Cierra el juego
    public void QuitGame()
    {

        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
