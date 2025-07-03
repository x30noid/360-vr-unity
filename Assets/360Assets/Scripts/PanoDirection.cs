using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PanoDir
{
    public string PanoName;
    public float DirectionValue;
}

public class PanoDirection : MonoBehaviour
{
    public PanoDir[] PanoramaDirections;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (SphereChanger.setDirection)
        {

            for(int i = 0; i < PanoramaDirections.Length; i++ )
            {
                if (PanoramaDirections[i].PanoName == SphereChanger.nxtSphere)
                {

                    Debug.Log("Loaded : " + PanoramaDirections[i].PanoName);
                    SphereChanger.setDirection = false;
                    GameObject Pano = GameObject.Find(PanoramaDirections[i].PanoName);
                    float DirToChange = Camera.main.transform.eulerAngles.y - PanoramaDirections[i].DirectionValue;
                    Debug.Log("Camera Value : " + Camera.main.transform.eulerAngles.y);
                    Debug.Log(DirToChange);
                    Pano.transform.eulerAngles = new Vector3(Pano.transform.eulerAngles.x, DirToChange, Pano.transform.eulerAngles.z);

                }
            } 
            
        }
        
    }
}
