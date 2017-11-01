using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour 
{
    private Transform[] spawnPositions;
    [SerializeField]private GameObject[] products;

    private void Start()
    {
        this.spawnPositions = GameObject.FindGameObjectWithTag("spawnpositions").GetComponentsInChildren<Transform>();
        spawnFood();
    }

    public void spawnFood()
    {
        for (var i = 0; i < products.Length; i++)
        {
            products[i].transform.position = spawnPositions[i].position;
            products[i].SetActive(true);
        }
    }
}
