using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Problem3
{
    public class BallControl : MonoBehaviour
    {
        // Rigidbody 2D bola
        private Rigidbody2D rigidBody2D;
     
        // Besarnya gaya awal yang diberikan untuk mendorong bola
        public float xInitialForce;
        public float yInitialForce;
        
        // Titik asal lintasan bola saat ini
        private Vector2 trajectoryOrigin;
        
        private float maxSpeed = 10.0f;

        // Start is called before the first frame update
        void Start()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
            
            trajectoryOrigin = transform.position;
            
            // Mulai game
            RestartGame();
        }

        // Update is called once per frame
        void Update()
        {
        }

        /*private void FixedUpdate()
        {
            rigidBody2D.velocity = Vector2.ClampMagnitude(rigidBody2D.velocity, maxSpeed);
        }*/

        void ResetBall()
        {
            // Reset posisi menjadi (0,0)
            transform.position = Vector2.zero;
     
            // Reset kecepatan menjadi (0,0)
            rigidBody2D.velocity = Vector2.zero;
        }
        
        void PushBall()
        {
            // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
            float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
          
            float magnitude = (yInitialForce * yInitialForce) + (xInitialForce * xInitialForce);

            float xForce = (float)Math.Sqrt(magnitude - (yRandomInitialForce * yRandomInitialForce));

            // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
            float randomDirection = Random.Range(-1, 2);

            // Jika nilainya di bawah 1, bola bergerak ke kiri. 
            // Jika tidak, bola bergerak ke kanan.
            if (randomDirection < 1.0f)
            {
                // Gunakan gaya untuk menggerakkan bola ini.
                rigidBody2D.AddForce(new Vector2(-xForce, yRandomInitialForce));
            }
            else
            {
                rigidBody2D.AddForce(new Vector2(xForce, yRandomInitialForce));
            }

            //rigidBody2D.velocity = Vector2.ClampMagnitude (rigidBody2D.velocity, speed);
        }
        
        void RestartGame()
        {
            // Kembalikan bola ke posisi semula
            ResetBall();
     
            // Setelah 2 detik, berikan gaya ke bola
            Invoke("PushBall", 2);
        }
        
        // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
        private void OnCollisionExit2D(Collision2D collision)
        {
            trajectoryOrigin = transform.position;
        }
        
        // Untuk mengakses informasi titik asal lintasan
        public Vector2 TrajectoryOrigin
        {
            get { return trajectoryOrigin; }
        }
    }
}
