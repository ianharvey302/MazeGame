using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWallReset : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float force;

    Vector3 initial;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        initial = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = player.transform.position;

        Vector3 direction = new Vector3(playerpos.x - transform.position.x, 0, playerpos.z - transform.position.z);
        direction = direction.normalized;
        rb.AddForce(direction * force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bad")
        {
            transform.position = initial;
        }
    }
}
