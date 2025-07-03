using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InfoVideoManager : MonoBehaviour
{
    private bool mFaded = true;

    public float Duration = 0.5f;

    public VideoPlayer Video;

    public Sprite PlayIcon;

    public Sprite PauseIcon;

    public GameObject PlayControl;

    public Slider Seekbar;

    public void OnClickedInfoVideo()
    {
        var canvGroup = GetComponent<CanvasGroup>();

        StartCoroutine(canvFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        mFaded = !mFaded;
    }

    public IEnumerator canvFade(CanvasGroup canvGroup, float Start, float End)
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(Start, End, counter / Duration);

            yield return null;
        }

        if (End == 1)
        {
            var VideoSrc = GetComponent<VideoPlayer>();
            VideoSrc.Play();
            PlayControl.GetComponent<Image>().sprite = PauseIcon;
        }
        else
        {
            var VideoSrc = GetComponent<VideoPlayer>();
            VideoSrc.Stop();
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

        Seekbar.value = (float)Video.frame / (float)Video.frameCount;
    }

    public void PlayPauseVideo()
    {
        var VideoSrc = GetComponent<VideoPlayer>();
        
        if (VideoSrc.isPlaying)
        {
            VideoSrc.Pause();
            PlayControl.GetComponent<Image>().sprite = PlayIcon;
        }
        else
        {
            VideoSrc.Play();
            PlayControl.GetComponent<Image>().sprite = PauseIcon;
        }
        
    }

}
