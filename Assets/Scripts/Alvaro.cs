using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvaro : MonoBehaviour
{

    public Rigidbody2D target;
    private Rigidbody2D body;
    private Vector2 movement;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;

        float angle =  Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        body.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    void FixedUpdate()
    {
        move(movement);
    }

    private void move(Vector2 direction)
    {
        body.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
