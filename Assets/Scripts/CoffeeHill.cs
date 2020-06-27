using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeHill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GrindedCoffee")
        {
            transform.localScale += new Vector3(0, 0, 0.01f);
            Debug.Log("d");
            Destroy(other.gameObject);
        }
    }
  
}
