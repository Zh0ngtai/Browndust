using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlinkImage : MonoBehaviour
{
    public Image pressAnyButtonImage;
    public float blinkInterval = 0.5f;
    public float fadeDuration = 1.0f;
    private bool canPressKey = false;

    void Start()
    {
        StartCoroutine(ShowAndBlinkImage());
        StartCoroutine(EnableKeyPressAfterDelay(4f));
    }

    IEnumerator EnableKeyPressAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canPressKey = true; // 키 입력을 허용합니다.
    }

    void Update()
    {
        // canPressKey가 true일 때만 키 입력을 감지합니다.
        if (canPressKey && Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    IEnumerator ShowAndBlinkImage()
    {

        yield return new WaitForSeconds(4f);

        while (true)
        {

            yield return FadeTo(0.0f, fadeDuration);
            yield return new WaitForSeconds(blinkInterval);


            yield return FadeTo(1.0f, fadeDuration);
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = pressAnyButtonImage.color.a;

        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = pressAnyButtonImage.color;
            newColor.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            pressAnyButtonImage.color = newColor;
            yield return null;
        }

        Color finalColor = pressAnyButtonImage.color;
        finalColor.a = targetAlpha;
        pressAnyButtonImage.color = finalColor;
    }
}
