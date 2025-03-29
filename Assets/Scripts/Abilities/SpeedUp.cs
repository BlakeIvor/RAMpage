using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUp", menuName = "Scriptable Objects/SpeedUp")]
public class SpeedUp : Ability
{
    public override void Use(MonoBehaviour player)
    {
        GameManager.instance.maxMovementSpeed += 300;
        PlayerMovement.instance.rb.AddForceX(300, ForceMode2D.Impulse);
    }
}
