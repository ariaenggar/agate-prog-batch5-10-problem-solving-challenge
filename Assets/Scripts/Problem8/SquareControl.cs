using UnityEngine;
using UnityEngine.Events;
namespace Problem8
{
        
    public class SquareControl : MonoBehaviour
    {
        
        public UnityAction<SquareControl> OnDestroyed = delegate {    };
        
        void OnTriggerEnter2D(Collider2D anotherCollider)
        {
            if (anotherCollider.CompareTag("Player"))
            {
                OnDestroyed(this);
                gameObject.SetActive(false);
            }
        }
    }
}
