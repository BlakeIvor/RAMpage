using UnityEngine;

[CreateAssetMenu(fileName = "RamObject", menuName = "Scriptable Objects/RamObject")]
public class RamObject : ScriptableObject
{
    public string title;
    public GameObject objectPrefab;
}
