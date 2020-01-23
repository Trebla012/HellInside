using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    //Script para el menú de opciones

    public AudioMixer audioMixer; //Controla el volumen de la música

    //Barra de control de volumen
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //Botón para pantalla completa o ventana
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
