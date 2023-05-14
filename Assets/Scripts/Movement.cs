using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Order of  the sequence
 
    //PARAMETERS - for tuning, typically set in the editor

    //CACHE - e.g. refrences for readability or speed 

    //STATE - private instance (member) variables 



    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;


    // here to access better
    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();


    }
    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed SPACE - Thrusting");
            //rb.AddRelativeForce(0, 1, 0);
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                ///audioSource.Play();
                audioSource.PlayOneShot(mainEngine);

            }
            if (!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }

        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Rotating Left");
            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
            //ApplyRotation(rotationThrust);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Debug.Log("Rotating Right");
            //  transform.Rotate(- Vector3.forward * rotationThrust * Time.deltaTime);
            ApplyRotation(-rotationThrust);
            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
        }
        else
        {
            rightThrusterParticles.Stop();
            leftThrusterParticles.Stop();

        }





        void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true; //freezing rtation so we cam maually rotate

            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

            rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
        }

    }
} 
