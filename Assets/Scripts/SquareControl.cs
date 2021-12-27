using UnityEngine;
using UnityEngine.Events;

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
