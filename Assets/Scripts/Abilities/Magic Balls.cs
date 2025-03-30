using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(fileName = "MagicBalls", menuName = "Scriptable Objects/MagicBalls")]
public class MagicBalls : Ability
{
    [SerializeField] private float cooldown;
    [SerializeField] private float duration;
    [SerializeField] GameObject ball;
    [SerializeField] private float offset;
    private Transform target;
    
    public override float Cooldown => cooldown;
    public override float Duration => duration;
    public override void Use(MonoBehaviour player)
    {
        target = PlayerMovement.instance.transform;
        GameObject ball1 = Instantiate(ball, PlayerMovement.instance.transform.position + new Vector3(offset,0, 0), Quaternion.identity, target);
        GameObject ball2 = Instantiate(ball, PlayerMovement.instance.transform.position + new Vector3(-offset, 0, 0), Quaternion.identity, target);
        player.StartCoroutine(Finish(player, ball1, ball2));
    }

    public IEnumerator Finish(MonoBehaviour player, GameObject ball1, GameObject ball2)
    {
        yield return new WaitForSeconds(duration);
        Destroy(ball1.gameObject);
        Destroy(ball2.gameObject);

    }

    
}
