using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
   
    public AudioClip collisionSound;
    private AudioSource audioSource; 

    public Rigidbody2D rb;

    public bool isMoving;
    public bool isAiming;
    public bool isWon;

    public Vector2 aimDirection;
    public float power;

    public int shots;
    public int par;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        isMoving = false;
        isAiming = false;
        isWon = false;

        power = 0f;
        shots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((Vector2.Distance(transform.position, mousePos)<1f)&&Input.GetMouseButtonDown(0) && !isMoving)
        {
            rb.velocity = Vector2.zero;
            isAiming = true;
        }
        if (Input.GetMouseButton(0) && isAiming)
        {
            aimDirection = (mousePos - (Vector2)transform.position).normalized;
            power = Mathf.Clamp(Vector2.Distance((Vector2) transform.position, mousePos),0f,7f);
        }
        if (Input.GetMouseButtonUp(0) && isAiming)
        {
            isMoving = true;
            isAiming = false;
            rb.velocity = aimDirection * -power * 5f;
        }
        isMoving = rb.velocity.magnitude > 0.1f;
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionSound != null && audioSource != null)
        {
            
            float volume = Mathf.Clamp(rb.velocity.magnitude / 10.0f, 0f, 1.0f);
            audioSource.volume = volume;
            audioSource.PlayOneShot(collisionSound);
        }
    }


}
