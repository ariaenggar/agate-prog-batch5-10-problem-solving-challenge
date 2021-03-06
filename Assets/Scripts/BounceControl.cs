using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BounceControl : MonoBehaviour
{
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;
 
    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
    
    private float maxSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        
        // Mulai game
        PushBall();
    }

    private void OnEnable()
    {
        if(rigidBody2D != null)
            PushBall();
    }

    public void PushBall()
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

    }
}
