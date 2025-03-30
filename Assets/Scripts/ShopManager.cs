using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public List<AbilitiesStruct> shopAbilities;
    public AbilitySlot[]  abilitySlots;

    public static ShopManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void buyUpgrade(ShopUpgrade upgrade)
    {
        if (upgrade.level != upgrade.upgradeCosts.Length){
            if (GameManager.instance.getCurrentMoney() >= upgrade.upgradeCosts[upgrade.level])
            {
                switch(upgrade.upgradeType) {
                    case ShopUpgrade.UpgradeType.Body:
                        GameManager.instance.buyUpgrade(0, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.Front:
                        GameManager.instance.buyUpgrade(1, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.Wheels:
                        GameManager.instance.buyUpgrade(2, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.Charge:
                        GameManager.instance.buyUpgrade(3, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                }
            }
        }
    }

    public void buyAbility(AbilitiesStruct ability)
    {
        if (!ability.isBought && GameManager.instance.getCurrentMoney() >= ability.cost)
        {
            ability.isBought = true;
        }
        else if(ability.isBought)
        {
            Debug.Log("isBought");
        }
        else if (GameManager.instance.getCurrentMoney() < ability.cost)
        {
            Debug.Log("Too Broke");
        }
    }

    public bool IsAbilityBought(int abilityIndex)
    {
        return shopAbilities[abilityIndex].isBought;
    }

}
