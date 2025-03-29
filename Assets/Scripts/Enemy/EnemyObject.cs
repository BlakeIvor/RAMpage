using UnityEngine;

[CreateAssetMenu(fileName = "EnemyObject", menuName = "Scriptable Objects/EnemyObject")]
public class EnemyObject : ScriptableObject
{
    public float health;
    public int reward;
    public float damage;
    public Sprite enemysprite;
    public GameObject Enemy;
}
