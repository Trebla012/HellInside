using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    //Script para acceder a la barra de vida del player y modificarlar

    public Slider HealthBar;

    public void ChangeAvatarHealthUI(int currentHealth)
    {
        HealthBar.value = currentHealth;
    }

    public void SetMaxHealthUI(int MaxHealth)
    {
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = MaxHealth;

    }
}