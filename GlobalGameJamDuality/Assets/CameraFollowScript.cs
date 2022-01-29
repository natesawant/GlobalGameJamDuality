using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject cam;
    public float lerpConstant;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, this.gameObject.transform.position + offset, lerpConstant);
        cam.transform.LookAt(this.gameObject.transform);
    }
}
