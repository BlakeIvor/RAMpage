using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSwitcher : MonoBehaviour
{
    [Header("Upgrade Tiers")]
    public Sprite[] upgradeTiers;
    public int[] tierCosts;
    public float[] statIncrease; // How much each tier increases the stat
    private bool[] isPurchased;

    [Header("UI References")]
    public Image tierImage;
    public TextMeshProUGUI tierLabel;
    public TextMeshProUGUI costText;
    public Image lockIcon;
    public Button nextButton;
    public Button previousButton;
    public Button purchaseButton;
    public Image purchaseButtonImage;
    public Sprite purchaseSprite;
    public Sprite equippedSprite;

    [Header("Upgrade Info")]
    public UpgradeType upgradeType; // Body, Wheels, Front
    public int statIndex; // 0 = Health, 1 = Damage, 2 = Speed, 3 = Charge

    private GameManager gameManager;
    private int currentIndex = 0;

    void Start()
    {
        gameManager = GameManager.instance;
        isPurchased = new bool[upgradeTiers.Length];
        UpdateUI();
    }

    public void ShowNextTier()
    {
        if (currentIndex < upgradeTiers.Length - 1)
        {
            currentIndex++;
            UpdateUI();
        }
    }

    public void ShowPreviousTier()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateUI();
        }
    }

    public void PurchaseCurrentTier()
    {
        int cost = tierCosts[currentIndex];
        if (gameManager.getCurrentMoney() >= cost && !isPurchased[currentIndex])
        {
            gameManager.updateCurrentMoney(-cost);
            isPurchased[currentIndex] = true;

            // Apply the stat boost
            float increase = statIncrease[currentIndex];
            gameManager.buyUpgrade(statIndex, increase);

            // Set the selected level for prefab spawning
            switch (upgradeType)
        {
            case UpgradeType.Body:
                gameManager.bodyLevel = currentIndex;
                break;
            case UpgradeType.Wheels:
                gameManager.wheelLevel = currentIndex;
                break;
            case UpgradeType.Front:
                gameManager.frontLevel = currentIndex; 
                break;
        }


            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough currency or already purchased.");
        }
    }
    
    void UpdateUI()
    {
        tierImage.sprite = upgradeTiers[currentIndex];
        tierLabel.text = $"TIER {currentIndex + 1}";

        previousButton.interactable = currentIndex > 0;
        nextButton.interactable = currentIndex < upgradeTiers.Length - 1;

        bool purchased = isPurchased[currentIndex];

        if (purchased)
        {
            purchaseButton.interactable = false;
            purchaseButtonImage.sprite = equippedSprite;
            lockIcon.enabled = false;
            costText.text = "Owned";
        }
        else
        {
            purchaseButton.interactable = gameManager.getCurrentMoney() >= tierCosts[currentIndex];
            purchaseButtonImage.sprite = purchaseSprite;
            lockIcon.enabled = true;
            costText.text = $"${tierCosts[currentIndex]}";
        }
      
    }
}

public enum UpgradeType
{
    Body,
    Wheels,
    Front 
}