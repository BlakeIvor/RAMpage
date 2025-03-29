using UnityEngine;

public class ShopUpgrade : MonoBehaviour
{
    public enum UpgradeType {
        Health,
        BaseDamage,
        MinMoveSpeed,
        MaxMoveSpeed,
        ChargeSpeed,
        MaxCharge,
        ClickDamage,
        ClickCooldown
    };

    public int level;
    public int[] upgradeCosts;
    public float[] upgradeChanges;
    public UpgradeType upgradeType;
}
