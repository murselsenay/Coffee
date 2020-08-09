using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject light;
    internal bool canStartGrinding = false;
    public static ButtonScript instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (CoffeeTank.instance.beansCount == 0f)
        {
            if (canStartGrinding)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
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
                GameManager.instance.canFade = false;
                GameManager.instance.statusText.text = "Put portafilter\nto correct position.";
            }

        }
        else
        {

            GameManager.instance.canFade = false;
            GameManager.instance.statusText.text = "Wait for \nfilling coffee.";


        }

    }
}
