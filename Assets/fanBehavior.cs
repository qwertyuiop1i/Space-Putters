using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanBehavior : MonoBehaviour
{
    public float forceStrength = 10f;
    public float radius = 5f;

    public ParticleSystem ps;

    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startSpeed = 0.2f * forceStrength;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb!=null)
        {
            rb.AddForce(transform.up*forceStrength/(0.1f+0.01f*Vector2.Distance(transform.position,collision.transform.position))*Time.deltaTime);
            //Debug.Log("ge");
        }
    }



}
