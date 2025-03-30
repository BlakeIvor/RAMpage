using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToNext : MonoBehaviour
{
    [SerializeField] int sceneNumber = 2;
    [SerializeField] int resetHealth = 600;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        Time.timeScale = 1f;
        Destroy(gameObject); 
        GameManager.instance.health -= resetHealth;
        SceneManager.LoadScene(sceneNumber);
    }

}
