using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;

public class SplashManager : MonoBehaviour
{
    public RawImage splashImage;
    public VideoPlayer videoPlayer;
    public CanvasGroup menuCanvasGroup;
    public float fadeOutTime = 1f;

    private bool canSkip = false;
    private bool fading = false;

    IEnumerator Start()
    {
        splashImage.gameObject.SetActive(true);
        splashImage.color = new Color(1f, 1f, 1f, 1f);
        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.gameObject.SetActive(false);

        // Prepare the video
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing video...");
            yield return null;
        }

        // Clear any old texture data
        RenderTexture.active = videoPlayer.targetTexture;
        GL.Clear(true, true, Color.black);
        RenderTexture.active = null;

        // Assign render texture to RawImage
        splashImage.texture = videoPlayer.targetTexture;

        videoPlayer.Play();
        Debug.Log("Video started!");

        StartCoroutine(SplashSequence());
    }

    void Update()
    {
        if (canSkip && Input.anyKeyDown && !fading)
        {
            Debug.Log("Skip pressed");
            StartCoroutine(FadeOutSplash());
        }
    }

    IEnumerator SplashSequence()
    {
        yield return new WaitForSeconds(1f);
        canSkip = true;

        yield return new WaitForSeconds(2f); // total 3 seconds
        if (!fading)
        {
            StartCoroutine(FadeOutSplash());
        }
    }

    IEnumerator FadeOutSplash()
    {
        fading = true;

        for (float t = 0; t < fadeOutTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeOutTime);
            splashImage.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        // Stop and clean up
        videoPlayer.Stop();
        splashImage.texture = null;
        splashImage.gameObject.SetActive(false);

        // Fade in menu
        menuCanvasGroup.gameObject.SetActive(true);
        for (float t = 0; t < fadeOutTime; t += Time.deltaTime)
        {
            menuCanvasGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeOutTime);
            yield return null;
        }
        menuCanvasGroup.alpha = 1f;
    }
}
