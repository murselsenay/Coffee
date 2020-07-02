using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (CoffeeTank.instance.beansCount== 0f)
        {
            GameObject[] coffeeBeans = GameObject.FindGameObjectsWithTag("CoffeeBeans");
            foreach (GameObject beans in coffeeBeans)
            {
                beans.GetComponent<CoffeeBean>().StartBeGrinded();
            }
            CoffeeTank.instance.StartGrind();
            light.SetActive(true);
        }
        else
        {
            Debug.Log("Wait");
        }
        
    }
}
