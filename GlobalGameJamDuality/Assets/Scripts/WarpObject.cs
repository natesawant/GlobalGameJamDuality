using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public UniverseHandler objects;
    GameObject Ground;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
 {
     if (Input.GetMouseButtonDown(0))
     {
         Debug.Log("Mouse is down");
         
         RaycastHit hitInfo = new RaycastHit();
         bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
         if (hit) 
         {
             Debug.Log("Hit " + hitInfo.transform.gameObject.name);
             if (hitInfo.transform.gameObject.tag == "NWorld")
             {
                 Debug.Log ("normal object");
                 hitInfo.transform.gameObject.tag = "MWorld";
                 objects.CountObjects();
                 objects.Refresh();
                 //turn it into a mirror object

             } else if(hitInfo.transform.gameObject.tag == "MWorld") {
                 Debug.Log ("mirror object");
                 hitInfo.transform.gameObject.tag = "NWorld";
                 objects.CountObjects();
                 objects.Refresh();
                 //turn it into a normal object

             } else {
                 Debug.Log ("both/neither");
             }
         } else {
             //Debug.Log("No hit");
         }
         //Debug.Log("Mouse is down");
     } 
 }
}
