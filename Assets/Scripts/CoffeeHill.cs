using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoffeeHill : MonoBehaviour
{
    private int counter=0;
    private int limit = 0;

    public Text txt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("d");
        counter += 1;
        if (limit<=25)
        {
            if (counter >= 5)
            {
                fillCoffee();
                counter = 0;
            }
            limit++;
        }
        else
        {
            Destroy(other.gameObject);
            txt.text = "You can manipulate \n the grinded coffee with mouse now.";
        }
       
    }
    void fillCoffee()
    {
        transform.localScale += new Vector3(0, 0, 0.01f);
    }
}
