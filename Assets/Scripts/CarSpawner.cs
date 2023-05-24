using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public GameObject[] cars;
    public float maxPos = 1.5f; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnCar), 1, 0.8f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCar()
    {
        Vector3 carPos = new Vector3(Random.Range(-maxPos, maxPos), transform.position.y, transform.position.z);

        int randomCar = Random.Range(0, cars.Length);
        Instantiate(cars[randomCar], carPos, transform.rotation);
    }

    
}
