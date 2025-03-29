using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public void buyUpgrade(ShopUpgrade upgrade)
    {
        if (upgrade.level != upgrade.upgradeCosts.Length){
            if (GameManager.instance.getCurrentMoney() >= upgrade.upgradeCosts[upgrade.level])
            {
                switch(upgrade.upgradeType) {
                    case ShopUpgrade.UpgradeType.Health:
                        GameManager.instance.buyUpgrade(0, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.BaseDamage:
                        GameManager.instance.buyUpgrade(1, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.MinMoveSpeed:
                        GameManager.instance.buyUpgrade(2, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.MaxMoveSpeed:
                        GameManager.instance.buyUpgrade(3, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.ChargeSpeed:
                        GameManager.instance.buyUpgrade(4, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.MaxCharge:
                        GameManager.instance.buyUpgrade(5, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.ClickDamage:
                        GameManager.instance.buyUpgrade(6, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                    case ShopUpgrade.UpgradeType.ClickCooldown:
                        GameManager.instance.buyUpgrade(7, upgrade.upgradeChanges[upgrade.level]);
                        upgrade.level++;
                        break;
                }
            }
        }
    }
}
