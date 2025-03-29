using UnityEngine;
using UnityEngine.UI;

public class ScatterButtonsWall : MonoBehaviour
{
    public Button[] uiButtons;  
    [SerializeField] float scatterForce = 500f;  
    [SerializeField] float scatterRange = 300f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Scatter buttons when the object hits a BoxCollider2D
        if (collider.gameObject.CompareTag("Player"))
        {
            ScatterUIElements();
        }
    }

    private void ScatterUIElements()
    {
        foreach (Button button in uiButtons)
        {
            RectTransform rectTransform = button.GetComponent<RectTransform>();

            Vector2 randomDirection = Random.insideUnitCircle.normalized;

            Vector2 newPosition = rectTransform.anchoredPosition + randomDirection * scatterRange;

            rectTransform.anchoredPosition = newPosition;
        }
    }
}