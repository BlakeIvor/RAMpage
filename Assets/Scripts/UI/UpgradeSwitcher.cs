using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeSwitcher : MonoBehaviour
{
    public int[] tierCosts;         
    public TextMeshProUGUI costText;        
    public int playerCurrency = 10000;      // THIS IS A PLACEHOLDER replace later with actual currency.
    public Image lockIcon;                  
    public Sprite[] upgradeTiers;
    public Image tierImage;
    public TextMeshProUGUI tierLabel;
    public Button nextButton;
    public Button previousButton;

    public Button purchaseButton;
    public Image purchaseButtonImage;         
    public Sprite purchaseSprite;             
    public Sprite equippedSprite;             

    private int currentIndex = 0;
    private bool[] isPurchased;

    void Start()
    {
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
        if (playerCurrency >= cost && !isPurchased[currentIndex])
        {
            playerCurrency -= cost;
            isPurchased[currentIndex] = true;
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
            purchaseButton.interactable = playerCurrency >= tierCosts[currentIndex];
            purchaseButtonImage.sprite = purchaseSprite;
            lockIcon.enabled = true;

            
            costText.text = $"${tierCosts[currentIndex]}";
        }
    }


}
