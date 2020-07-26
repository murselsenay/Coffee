using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBean : MonoBehaviour
{
    public static CoffeeBean instance;
    // Start is called before the first frame update
    void Start()
    {
        //instance = this;

    }
    public void StartBeGrinded()
    {
        //float r = Random.Range(1f, 5f);
        //Invoke("GrindCoffee", r);
        //Destroy(gameObject, r);
    }
    void GrindCoffee()
    {
        //CoffeeTank.instance._beansCount -= 1;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
