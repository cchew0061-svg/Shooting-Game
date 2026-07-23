using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{

    public Image fadeImage;
    public float fadeDuration = 2.0f;

	//starts the coroutine below
    public void StartFade()
    {
		StartCoroutine(FadeOut());
    }

	//fades the background screen into view
    private IEnumerator FadeOut()
    {
		float timer = 0f;
		Color startColor = fadeImage.color;
		Color endColor = new Color(0f, 0f, 0f, 1f);
		while(timer < fadeDuration)
		{
			fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
			timer += Time.deltaTime;
			yield return null;
		}
        fadeImage.color = endColor;
    }
}

