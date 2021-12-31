using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
 
    public float speed = 5.0f;
    private int score;
    public Text scoreText;

    void Start()
    {
        int key = Random.Range(97, 122);
        Debug.Log("Up is :" + KeyCode.W);
        upButton = (KeyCode)key;
        Debug.Log("Up is :" + (KeyCode)key);
        Debug.Log("me" + this.gameObject.name);
    }

    void Update()
    {
        Vector3 pos = transform.position;
   
        if (Input.GetKey(upButton))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(downButton))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(leftButton))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(rightButton))
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

    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        if (anotherCollider.CompareTag("Square"))
        {
            IncrementScore();
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
        }
    }
}
