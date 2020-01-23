using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour {

    //Script para llamar a la barra de vida del enemigo ponerle la salud máxima o restarle vida 

    public Slider EnemyHealthBar;

    public void ChangeAvatarHealthUI(int currentHealth)
    {
        EnemyHealthBar.value = currentHealth;
    }

    public void SetEnemyMaxHealthUI(int MaxHealth)
    {
        EnemyHealthBar.maxValue = MaxHealth;
        EnemyHealthBar.value = MaxHealth;

    }
}