using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config pars
    [SerializeField] Paddle paddle1;
    [SerializeField] float xlaunch= 2f;
    [SerializeField] float ylaunch = 10f;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddletoballvector;
    bool hasStarted = false;
    AudioSource myaudiosource;
    Rigidbody2D myrigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        paddletoballvector = transform.position - paddle1.transform.position;
        myaudiosource = GetComponent<AudioSource>();
        myrigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            launchball();
            launchOnmouseclick();
        }
    }
    private void launchOnmouseclick()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xlaunch,ylaunch);
        }
    }
    private void launchball()
    { 
        Vector2 paddlePoss = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePoss + paddletoballvector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocitytweak =
            new Vector2(Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
            myaudiosource.PlayOneShot(clip);
            myrigidbody2d.velocity += velocitytweak;
        }
    }
}
