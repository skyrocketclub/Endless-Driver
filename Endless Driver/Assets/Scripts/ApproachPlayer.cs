using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : MonoBehaviour
{
    private float speed = 30.0f;
    private float destroyBoundary = 90.0f;
    public AudioClip enemySoundTrack;
    private AudioSource audioSource;
    private float rotationSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = enemySoundTrack;
            audioSource.Play();
        }
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

        if (gameObject.CompareTag("Music"))
        {
            //for instantaenous rotation
            Vector3 forwardDirection = transform.forward;
            transform.Rotate(forwardDirection, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }


}
