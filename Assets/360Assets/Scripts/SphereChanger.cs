using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChanger : MonoBehaviour {



    //This object should be called 'Fader' and placed over the camera
    public GameObject m_Fader;
    Animator faderAnimator;

    //This ensures that we don't mash to change spheres
    public static bool changing = false;
    public static bool setDirection = false;
    public static string nxtSphere;


    void Awake()
    {

        //Check if we found something
        if (m_Fader == null)
            Debug.LogWarning("No Fader object found on camera.");

    }

    void Start()
    {
        faderAnimator = m_Fader.GetComponent<Animator>();
    }

    public void goToSphere(Transform nextSphere)
    {
        changing = true;
        setDirection = false;
        faderAnimator.SetTrigger("startFading");
        StartCoroutine(changeSphere(nextSphere));
        nxtSphere = nextSphere.name.ToString();
    }

    //public void setToDirection(float direction)
    //{
    //    StartCoroutine(setdirection(direction));
    //}

    //IEnumerator setdirection(float dir)
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, dir, Camera.main.transform.eulerAngles.z);

    //}

    IEnumerator changeSphere(Transform nextSphere)
    {
        yield return new WaitForSeconds(1.0f);
        changing = false;
        setDirection = true;
        Camera.main.transform.parent.position = nextSphere.position;

    }
}
