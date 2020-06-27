using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeSpawner : MonoBehaviour
{
    public GameObject grindedCoffee;
    public int coffeeAmount = 5;
    void Start()
    {
        StartCoroutine(grindCoffee());
    }

    
    void Update()
    {
        
    }
    public IEnumerator grindCoffee()
    {
        while (coffeeAmount>0)
        {
            Instantiate(grindedCoffee, transform.position, Quaternion.identity);
            coffeeAmount -= 1;
            yield return new WaitForSeconds(2f);
        }
       
    }
}
