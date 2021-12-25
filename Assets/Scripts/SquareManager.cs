using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    [SerializeField] private GameObject square;
    [SerializeField] private int minSquareCount = 10;
    [SerializeField] private int maxSareCount = 30;

    private void Start()
    {
        float squareSpawn = Random.Range(minSquareCount, maxSareCount);
        for(int i = 0; i < squareSpawn; i++)
        {
            GameObject newSquare = Instantiate(square, square.transform.position, Quaternion.identity);
            
            float randomY = Random.Range(-3.5f, 3.5f);
            float randomX = Random.Range(-7.8f, 7.8f);
            
            newSquare.transform.position = new Vector2(randomX, randomY);
        }
    }

}
