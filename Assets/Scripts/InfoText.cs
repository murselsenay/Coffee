using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    public Canvas infoCanvas;
    Canvas instantiatedInfoCanvas;
    bool canShow = true;

    [Header("Info Text Position")]
 
    public bool right;
    public bool bottom;
    float offsetX, offsetY, offsetZ;

    [Header("Info Text Type")]
    public bool coffeePackage;

   

    public static InfoText instance;
    public bool isButtonActive;

    // Start is called before the first frame update
    void Start()
    {

        

      /*  if (right)
        {
            offsetX = 4f;
            offsetY = 3f;
            offsetZ = 1f;
        }
        if (bottom)
        {
            offsetX = 0f;
            offsetY = -1.8f;
            offsetZ = -1f;
        }
        */

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        if (canShow)
        {
            instantiatedInfoCanvas = Instantiate(infoCanvas, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z + offsetZ), Quaternion.identity);
            instantiatedInfoCanvas.transform.SetParent(this.transform);
            if (gameObject.GetComponent<CoffeePackage>()!=null)
                RefreshText(gameObject.GetComponent<CoffeePackage>().coffeeName + "\n" + gameObject.GetComponent<CoffeePackage>().describtion + "\n" + gameObject.GetComponent<CoffeePackage>().weight.ToString() + " gr.\n" + "Brew Time: ~" + gameObject.GetComponent<CoffeePackage>().brewTime.ToString() + "m");
            if (gameObject.GetComponent<CoffeeTank>() != null)
                RefreshText(gameObject.GetComponent<CoffeeTank>()._beansCount + "gr. Coffee");


            if (isButtonActive)
                instantiatedInfoCanvas.transform.GetChild(2).gameObject.SetActive(true);
            if (!isButtonActive)
                instantiatedInfoCanvas.transform.GetChild(2).gameObject.SetActive(false);




            canShow = false;
        }

    }
    private void OnMouseExit()
    {
        if (!canShow)
        {
            canShow = true;
            Destroy(instantiatedInfoCanvas.gameObject);

        }

    }

    public void RefreshText(string text)
    {
        instantiatedInfoCanvas.transform.GetChild(1).GetComponent<Text>().text = text;
    }
}
