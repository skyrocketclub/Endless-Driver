using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // private Rigidbody playerRb;
    private float horizontalInput;
    private float xRange = 8.0f;
    public float speed = 5.0f;
    

    // Start is called before the first frame update
    void Start()
    {
       // playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            Debug.Log("Heart Collected...");
            Destroy(other.gameObject);
            GameManager.lives += 1;
        }
        else if (other.gameObject.CompareTag("Music"))
        {
            Destroy(other.gameObject);
            Debug.Log("Music Collected...");
            PlayRandomMusic.changeMusic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You hit an Enemy...");
            GameManager.lives -=1;
        }
    }
}
