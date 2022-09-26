using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementActivator : MonoBehaviour
{
    [SerializeField] List<GameObject> toActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        foreach (GameObject o in toActivate)
        {
            o.SendMessage("Activate"); // SendMessage is... fine. My personal preference
            // is to avoid it because as a project grows it becomes difficult to refactor any 
            // string-based Method invoker. 
            // 
            // My preferred alternative would be to implement an Interface on each Class
            // that can activate a device, something like IActivatable that ensures the Activate() method is present.
            //
            // By using an Interface you can easily refactor, but you're not bound to Class
            // hierarchies to guarantee the presence of a method. 
        }
    }

    void OnTriggerExit(Collider collision)
    {
        foreach (GameObject o in toActivate)
        {
            o.SendMessage("Deactivate");
        }
    }
}
