using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public Rigidbody2D player;
    public int playerSpeed;
    public GameObject missile;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.velocity = Vector2.zero;

        int currSpeed = playerSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currSpeed = playerSpeed * 4;
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.velocity = player.velocity + Vector2.left * currSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.velocity = player.velocity + Vector2.right * currSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            player.velocity = player.velocity + Vector2.up * currSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.velocity = player.velocity + Vector2.down * currSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(missile, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(player.transform.up * 20f, ForceMode2D.Impulse);
        }
    }
}
