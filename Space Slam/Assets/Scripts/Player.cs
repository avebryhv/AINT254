using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    private float movementSpeed = 10;
    public float turningSpeed = 60;
    public float thrust; //Force when the player boosts
    public int score = 0;

    [Range(0, 200f)]
    public float charge;

    public Rigidbody rb;
    public Slider boostSlider;
    public float V;
    public Camera p1Cam;
    public ParticleSystem fire;
    public ParticleSystem boost;
    public ParticleSystem glow;    
    AudioSource audioPlayer;
    public AudioClip afterburnerSound;
    public AudioClip explosion;
    public AudioSource boostPlayer;
    public GameObject explosionEffect;
    SFXPlayer SFXPlayer;
    public bool inArena;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        SFXPlayer = GameObject.FindGameObjectWithTag("SFX_Player").GetComponent<SFXPlayer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("p1Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal * 2, 0);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        //transform.Translate(0, 0, vertical);

        if (Input.GetKeyDown("w")) //Plays effects while the player is charging
        {
            boostPlayer.Play();
            glow.Play();
        }
        if (Input.GetKey("w"))
        {
            if (charge < 200) //Caps charge level
            {
                charge += 1 * Time.deltaTime * 120; //Adds charge
            }
            p1Cam.fieldOfView = Mathf.Lerp(p1Cam.fieldOfView, 60 - (charge / 20), Time.deltaTime); //Zooms in the camera while charging
            var main = glow.main;
            main.startSpeed = main.startSpeed = (charge / 200 * 12); //Plays the back flame effect, scaling on charge
            //rb.AddForce(transform.forward * thrust);
        }
        if (Input.GetKeyUp("w")) //Release charge/boost
        {
            boostPlayer.Stop();
            //audioPlayer.Play();
            SFXPlayer.PlaySound(afterburnerSound);
            var main = boost.main;
            main.startSpeed = (charge / 200 * 12) + 3; //Plays afterburner effect
            boost.Play();
            glow.Stop();
            rb.AddForce(transform.forward * charge * thrust); //Shoots player forward
            charge = 0; //Resets charge
        }
        if (Input.GetKeyDown("q") && charge > 190) //Allows player to jump
        {
            rb.AddForce(transform.up * charge * thrust / 10);
            charge = 0;
        }
        if (transform.position.y < -5) //When player falls off map
        {
            //audioPlayer.PlayOneShot(explosion);
            SFXPlayer.PlaySound(explosion);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            score++;
            gameObject.SetActive(false);
            Invoke("Respawn", 1f); //Gives small pause before the player respawns
        }
        if (Input.GetKeyDown("s"))
        {
            charge = 0;
        }

        V = rb.velocity.magnitude;
        if (V >= 30) //Zooms out camera when going at higher speed
        {
            p1Cam.fieldOfView = Mathf.Lerp(p1Cam.fieldOfView, 60 + (V * 1.5f) - 30, Time.deltaTime);
            fire.Play();
        }
        else if(charge == 0)
        {
            p1Cam.fieldOfView = Mathf.Lerp(p1Cam.fieldOfView, 60, Time.deltaTime);
            fire.Stop();
        }

        boostSlider.value = charge;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jump_Panel")
        {
            rb.AddForce(transform.up * 2000);
        }

        if (other.gameObject.tag == "ring_boundary") //Used to prevent player 2 AI from chasing player off the edge
        {
            inArena = true;
        }

    }

    private void OnTriggerExit(Collider other) //Used to prevent player 2 AI from chasing player off the edge
    {
        if (other.gameObject.tag == "ring_boundary")
        {
            inArena = false;
        }
    }

    private void Respawn() //Respawns the player
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0, 2 , -20);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        charge = 0;
        
    }
}
