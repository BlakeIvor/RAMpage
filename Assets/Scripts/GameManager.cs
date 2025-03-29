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

    public AbilitiesStruct[] activeAbilities;

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
                maxMovementSpeed += change;
                break;
            case 3:
                maxCharge += change;
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
