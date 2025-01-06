using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_movement_and_destruction : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float deadZone = -200f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }      
    
    }
}
