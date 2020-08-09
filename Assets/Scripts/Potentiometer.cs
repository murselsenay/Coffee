using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potentiometer : MonoBehaviour
{
    public int coffeeBeansCount = 20;
    int clickCount;
    int cupCount = 2;
    public static Potentiometer instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45);
        clickCount++;
        cupCount += 2;
        coffeeBeansCount += 20;
        if (clickCount == 6)
        {
            clickCount = 0;
            cupCount = 2;
            coffeeBeansCount = 20;
            transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90);
        }
    }
}
