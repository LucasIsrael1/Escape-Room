using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeOverlay : MonoBehaviour
{
    [SerializeField] float duration;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        yield return Fade(false);
        gameObject.SetActive(false);
    }

    public IEnumerator FadeOut()
    {
        gameObject.SetActive(true);
        yield return Fade(true);
    }

    private IEnumerator Fade(bool isActive)
    {
        float time = 0;
        while (time < duration)
        {
            float alpha = (isActive ? time : duration - time) / duration;
            image.color = image.color.WithAlpha(alpha);
            yield return null;
            time += Time.deltaTime;
        }
    }
}
