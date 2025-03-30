using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret", menuName = "Scriptable Objects/Turret")]
public class Turret : Ability
{
    [SerializeField] private float cooldown;
    [SerializeField] private float duration;
    [SerializeField] private GameObject turret;
    public override float Cooldown => cooldown;
    public override float Duration => duration;

    public override void Use(MonoBehaviour player)
    {
        Transform spawn = GameObject.Find("PassivePosition").transform;
        GameObject newTurret = Instantiate(turret, spawn.position, Quaternion.identity, spawn);
        spawn.name = "FILLED";
    }
}
