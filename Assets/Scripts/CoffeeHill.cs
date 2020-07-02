using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoffeeHill : MonoBehaviour
{
    private int counter = 0;
    public Text txt;
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
            fillCoffee();
        }
        
        Debug.Log(CoffeeTank.instance._beansCount.ToString());

    }
    void fillCoffee()
    {
        transform.parent.localScale += new Vector3(0, 0.5f, 0);
    }
    void changeColor(byte r, byte g, byte b, byte a)
    {
        var coffeeColor = new MaterialPropertyBlock();
        coffeeColor.SetColor("_BaseColor", new Color32(r, g, b, a));
        GetComponent<Renderer>().SetPropertyBlock(coffeeColor);
    }
}
