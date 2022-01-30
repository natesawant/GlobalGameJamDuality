using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LadderScript : MonoBehaviour
{
    public GameObject otherPoint;
    bool isAxisInUse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {


        if (Input.GetAxisRaw("Interact") == 1)
        {
            if (isAxisInUse == false)
            {
                other.transform.position = otherPoint.transform.position;
                isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Interact") == 0)
        {
            isAxisInUse = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Captions").GetComponent<TextMeshProUGUI>().text = "I might be able to use the ladder...";
    }
}
