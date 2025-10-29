using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image barImg;

    public void UpdateHealthBar(float maxHealth, float health)
    {
        barImg.fillAmount = health/maxHealth;
    }
}
