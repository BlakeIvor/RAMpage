using System.Collections.Generic;
using UnityEngine;

public class Start2 : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] int ramLevel, wheelLevel, weaponsLevel;
    [SerializeField] List<GameObject> rams;
    [SerializeField] List<GameObject> wheels;
    [SerializeField] List<GameObject> fronts;


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
        Instantiate(rams[ramLevel].objectPrefab, playerTransform);
        Instantiate(wheels[wheelLevel].objectPrefab, playerTransform);
        //Instantiate(weapons[weaponsLevel].objectPrefab, playerTransform);
        PlayerBaseController controller = playerTransform.GetComponent<PlayerBaseController>();

        GameObject ram = Instantiate(rams[gameManager.bodyLevel], controller.ramSlot);
        GameObject wheel = Instantiate(wheels[gameManager.wheelLevel], controller.wheelSlot);
        GameObject front = Instantiate(fronts[gameManager.frontLevel], controller.frontSlot);

        controller.SetParts(ram, wheel, front);
    }


}
