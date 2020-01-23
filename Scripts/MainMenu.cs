using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Script del main menu

     //Carga la pantalla del primer nivel
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Cierra el juego
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}