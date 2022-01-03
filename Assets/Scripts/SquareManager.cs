using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    [SerializeField] private GameObject square;
    [SerializeField] private int minSquareCount = 10;
    [SerializeField] private int maxSareCount = 30;
    [SerializeField] private Collider2D playerCollider;
    private void Start()
    {
        float squareSpawnNum = Random.Range(minSquareCount, maxSareCount);
        for(int i = 0; i < squareSpawnNum; i++)
        {
            InstantiateNewSquare();
        }
        
        InvokeRepeating("InstantiateNewSquare", 2.0f, 2.0f);
    }

    private void InstantiateNewSquare()
    {
        GameObject newSquare = Instantiate(square, square.transform.position, Quaternion.identity);
            
        SquareControl squareController = newSquare.GetComponent<SquareControl>();
        squareController.OnDestroyed += RespawnSquare;

        SetPosition(newSquare);
    }
    
    public void RespawnSquare(SquareControl square)
    {
        StartCoroutine(RespawnCoroutine(square));
    }

    private IEnumerator RespawnCoroutine(SquareControl square)
    {
        yield return new WaitForSeconds(3f);
        square.gameObject.SetActive(true);
        SetPosition(square.gameObject);
    }

    private void SetPosition(GameObject squareGameObject)
    {
        Vector2 position = GetRandomPosition();
            
        while (playerCollider.bounds.Contains(position))
        {
            position = GetRandomPosition();
        }

        squareGameObject.transform.position = position;
    }

    private Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-7.8f, 7.8f), Random.Range(-3.5f, 3.5f));
    }

}
