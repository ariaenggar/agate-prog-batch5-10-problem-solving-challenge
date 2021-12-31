using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    
    [SerializeField] private Text upText;
    [SerializeField] private Text downText;
    [SerializeField] private Text lefText;
    [SerializeField] private Text rightText;

    private KeyCode[] keyCodes = {0,0,0,0}; 
 
    public float speed = 5.0f;
    private int score;
    public Text scoreText;

    void Start()
    {
        upButton = (KeyCode)Random.Range(97, 122);
        keyCodes[0] = upButton;
        
        do {
            downButton = (KeyCode)Random.Range(97, 122);
        } while (keyCodes.Contains(downButton));
        keyCodes[1] = downButton;
 
        do {
            leftButton = (KeyCode)Random.Range(97, 122);
        } while (keyCodes.Contains(leftButton));
        keyCodes[2] = leftButton;
 
        do {
            rightButton = (KeyCode)Random.Range(97, 122);
        } while (keyCodes.Contains(rightButton));
        keyCodes[3] = rightButton;
        
        upText.text = "Up: " + upButton;
        downText.text = "Down: " + downButton;
        lefText.text = "Left\n" + leftButton;
        rightText.text = "Right\n" + rightButton;
    }

    void Update()
    {
        Vector2 pos = transform.position;
   
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
