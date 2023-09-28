using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAndRotate : MonoBehaviour
{

    public float rotateSpeed = 2.0f; // Time for one 360° rotation
    public float bounceAmplitude = 0.5f;
    public float bounceSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bounce and Rotate this transform
        transform.position = new Vector3(transform.position.x, bounceAmplitude * Mathf.Sin(bounceSpeed * Time.time), transform.position.z);
        transform.rotation = Quaternion.Euler(0, rotateSpeed * Time.time, 0);
    }
}
