using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeStonePickup : MonoBehaviour
{
    public GameObject dimensionScript;

    private void OnTriggerEnter(Collider other)
    {
        dimensionScript.SetActive(true);
        GameObject.FindGameObjectWithTag("Captions").GetComponent<TextMeshProUGUI>().text = "Woah, what was that? What if I try to touch it? [R]";
        this.gameObject.SetActive(false);
    }
}
