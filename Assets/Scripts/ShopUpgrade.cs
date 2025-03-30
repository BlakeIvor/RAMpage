using UnityEngine;

public class ShopUpgrade : MonoBehaviour
{
    public enum UpgradeType {
        Body,
        Front,
        Wheels,
        Charge
    };

    public int level;
    public int[] upgradeCosts;
    public float[] upgradeChanges;
    public UpgradeType upgradeType;
}
