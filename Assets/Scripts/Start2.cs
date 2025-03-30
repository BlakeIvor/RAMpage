using System.Collections.Generic;
using UnityEngine;

public class Start2 : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] int level;
    [SerializeField] List<RamObject> rams;
    Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
        playerTransform = GameObject.Find("PlayerBase").transform;
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        Instantiate(rams[level].objectPrefab, playerTransform);
    }
}
