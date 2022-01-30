using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorScript : MonoBehaviour
{

    public GameObject door;
    public bool hasKey;
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
        if (Input.GetAxisRaw("Interact") == 1 && hasKey)
        {
            if (isAxisInUse == false)
            {
                GameObject.FindGameObjectWithTag("Captions").GetComponent<TextMeshProUGUI>().text = "Ka ching! That key worked";
                door.SetActive(false);
                isAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw("Interact") == 1 && !hasKey)
        {
            
        }

        if (Input.GetAxisRaw("Interact") == 0)
        {
            isAxisInUse = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Captions").GetComponent<TextMeshProUGUI>().text = "Looks like I need a key";
    }
}
