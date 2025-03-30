using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Scriptable Objects/Ability")]
public abstract class Ability : ScriptableObject, IAbility
{
    public abstract float Cooldown {  get; }
    public abstract float Duration { get; }
    public abstract void Use(MonoBehaviour player);
}
