using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject shopGroupPrefab; // Assign ShopGroup prefab in Inspector
    GameObject currentShopUI;
    bool hasSpawnedShopUI = false;

    [Header("Upgrade Levels")]
    public int bodyLevel;
    public int wheelLevel;
    public int frontLevel;

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
        switch (stat)
        {
            case 0: health += change; break;
            case 1: baseDamage += change; break;
            case 2: maxMovementSpeed += change; break;
            case 3: maxCharge += change; break;
        }
    }

    public float CalculateMovingDamage(float moveSpeed)
    {
        return moveSpeed > 0.5f ? moveSpeed * baseDamage : 0.01f;
    }

    public void updateAllowInput(bool b)
    {
        allowInput = b;
    }

    public bool getAllowInput()
    {
        return allowInput;
    }

    void Update()
    {
        if (health <= 0 && !hasSpawnedShopUI)
        {
            hasSpawnedShopUI = true;
            SpawnShopUI();
        }
    }

    void SpawnShopUI()
    {
        Time.timeScale = 0f;

        currentShopUI = Instantiate(shopGroupPrefab);

        Transform shopMenu = currentShopUI.transform.Find("Canvas/ShopMenu");
        if (shopMenu == null)
        {
            Debug.LogError("ShopMenu not found inside ShopGroup prefab!");
            return;
        }

        CanvasGroup cg = shopMenu.GetComponent<CanvasGroup>();
        if (cg == null)
        {
            cg = shopMenu.gameObject.AddComponent<CanvasGroup>();
        }

        cg.alpha = 0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;

        StartCoroutine(FadeInCanvas(cg, 0.2f));
    }

    private System.Collections.IEnumerator FadeInCanvas(CanvasGroup cg, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            cg.alpha = Mathf.Lerp(0f, 1f, t / duration);
            yield return null;
        }

        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
}
