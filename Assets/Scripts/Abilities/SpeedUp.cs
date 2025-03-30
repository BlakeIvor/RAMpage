using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUp", menuName = "Scriptable Objects/SpeedUp")]
public class SpeedUp : Ability
{
    [SerializeField] private float cooldown;
    [SerializeField] private float duration;
    [SerializeField] private float maxChange;
    [SerializeField] private float force;
    public override float Cooldown => cooldown;
    public override float Duration => duration;
    public override void Use(MonoBehaviour player)
    {
        GameManager.instance.maxMovementSpeed += maxChange;
        PlayerMovement.instance.rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
        player.StartCoroutine(Finish(player));
    }

    public IEnumerator Finish(MonoBehaviour player)
    {
        yield return new WaitForSeconds(duration);
        GameManager.instance.maxMovementSpeed -= maxChange;
    }

    
}
