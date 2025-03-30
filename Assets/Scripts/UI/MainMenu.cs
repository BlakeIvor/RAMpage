using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int sceneToLoad;
    public CanvasGroup creditsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad); 
    }

    public void ShowCredits()
    {
        StartCoroutine(FadeInPanel(creditsPanel));
    }

    public void HideCredits()
    {
        StartCoroutine(FadeOutPanel(creditsPanel));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator FadeInPanel(CanvasGroup panel)
    {
        panel.gameObject.SetActive(true); 
        panel.blocksRaycasts = true;
        panel.interactable = true;

        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            panel.alpha = Mathf.Lerp(0, 1, t / 1f);
            yield return null;
        }
        panel.alpha = 1;
    }

    IEnumerator FadeOutPanel(CanvasGroup panel)
    {
        panel.blocksRaycasts = false;
        panel.interactable = false;

        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            panel.alpha = Mathf.Lerp(1, 0, t / 1f);
            yield return null;
        }
        panel.alpha = 0;
        panel.gameObject.SetActive(false);
    }


IEnumerator FadeUIElement(CanvasGroup cg, bool enableInteraction = false)
{
    if (cg == null) yield break;

    cg.gameObject.SetActive(true);

    float t = 0f;
    while (t < 1f)
    {
        t += Time.deltaTime;
        cg.alpha = Mathf.Lerp(0, 1, t / 1f);
        yield return null;
    }

    cg.alpha = 1f;

    if (enableInteraction)
    {
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
}

}
