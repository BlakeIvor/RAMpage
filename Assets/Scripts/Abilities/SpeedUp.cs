using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUp", menuName = "Scriptable Objects/SpeedUp")]
public class SpeedUp : Ability
{
    [SerializeField] private float cooldown;
    [SerializeField] private float duration;
    public override float Cooldown => cooldown;
    public override float Duration => duration;
    public float force = 20;
    public override void Use(MonoBehaviour player)
    {
        GameManager.instance.maxMovementSpeed += 3;
        PlayerMovement.instance.rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
        player.StartCoroutine(Finish(player));
    }

    public IEnumerator Finish(MonoBehaviour player)
    {
        yield return new WaitForSeconds(duration);
        GameManager.instance.maxMovementSpeed -= 3;
    }

    
}
