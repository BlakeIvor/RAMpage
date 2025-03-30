using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBar;
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = GameManager.instance.getCurrentHealth() / GameManager.instance.getMaxHealth();
    }
}
