using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToNext : MonoBehaviour
{
    int resetHealth = 600;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int scene)
    {
        SceneManager.LoadScene(scene);
        GameManager.instance.health = resetHealth;
    }
}
