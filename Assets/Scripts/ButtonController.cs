using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    internal GameObject selectedCoffeePackage;
    public static ButtonController instance;
    GameObject[] coffeePackages;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseCoffeePackage()
    {
        coffeePackages = GameObject.FindGameObjectsWithTag("CoffeePackage");
        foreach (GameObject coffeePackage in coffeePackages)
        {
            coffeePackage.GetComponent<BoxCollider>().enabled = false;
        }
        selectedCoffeePackage = EventSystem.current.currentSelectedGameObject.transform.parent.transform.parent.gameObject;
        CoffeeTank.instance.coffeeName = selectedCoffeePackage.name;
        selectedCoffeePackage.GetComponent<CoffeePackage>().GotoCoffeeTankPosition();
        CameraPositionHandler.instance.GoToGrindingPosition();
       
    }
}
