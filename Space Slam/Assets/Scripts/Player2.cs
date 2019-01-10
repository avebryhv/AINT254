using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour {

    private float movementSpeed = 10;
    public float turningSpeed = 60;
    public float thrust;
    public float charge;
    public Rigidbody rb;
    public Slider boostSlider;
    public int score = 0;
    public float V;
    public Camera p2Cam;
    public ParticleSystem fire;
    public ParticleSystem boost;
    public ParticleSystem glow;
    AudioSource audioPlayer;
    public AudioClip afterburnerSound;
    public AudioClip explosion;
    public AudioSource boostPlayer;
    SFXPlayer SFXPlayer;
    public GameObject explosionEffect;

    //AI only variables
    public bool AI = false;
    public GameObject player1;
    int chargeLimit = 170;
    int AIMode = 0;
    public float p1dist;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        SFXPlayer = GameObject.FindGameObjectWithTag("SFX_Player").GetComponent<SFXPlayer>();
        AIMode = PlayerPrefs.GetInt("p2Mode");
        if (AIMode > 0)
        {
            AI = true;            
        }
        else
        {
            AI = false;            
        }
    }

    void Update()
    {
        p1dist = Vector3.Distance(transform.position, player1.transform.position);
        //AI INSTRUCTIONS
        if (AI && player1.GetComponent<Player>().inArena) //Sets behaviour of computer controlled player
        {
            //Vector3.RotateTowards(transform.right, player1.transform.position, turningSpeed * Time.deltaTime, 0.0f);
            //Quaternion.RotateTowards(transform.rotation, player1.transform, turningSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((player1.transform.position - transform.position).normalized), Time.deltaTime * (4 * AIMode));
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); //Rotates to face player 1

            charge += 1 * Time.deltaTime * 120; //Constantly charges
            
            var main = glow.main;
            main.startSpeed = main.startSpeed = ((charge) / 200 * 12);

            if (p1dist < 30 && AIMode == 2) 
            {
                chargeLimit = (int)p1dist * 4; //On hard mode, scales charging time based on distance to player 1 - boosts more often when close
            }
            
            if (charge > chargeLimit)
            {
                audioPlayer.PlayOneShot(afterburnerSound);
                var boostMain = boost.main;
                boostMain.startSpeed = (charge / 200 * 12) + 3;
                boost.Play();
                glow.Stop();
                rb.AddForce(transform.forward * charge * thrust);
                charge = (-120 + AIMode * 60); //Charge starts negative, to simulate a delay before the player starts charging again
                chargeLimit = Random.Range(90, 170);
                glow.Play();
            }
        }
        else
        {
            float horizontal = Input.GetAxis("p2Horizontal") * turningSpeed * Time.deltaTime;
            transform.Rotate(0, horizontal * 2, 0);
            //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            //float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            //transform.Translate(0, 0, vertical);

            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                boostPlayer.Play();
                glow.Play();
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                if (charge < 200)
                {
                    charge += 1 * Time.deltaTime * 120;
                }
                p2Cam.fieldOfView = Mathf.Lerp(p2Cam.fieldOfView, 60 - (charge / 20), Time.deltaTime);
                var main = glow.main;
                main.startSpeed = main.startSpeed = (charge / 200 * 12);
            }
            if (Input.GetKeyUp(KeyCode.Keypad8))
            {
                boostPlayer.Stop();
                audioPlayer.PlayOneShot(afterburnerSound);
                var main = boost.main;
                main.startSpeed = (charge / 200 * 12) + 3;
                boost.Play();
                glow.Stop();
                rb.AddForce(transform.forward * charge * thrust);
                charge = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad7) && charge > 190)
            {
                rb.AddForce(transform.up * charge * thrust / 10);
                Debug.Log("boosto");
                charge = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                charge = 0;
            }
        }

        

        if (transform.position.y < -5)
        {
            SFXPlayer.PlaySound(explosion);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            score++;
            gameObject.SetActive(false);
            Invoke("Respawn", 1f);
        }

        V = rb.velocity.magnitude;
        if (V >= 30)
        {
            p2Cam.fieldOfView = Mathf.Lerp(p2Cam.fieldOfView, 60 + V - 30, Time.deltaTime);
            fire.Play();
        }
        else
        {
            p2Cam.fieldOfView = Mathf.Lerp(p2Cam.fieldOfView, 60, Time.deltaTime);
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
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0,2,20);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        charge = 0;
        
    }
}
