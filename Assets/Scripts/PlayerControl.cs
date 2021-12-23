using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
 
    public float speed = 5.0f;
 
 
    private Rigidbody2D rigidBody2D;
 
    private int score;
    
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
   
        if (Input.GetKey(upButton))
        {
            pos.y += speed * Time.deltaTime;
        }
        else if (Input.GetKey(downButton))
        {
            pos.y -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(leftButton))
        {
            pos.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(rightButton))
        {
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;
    }
    
    // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }
    
    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }
 
    // Mendapatkan nilai skor
    public int Score
    {
        get { return score; }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Ball"))
        {
        }
    }
}
