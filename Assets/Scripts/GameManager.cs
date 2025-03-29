using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Battering Ram Variables")]
    public float health;
    public float baseDamage;
    public float minMovementSpeed;
    public float maxMovementSpeed;
    public float chargeSpeed;
    public float maxCharge;

    [Header("Shoot Variables")]
    [SerializeField] float clickDamage;
    [SerializeField] float clickCooldown;

    [Header("Economy Variables")]
    [SerializeField] int currentMoney;
    // [SerializeField] float moneyMultiplier

    [SerializeField] bool allowInput;

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int getCurrentMoney()
    {
        return currentMoney;
    }

    public void updateCurrentMoney(int updateAmount)
    {
        currentMoney += updateAmount;
    }

    public void buyUpgrade(int stat, float change)
    {
        switch(stat) {
            case 0:
                health += change;
                break;
            case 1:
                baseDamage += change;
                break;
            case 2:
                minMovementSpeed += change;
                break;
            case 3:
                maxMovementSpeed += change;
                break;
            case 4:
                chargeSpeed += change;
                break;
            case 5:
                maxCharge += change;
                break;
            case 6:
                clickDamage += change;
                break;
            case 7:
                clickCooldown += change;
                break;
        }
    }

    public float CalculateMovingDamage(float moveSpeed)
    {
        if (moveSpeed > 0.5)
        {
            float damage = moveSpeed / maxMovementSpeed * baseDamage;
            return damage;
        }
        return 0.01f;
    }
    
    public void updateAllowInput(bool b)
    {
        allowInput = b;
    }

    public bool getAllowInput()
    {
        return allowInput;
    }

}
