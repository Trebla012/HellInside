using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCanvas : MonoBehaviour {

    //Script del canvas de fin de nivel
    
    public void LoadMenu() //Si pulsamos el botón nos lleva al menú principal
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart() //Si pulsamos el botón reinicia la partida
    {
        SceneManager.LoadScene(1);
    }

}
