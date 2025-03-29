using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScatterButtonsWall : MonoBehaviour
{
    public Button[] uiButtons;  
    [SerializeField] float scatterSpeed = 1f;  
    [SerializeField] float scatterRange = 600f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Scatter buttons when the object hits a BoxCollider2D
        if (collider.gameObject.CompareTag("Player"))
        {
            foreach (Button button in uiButtons)
            {
                StartCoroutine(ScatterButton(button.GetComponent<RectTransform>()));
            }
        }
    }

    IEnumerator ScatterButton(RectTransform rectTransform)
    {
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 randomDirection = Random.insideUnitCircle.normalized * scatterRange; 

        float elapsedTime = 0f;
        float duration = 0.5f; 

        while (elapsedTime < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, startPosition + randomDirection, elapsedTime / duration);
            elapsedTime += Time.deltaTime * scatterSpeed; 
            yield return null;
        }

        rectTransform.anchoredPosition = startPosition + randomDirection;

        Destroy(rectTransform.gameObject);
    }
}