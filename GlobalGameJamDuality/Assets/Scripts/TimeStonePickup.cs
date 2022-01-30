using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeStonePickup : MonoBehaviour
{
    public GameObject dimensionScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        dimensionScript.SetActive(true);
        GameObject.FindGameObjectWithTag("Captions").GetComponent<TextMeshProUGUI>().text = "Woah, what was that? What if I try to touch it? [H]";
        this.gameObject.SetActive(false);
    }
}
