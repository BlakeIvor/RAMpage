using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    [SerializeField] Image speedBar;
    [SerializeField] Image chargeBar;

    void Update()
    {
        speedBar.fillAmount = PlayerMovement.instance.rb.linearVelocity.x / 30;
        chargeBar.fillAmount = (PlayerMovement.instance.rb.linearVelocity.x * -1) / 30;
    }
}
