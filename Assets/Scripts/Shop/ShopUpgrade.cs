using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUpgrade : MonoBehaviour
{
    public enum UpgradeType {
        Body,
        Front,
        Wheels,
        Charge
    };

    [Header("Upgrade Infomation")]
    public int level;
    public int[] upgradeCosts;
    public float[] upgradeChanges;
    public UpgradeType upgradeType;

    // [Header("UI Stuff")]
    // [SerializeField] TextMeshProUGUI tierLabel;
    // [SerializeField] TextMeshProUGUI costText;
    // [SerializeField] Image currentUpgrade;
    // [SerializeField] Sprite[] upgradeImages;
    // [SerializeField] Button nextButton;
    // [SerializeField] Button previousButton;

    // void Start()
    // {
    //     UpdateUI();
    // }

    // public void ShowNextTier()
    // {
    //     if (currentIndex < upgradeTiers.Length - 1)
    //     {
    //         currentIndex++;
    //         UpdateUI();
    //     }
    // }

    // public void ShowPreviousTier()
    // {
    //     if (currentIndex > 0)
    //     {
    //         currentIndex--;
    //         UpdateUI();
    //     }
    // }

    // private void UpdateUI()
    // {
    //     tierLabel.text = $"TIER {level + 1}";

    //     previousButton.interactable = level > 0;
    //     nextButton.interactable = currentIndex < upgradeTiers.Length - 1;

    // }
}