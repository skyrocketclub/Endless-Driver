using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject car;
    public float smoothSpeed = 0.001f;
    private Vector3 offset;
  //  private Vector3 cameraPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - car.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //cameraPosition = new Vector3(car.transform.position.x, transform.position.y, transform.position.z);
        //transform.position = cameraPosition;
        Vector3 desiredPosition = car.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
