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

    // This is a totally legit way to accomplish the task. The "hacky" way was to use moving triggers, 
    // but that is definitely NOT the best way. 

    // Just for personal edification, you might want to look into accomplishing this same task via a combination
    // of a few patterns:
    //
    // 1. Having the Move and Rotate methods in Coroutines or Async methods (in this case these are functionally the same,
    // but it would be good practice to try implementing each)
    //
    // 2. Having the Move and Rotate methods called via an Event Listener instead of a Manager class like MultiActivator,
    // as well as calling "to anybody listening" that they have completed.
    // 
    // There are a couple of different ways to implement an Event Listener, but my two favorites are these:
    // a. Pure C# Events
    // b. The ScriptableObject GameEvent system as popularized by Ryan Hipple in this famous 2017 video: https://www.youtube.com/watch?v=raQ3iHhE_Kk
    // 
    // The benefit to eliminating or minimizing the Manager is that you gain flexibility. This becomes
    // VERY useful when you need multiple GameObjects to respond to cues. 
    //
    // The benefit to using "Pure C# Events" is speed and ease of refactoring. Some people also just prefer
    // to "keep it in code" as their brains work that way. 
    // 
    // The benefit to using ScriptableObject GameEvents is that it becomes easier to respond to events across 
    // layered Scenes as SO are Assets therefore not Scene-dependent. Some people also just prefer the
    // "Lego-like" modularity of drag-and-drop Assets instead of pure code. This becomes especially important
    // if you are working with Designers and want them to have flexibilty in testing events on their own. 

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
                if (cycle % 2 == 0) // Nice use of modulus
                    activators[at].SendMessage("Activate"); // See my message in MovementActivator about SendMessage...
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
