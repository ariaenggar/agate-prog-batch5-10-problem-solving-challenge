using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Problem5
{
    
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
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
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
}
