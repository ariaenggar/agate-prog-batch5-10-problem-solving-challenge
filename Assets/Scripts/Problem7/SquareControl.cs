using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Problem7
{
    public class SquareControl : MonoBehaviour
    {
        
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        void OnTriggerEnter2D(Collider2D anotherCollider)
        {
            if (anotherCollider.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
