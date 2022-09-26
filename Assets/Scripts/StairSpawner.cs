using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSpawner : MonoBehaviour
{
    [SerializeField] GameObject replicate;
    [SerializeField] int maxRep;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 gap;
    [SerializeField] Material[] colors;

    int count;
    int delay;
    bool activated;
    
    // Nicely done here with both the spawner and the SinMovement of the stairs. 

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        delay = 0;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(count < maxRep && activated && delay == 0)
        {
            Vector3 pos = transform.position + offset + (gap * count);
            GameObject current = Instantiate(replicate, pos, replicate.transform.rotation);
            current.GetComponent<Renderer>().material = colors[count % colors.Length];
            count++;
            delay = 20;
        }
        if(delay > 0)
        {
            delay--;
        }
    }

    void Activate()
    {
        activated = true;
    }

    void Deactivate() { }
}
