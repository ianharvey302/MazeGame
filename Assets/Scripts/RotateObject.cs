using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int maxRotation;

    Vector3 rotationDirection;
    int rotationAmount;
    bool activated;

    // Start is called before the first frame update
    void Start()
    {
        rotationDirection = new Vector3(0, 1f, 0);
        rotationAmount = 0;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && rotationAmount < maxRotation)
        {
            gameObject.transform.Rotate(rotationDirection * moveSpeed);
            rotationAmount++;
        }
        else if (!activated && rotationAmount > 0)
        {
            gameObject.transform.Rotate(-rotationDirection * moveSpeed);
            rotationAmount--;
        }
    }

    public void Activate()
    {
        activated = true;
    }

    public void Deactivate()
    {
        activated = false;
    }
}
