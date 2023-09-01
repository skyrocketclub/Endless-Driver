using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : MonoBehaviour
{
    public float speed = 40.0f;
    private float destroyBoundary = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > destroyBoundary)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " has been destroyed!");
        }
    }


}
