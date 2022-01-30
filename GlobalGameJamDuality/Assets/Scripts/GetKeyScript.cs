using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetKeyScript : MonoBehaviour
{

    bool isAxisInUse;
    public GameObject door;
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
                door.GetComponent<DoorScript>().hasKey = true;
                GameObject.FindGameObjectWithTag("Captions").GetComponent<TextMeshProUGUI>().text = "This rusty key might work...";
                isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Interact") == 0)
        {
            isAxisInUse = false;
        }
    }
}
