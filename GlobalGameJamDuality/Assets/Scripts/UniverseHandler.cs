using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class UniverseHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] MWorldObjects;
    public GameObject[] NWorldObjects;

    PostProcessVolume vol;
    ColorGrading colorGrade;

    bool isNormal = true;
    void Start()
    {
        vol = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessVolume>();
        colorGrade = vol.profile.GetSetting<ColorGrading>();
        Invoke("CountObjects", 2.0f);
        Refresh();
    }

    public void CountObjects(){
       
            MWorldObjects = FindInActiveObjectsByTag("MWorld");
            //Debug.Log(GameObject.FindGameObjectsWithTag("MWorld").Length);
            NWorldObjects = FindInActiveObjectsByTag("NWorld");
            
        
    }
    public void Switch(){
        if (isNormal){
            SwitchToMirror();
        }else{
            SwitchToNormal();
        }
    }

    public void Refresh(){
       if (isNormal){
            SwitchToNormal();
        }else{
            SwitchToMirror();
        } 
    }
    public void SwitchToMirror(){
        colorGrade.saturation.value = -100;
        foreach (GameObject item in NWorldObjects)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in MWorldObjects){
            item.SetActive(true);
        }
        isNormal = false;
    }
    public void SwitchToNormal(){
        colorGrade.saturation.value = 0;
        foreach (GameObject item in NWorldObjects)
        {
            item.SetActive(true);
        }
        foreach (GameObject item in MWorldObjects){
            item.SetActive(false);
        }
        isNormal = true;
    }
    // Update is called once per frame
    GameObject[] FindInActiveObjectsByTag(string tag){
    List<GameObject> validTransforms = new List<GameObject>();
    Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    for (int i = 0; i < objs.Length; i++)
    {
        if (objs[i].hideFlags == HideFlags.None)
        {
            if (objs[i].gameObject.CompareTag(tag))
            {
                validTransforms.Add(objs[i].gameObject);
            }
        }
    }
    return validTransforms.ToArray();
    }
}
