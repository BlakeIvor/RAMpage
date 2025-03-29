using UnityEngine;
using System.Collections.Generic;
public class GameStarter: MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] int level;
    [SerializeField] List<RamObject> rams;
    Transform playerTransform;

    private void Awake()
    {
        gameManager = GameManager.instance;
        playerTransform = GameObject.Find("PlayerBase").transform;
        StartGame(); //PLEASE GOD REMOVE THIS LATER. SHOULD BE CALLED BY BUTTON
    }
    public void StartGame()
    {
        Instantiate(rams[level].objectPrefab, playerTransform);
    }

    private void Update()
    {
        
    }
}
