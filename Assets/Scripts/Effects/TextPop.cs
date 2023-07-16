using System.Collections;
using UnityEngine;
using TMPro;

public class TextPop : MonoBehaviour
{
    public TextMeshPro textObject;
    public float popDuration = 0.5f;
    public float popScale = 1.2f;

    private Vector3 originalScale;

    void Start()
    {
        // Store the original scale of the text object
        originalScale = textObject.transform.localScale;

        // Hide the text object initially
        textObject.gameObject.SetActive(false);
    }

    public void TriggerPop(int score)
    {
        // Set the text message
        textObject.text = score.ToString();

        // Start the popping animation coroutine
        StartCoroutine(PopAnimation());
    }

    private IEnumerator PopAnimation()
    {
        // Show the text object
        textObject.gameObject.SetActive(true);

        // Scale up the text gradually
        float timer = 0f;
        while (timer < popDuration)
        {
            float scale = Mathf.Lerp(originalScale.x, originalScale.x * popScale, timer / popDuration);
            textObject.transform.localScale = new Vector3(scale, scale, scale);
            timer += Time.deltaTime;
            yield return null;
        }

        // Scale down the text gradually
        /*timer = 0f;
        while (timer < popDuration)
        {
            float scale = Mathf.Lerp(originalScale.x * popScale, originalScale.x, timer / popDuration);
            textObject.transform.localScale = new Vector3(scale, scale, scale);
            timer += Time.deltaTime;
            yield return null;
        }*/

        // Set the text scale to its original size
        textObject.transform.localScale = originalScale;

        // Hide the text object
        textObject.gameObject.SetActive(false);
    }
}
