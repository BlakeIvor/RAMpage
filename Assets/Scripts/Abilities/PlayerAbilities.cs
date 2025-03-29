using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private Ability[] m_Abilities;
    [SerializeField] private Image[] images;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseAbility(int abilitySlot)
    {
        try
        {
            
            m_Abilities[abilitySlot].Use(this);
        }
        catch {
            Debug.Log($"There is no ability in slot {abilitySlot}.");
                };
    }
}
