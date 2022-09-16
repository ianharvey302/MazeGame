using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float totalMoveDistance;

    Vector3 startingLocation;
    Vector3 negDirection;
    bool activated;

    // Start is called before the first frame update
    void Start()
    {
        startingLocation = gameObject.transform.position;
        negDirection = -moveDirection;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTraveled = GetDistanceTraveled();

        if ((activated && distanceTraveled < totalMoveDistance) || (!activated && distanceTraveled > 0.001f))
        {
            gameObject.transform.Translate(moveDirection * moveSpeed);
        }
    }

    void FlipMoveDirection()
    {
        if (!activated)
            moveDirection = negDirection;
        else
            moveDirection = -negDirection;
    }

    float GetDistanceTraveled()
    {
        return Vector3.Distance(gameObject.transform.position, startingLocation);
    }

    public void Activate()
    {
        activated = true;
        FlipMoveDirection();
    }

    public void Deactivate()
    {
        activated = false;
        FlipMoveDirection();
    }
}
