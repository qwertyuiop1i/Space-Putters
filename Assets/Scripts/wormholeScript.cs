using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormholeScript : MonoBehaviour
{
    public Transform pairedWormhole;
    public GameObject ball;

    public AudioClip teleportSound;
    private AudioSource audioSource;


    private void Start()
    {
        ball=GameObject.Find("Ball");
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")&&!ball.GetComponent<GolfBallScript>().ballPassing)
        {
            ball.GetComponent<GolfBallScript>().ballPassing = true;
            collision.transform.position = pairedWormhole.position;
            audioSource.PlayOneShot(teleportSound);
            Invoke("ResetTeleportFlag", 1f);
        }
    }
    private void ResetTeleportFlag()
    {
        ball.GetComponent<GolfBallScript>().ballPassing = false;
        
    }
}
