using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextManager : MonoBehaviour
{
    private bool mFaded = true;

    public float Duration = 0.5f;

    public void OnClickedInfoText()
    {
        var canvGroup = GetComponent<CanvasGroup>();

        StartCoroutine(canvFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        mFaded = !mFaded;
    }

    public IEnumerator canvFade(CanvasGroup canvGroup, float Start, float End)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(Start, End, counter / Duration);

            yield return null;
        }
    }

    private void Update()
    {
        if (SphereChanger.changing)
        {
            var canvGroup = GetComponent<CanvasGroup>();

            StartCoroutine(canvFade(canvGroup, canvGroup.alpha, 0));

            mFaded = true;
        }
    }

}
