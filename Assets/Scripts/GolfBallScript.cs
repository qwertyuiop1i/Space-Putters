using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GolfBallScript : MonoBehaviour
{
   
    public AudioClip collisionSound;
    public AudioClip hitSound;
    public AudioClip chargeSound;
    public AudioClip releaseSound;
    private AudioSource audioSource;

    public TextMeshProUGUI strikeText;

    public Rigidbody2D rb;

    public GameObject mousePE;
    private ParticleSystem mouseParticleSystem;

    public LineRenderer aimLine;
    public float minLineThickness = 0.2f;
    public float maxLineThickness = 0.7f;
    public Color minPowerColor = Color.green;
    public Color maxPowerColor = Color.red;
    public Material Lmaterial;

    public bool isMoving;
    public bool isAiming;
    public bool isWon;

    public bool ballPassing = false;

    public Vector2 aimDirection;
    public float power;
    public float maxPower = 7f;

    public int shots;
    public int par;


    void Start()
    {
        mousePE = GameObject.Find("mouseParticles");
        mouseParticleSystem = mousePE.GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();


        

        isMoving = false;
        isAiming = false;
        isWon = false;

        power = 0f;
        shots = 0;

        strikeText.text = "Strikes: " + shots;

        aimLine = GetComponent<LineRenderer>();
        aimLine.enabled = false;
        mouseParticleSystem.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((Vector2.Distance(transform.position, mousePos)<1f)&&Input.GetMouseButtonDown(0) && !isMoving &&!isWon)
        {
            rb.velocity = Vector2.zero;
            isAiming = true;
            aimLine.enabled = true;
            mouseParticleSystem.Play();
            

        }

        if (Input.GetMouseButton(0) && isAiming)
        {

            aimDirection = (mousePos - (Vector2)transform.position).normalized;
            power = Mathf.Clamp(Vector2.Distance((Vector2) transform.position, mousePos)/3,0f,maxPower);

            aimLine.SetPosition(0, transform.position);
            aimLine.SetPosition(1, mousePos);

            //float lineThickness = Mathf.Lerp(minLineThickness, maxLineThickness, power / maxPower);
           // aimLine.startWidth = lineThickness;
            //aimLine.endWidth = lineThickness;
            Color lineColor = Color.Lerp(minPowerColor, maxPowerColor, power / maxPower);
            aimLine.startColor = lineColor;
            aimLine.endColor = lineColor;
            Lmaterial.SetColor("_Color", lineColor*800);

            mousePE.transform.position = mousePos;
            var em = mousePE.GetComponent<ParticleSystem>().emission;
            em.rateOverTime = power * 4;
            var mav = mousePE.GetComponent<ParticleSystem>().main;
            mav.startSpeed = power*8;




            audioSource.clip = chargeSound;
            audioSource.volume = power / maxPower;

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }



        }

        if (Input.GetMouseButtonUp(0) && isAiming)
        {
            mouseParticleSystem.Stop();
            audioSource.Stop();
            float volume = power / maxPower;
            audioSource.volume = volume;
            isMoving = true;
            isAiming = false;
            rb.velocity = aimDirection * -power * 5f;
            aimLine.enabled = false;
            
           
            audioSource.PlayOneShot(hitSound);
            shots += 1;
            strikeText.text = "Strikes: " + shots;

           
      
            

            audioSource.PlayOneShot(releaseSound);
        }
        isMoving = rb.velocity.magnitude > 0.1f;
        


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionSound != null && audioSource != null)
        {

            float volume = power / maxPower;
            audioSource.volume = volume;
            audioSource.PlayOneShot(collisionSound);
        }
    }


}
