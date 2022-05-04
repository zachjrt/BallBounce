using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float V = 1;
    Rigidbody2D rb;
    public float bounceForce;
    bool gameStarted;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                StartBounce();
                gameStarted = true;
                GameManager.instance.Gamestart();
            }
        }
    
    }

    //Used to create the impulse
    void StartBounce()
    {
        Vector2 randomDirection = new Vector2(-1, 1);
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FallCheck")
        {
            GameManager.instance.Restart();
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.ScoreUp();
            source.Play();
           
        }
    }
}
