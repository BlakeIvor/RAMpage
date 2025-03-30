using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  

public class AbilitySlot : MonoBehaviour
{
    public bool isUnlocked = false;       
    public Image abilityIcon;             
    public int assignedAbilityIndex = -1; 
    private bool isSlotSelected = false; 

    public void OnSlotClicked()  
    {
        if (isUnlocked)
        {
            isSlotSelected = true;
            Debug.Log("Slot selected! Now select an ability.");
        }
        else
        {
            Debug.Log("This slot is locked!");
        }
    }

    private void Update()
    {
        if (isSlotSelected)
        {
            GameObject selectedObject = EventSystem.current.currentSelectedGameObject; 

            if (selectedObject != null && selectedObject.CompareTag("AbilityButton"))
            {
                AbilitiesStruct abilityButton = selectedObject.GetComponent<AbilitiesStruct>();
                int abilityIndex = abilityButton.id;

                if (ShopManager.instance.IsAbilityBought(abilityIndex))
                {
                    AssignAbilityToSlot(abilityIndex);  
                    isSlotSelected = false;  
                }
            }

            if (Input.GetButtonDown("Cancel"))
            {
                Debug.Log("Selection canceled.");
                isSlotSelected = false;
            }
        }
    }

    private void AssignAbilityToSlot(int abilityIndex)
    {
        assignedAbilityIndex = abilityIndex;
        abilityIcon.sprite = ShopManager.instance.shopAbilities[abilityIndex].image;
        Debug.Log("Assigned ability: " + ShopManager.instance.shopAbilities[abilityIndex].name);
    }
}

