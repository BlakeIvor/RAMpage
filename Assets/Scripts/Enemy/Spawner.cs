using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] int foo;
    [SerializeField] List<EnemyObject> bar;

    public void Start()
    {
        spawn();
    }

    public void spawn()
    {
        Instantiate(bar[foo].Enemy) ;
    }
}
