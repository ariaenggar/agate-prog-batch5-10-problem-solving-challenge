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
        float squareSpawnNum = Random.Range(minSquareCount, maxSareCount);
        for(int i = 0; i < squareSpawnNum; i++)
        {
            GameObject newSquare = Instantiate(square, square.transform.position, Quaternion.identity);
            
            SquareControl squareController = newSquare.GetComponent<SquareControl>();
            squareController.OnDestroyed += RespawnSquare;

            SetPosition(newSquare);
        }
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
        float randomY = Random.Range(-3.5f, 3.5f);
        float randomX = Random.Range(-7.8f, 7.8f);
            
        squareGameObject.transform.position = new Vector2(randomX, randomY);
    }

}
