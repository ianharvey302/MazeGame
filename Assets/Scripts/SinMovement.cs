using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    [SerializeField] float distMult;
    [SerializeField] float speed;

    Vector3 initial;
    float tracker;

    // Start is called before the first frame update
    void Start()
    {
        initial = transform.position;
        tracker = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tracker >= 360)
            transform.position = initial + new Vector3(Mathf.Sin(tracker * Mathf.PI / 180f), 0, 0) * distMult;
        tracker += speed;
    }
}
