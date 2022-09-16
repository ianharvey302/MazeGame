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
            o.SendMessage("Activate");
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
