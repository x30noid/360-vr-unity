using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPopupManager : MonoBehaviour
{
    private bool mAudio = true;
    public bool OnEnter = false;
    public string PanoName;
    public Sprite IdleButtonImg;
    public Sprite PressedButtonImg;
    

    public void OnClickedAudioPopup()
    {
        var AudioSrc = GetComponent<AudioSource>();

        ToggleAudio(AudioSrc, mAudio ? true : false);

        mAudio = !mAudio;
    }

    public void ToggleAudio(AudioSource AudioSrc, bool mAudio)
    {
        if(mAudio)
        { 
            GetComponent<Image>().sprite = PressedButtonImg;
            AudioSrc.Play();
        }
        else
        {
            GetComponent<Image>().sprite = IdleButtonImg;
            AudioSrc.Stop();
        }
    }

    private void Update()
    {
        if(SphereChanger.changing)
        {
            if(OnEnter == true && PanoName == SphereChanger.nxtSphere)
            {
                var AudioSrc = GetComponent<AudioSource>();
                ToggleAudio(AudioSrc, true);
                mAudio = false;
            }
            else
            {
                var AudioSrc = GetComponent<AudioSource>();
                ToggleAudio(AudioSrc, false);
                mAudio = true;
            }
            
        }
    }
}
