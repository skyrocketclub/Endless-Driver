using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
       // repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        //Debug.Log("Repeat Width: " + repeatWidth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 258.0f)
        {
            transform.position = startPos;
        }
    }
}
