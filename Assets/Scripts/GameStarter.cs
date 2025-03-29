using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStarter: MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] int level;
    [SerializeField] List<RamObject> rams;
    Transform playerTransform;

    [Header("Starting Sequence")]
    Rigidbody2D rb;
    [SerializeField] BoxCollider2D enableInputCollider;
    

    private void Awake()
    {
        gameManager = GameManager.instance;
        playerTransform = GameObject.Find("PlayerBase").transform;
        GameObject go = Instantiate(rams[level].objectPrefab, playerTransform);
        rb = go.GetComponentInParent<Rigidbody2D>();
        // StartGame(); //PLEASE GOD REMOVE THIS LATER. SHOULD BE CALLED BY BUTTON
    }
    public void StartGame()
    {
        StartCoroutine(IntroSequence(1, 1));
        // Instantiate(rams[level].objectPrefab, playerTransform);
    }

    private void Update()
    {
        
    }

    IEnumerator IntroSequence(float backupTime, float forwardTime)
    {
        rb.linearVelocity = Vector2.left * 5;
        yield return new WaitForSeconds(backupTime);

        rb.linearVelocity = Vector2.right * 10;
        yield return new WaitForSeconds(forwardTime);
    }
}

