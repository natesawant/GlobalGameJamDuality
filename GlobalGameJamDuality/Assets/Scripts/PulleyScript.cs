using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyScript : MonoBehaviour
{
    public Rigidbody platform1, platform2;
    public LineRenderer lineA, lineB;
    public Transform anchorA, anchorB;
    float initialY;

    // Start is called before the first frame update
    void Start()
    {
        initialY = platform1.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //platform2.transform.position = new Vector3(platform2.transform.position.x, initialY - platform1.transform.position.y, platform2.transform.position.z);
        platform2.velocity = new Vector3(0, -platform1.velocity.y, 0);
        lineA.SetPositions(new [] { anchorA.position, platform1.position });
        lineB.SetPositions(new [] { anchorB.position, platform2.position });
    }

    
}
