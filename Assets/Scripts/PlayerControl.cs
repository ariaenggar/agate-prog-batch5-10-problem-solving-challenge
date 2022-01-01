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

    private KeyCode[] keyCodes = {KeyCode.W,KeyCode.S,KeyCode.A,KeyCode.D}; 
 
    public float speed = 5.0f;
    private int score;
    public Text scoreText;

    void Start()
    {
        InvokeRepeating("ChangeInputBind", 10.0f, 10.0f);
        InvokeRepeating("IncrementScore", 1.0f, 1.0f);
    }

    void ChangeInputBind()
    {
        int index = Random.Range(0, 3);

        if (index == 1)
        {
            do
            {
                upButton = (KeyCode)Random.Range(97, 122);
            } while (keyCodes.Contains(upButton));
            keyCodes[0] = upButton;
        }

        if (index == 2)
        {
            do
            {
                downButton = (KeyCode)Random.Range(97, 122);
            } while (keyCodes.Contains(downButton));

            keyCodes[1] = downButton;
        }

        if (index == 3)
        {
            do
            {
                leftButton = (KeyCode)Random.Range(97, 122);
            } while (keyCodes.Contains(leftButton));

            keyCodes[2] = leftButton;
        }

        if (index == 4)
        {
            do
            {
                rightButton = (KeyCode)Random.Range(97, 122);
            } while (keyCodes.Contains(rightButton));

            keyCodes[3] = rightButton;
        }

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

        pos.y = Mathf.Clamp(pos.y, -3.81f, 3.67f);
        pos.x = Mathf.Clamp(pos.x, -7.9f, 7.9f);
        
        transform.position = pos;
    }
    
    // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
    
    public void DecrementScore()
    {
        score = score - 10;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        if (anotherCollider.CompareTag("Square"))
        {
            DecrementScore();
        }
    }
}
