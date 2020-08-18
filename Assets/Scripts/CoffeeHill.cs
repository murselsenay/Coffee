using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoffeeHill : MonoBehaviour
{
    private int counter = 0;
    public Text txt;
    float grindedCoffeeAmount;
    public bool jar = false;
    public bool portafilter = false;
    public bool grinderMachine = false;
    // Start is called before the first frame update
    void Start()
    {

        changeColor(128, 128, 128, 255);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)//değişecek
    {
        counter += 1;
        if (counter == 1)
        {
            changeColor(125, 81, 57, 255);
        }
        if (CoffeeTank.instance._beansCount > 1)
        {
            if (portafilter)
                grindedCoffeeAmount = 0.08f;
            if (jar)
                grindedCoffeeAmount = 0.0025f;
            if (grinderMachine)
                grindedCoffeeAmount = 0.0010f;


            fillCoffee(grindedCoffeeAmount);
        }

    }
    void fillCoffee(float _grindedCoffeeAmount)
    {
        transform.parent.localScale += new Vector3(0, _grindedCoffeeAmount, 0);
    }
    void changeColor(byte r, byte g, byte b, byte a)
    {
        var coffeeColor = new MaterialPropertyBlock();
        coffeeColor.SetColor("_BaseColor", new Color32(r, g, b, a));
        GetComponent<Renderer>().SetPropertyBlock(coffeeColor);
    }
}
