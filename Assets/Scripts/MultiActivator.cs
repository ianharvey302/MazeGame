using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiActivator : MonoBehaviour
{
    [SerializeField] GameObject[] activators;
    [SerializeField] int[] durations;
    [SerializeField] int maxCycles;
    [SerializeField] Material[] colors;
    [SerializeField] Material defaultColor;
    [SerializeField] GameObject colorIndicator;

    public int at;
    public int cycle;
    public int duration;
    public bool activated;

    Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        ren = colorIndicator.GetComponent<Renderer>();
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && cycle < maxCycles*2)
        {
            if (duration == 0) {
                if (cycle % 2 == 0)
                    activators[at].SendMessage("Activate");
                else
                    activators[at].SendMessage("Deactivate");
                ren.material = colors[at];
            }
            if (duration == durations[at])
            {
                at++;
                if (at == activators.Length)
                {
                    cycle++;
                    at = 0;
                }
                duration = -1;
            }
            duration++;
        }
    }

    public void Activate()
    {
        activated = true;
    }

    public void Deactivate()
    {
        at = 0;
        cycle = 0;
        duration = 0;
        activated = false;
        ren.material = defaultColor;
        for(int i = 0; i < activators.Length; i++)
        {
            activators[i].SendMessage("Deactivate");
        }
    }
}
