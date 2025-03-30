using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private Ability[] m_Abilities;
    [SerializeField] private Image[] images;
    [SerializeField] private Ability[] m_Passives;
    private float[] cooldowns;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cooldowns = new float[4] { 0, 0, 0, 0 };

        //ennact all abilities at start
        foreach(Ability ability in m_Passives)
        {
            ability.Use(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            cooldowns[i] -= Time.deltaTime;
        }
    }

    public void UseAbility(int abilitySlot)
    {
        if (m_Abilities[abilitySlot] != null)
        {
            // end if ability on CD
            if (cooldowns[abilitySlot] > 0)
            {
                return;
            }
            else
            {
                float cooldown = m_Abilities[abilitySlot].Cooldown;
                cooldowns[abilitySlot] = cooldown;
                m_Abilities[abilitySlot].Use(this);
                ;
            }
        }
        else
        {
            Debug.Log($"There is no ability in slot {abilitySlot}.");
        }
    }
}
