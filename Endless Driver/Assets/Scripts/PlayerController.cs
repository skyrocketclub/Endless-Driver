using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // private Rigidbody playerRb;
    private float horizontalInput;
    private float xRange = 8.0f;
    public float speed = 5.0f;
    public GameObject flame;
    public ParticleSystem particleSystem;

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
            Debug.Log("Music Collected...");
            PlayRandomMusic.changeMusic = true;
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Powerup Collected...");
            GameManager.hasPowerup = true;
            Destroy(other.gameObject);
            flame.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(GameManager.hasPowerup == true)
            {
                //Player destroys enemy vehicles if he has Power up...
                Debug.Log("You hit an Enemy and you destroyed him...");
                GameManager.hasPowerup = false;
                Destroy(collision.gameObject);
                flame.gameObject.SetActive(false);
                particleSystem.Play();
            }
            else
            {
                Debug.Log("You hit an Enemy...");
                GameManager.lives -= 1;
            }
        }
    }
}
