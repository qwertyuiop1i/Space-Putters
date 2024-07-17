using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject ball;

    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.GetComponent<GolfBallScript>().isWon)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, transform.position, Time.deltaTime * 1f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball.GetComponent<GolfBallScript>().isWon = true;
            winScreen.SetActive(true);
        }
    }
  
}
