using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeePackage : MonoBehaviour
{
    [Header("Coffee Type Selection")]
    public bool arabica;
    public bool ethiopia;
    public bool kenya;
    public bool colombia;

    [Header("Package Cover Materials")]
    public Material arabicaMat;
    public Material ethiopiaMat;
    public Material kenyaMat;
    public Material colombiaMat;

    [Space]
    MeshRenderer packageMesh;

    internal string coffeeName;
    internal string describtion;
    internal float weight;
    internal float brewTime;

    public static CoffeePackage instance;
    Vector3 coffeeTankPosition;
    Vector3 startPosition;
    Quaternion startRotation;
    Quaternion lastRotation;

    [Header("Info Text Options")]
    bool canShowInfo = true;
    GameObject instantiatedInfoTextCanvas;
    public GameObject infoTextCanvas;
    public bool right;
    public bool bottom;
    float offsetX, offsetY, offsetZ;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (right)
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



        startPosition = transform.position;
        startRotation = transform.rotation;
        coffeeTankPosition = new Vector3(0.17f, 25.5f, -12f);
        packageMesh = GetComponent<MeshRenderer>();
        SetCoffeeType();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetCoffeeType()
    {
        if (arabica)
            Arabica();
        if (ethiopia)
            Ethiopia();
        if (kenya)
            Kenya();
        if (colombia)
            Colombia();

    }
    private void OnMouseDown()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);
    }
    private void OnMouseUp()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 4f);
    }
    void changeMat(Material packageMat)
    {
        Material[] mats = packageMesh.materials;

        mats[0] = packageMat;
        mats[1] = packageMat;
        packageMesh.materials = mats;
    }

    void Arabica()
    {
        changeMat(arabicaMat);
        Coffee arabica = new Coffee("Arabica", 250f, "Coffee from Arabia", 2f);
        gameObject.name = "Arabica";
        coffeeName = arabica.name;
        describtion = arabica.describtion;
        weight = arabica.weight;
        brewTime = arabica.brewTime;

    }
    void Ethiopia()
    {
        changeMat(ethiopiaMat);
        Coffee ethiopia = new Coffee("Ethiopia", 250f, "Coffee from Ethiopia", 3f);
        gameObject.name = "Ethiopia";
        coffeeName = ethiopia.name;
        describtion = ethiopia.describtion;
        weight = ethiopia.weight;
        brewTime = ethiopia.brewTime;
    }
    void Kenya()
    {
        changeMat(kenyaMat);
        Coffee kenya = new Coffee("Kenya", 250f, "Coffee from Kenya", 1f);
        gameObject.name = "Kenya";
        coffeeName = kenya.name;
        describtion = kenya.describtion;
        weight = kenya.weight;
        brewTime = kenya.brewTime;
    }
    void Colombia()
    {
        changeMat(colombiaMat);
        Coffee colombia = new Coffee("Colombia", 250f, "Coffee from Colombia", 2f);
        gameObject.name = "Colombia";
        coffeeName = colombia.name;
        describtion = colombia.describtion;
        weight = colombia.weight;
        brewTime = colombia.brewTime;
    }
    public void GotoCoffeeTankPosition()
    {
        StartCoroutine(GotoCoffeeTankPositionCoroutine());
    }

    public void GoBacktoShelf()
    {
        
        StartCoroutine(GoBacktoShelfCoroutine());
    }
    public IEnumerator GotoCoffeeTankPositionCoroutine()
    {

        var t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime / 2f;
            transform.position = Vector3.Lerp(startPosition, coffeeTankPosition, t);
            transform.rotation = Quaternion.Lerp(startRotation, new Quaternion(-90, 0, 0, 0), t * 0.08f);
            yield return null;
        }
        CoffeeTank.instance.Fill();
        yield return new WaitForSeconds(3f);
        GoBacktoShelf();

    }
    public IEnumerator GoBacktoShelfCoroutine()
    {

        var t = 0f;
        lastRotation = transform.rotation;
        while (t < 1)
        {
            t += Time.deltaTime / 2f;
            transform.position = Vector3.Lerp(coffeeTankPosition, startPosition, t);
            transform.rotation = Quaternion.Lerp(lastRotation, new Quaternion(0, 180, 0, 0), t * 0.5f);
            yield return null;
        }
    }
    private void OnMouseOver()
    {
        ShowInfoText();
    }
    private void OnMouseExit()
    {
        DestroyInfoText();
    }
    void ShowInfoText()
    {
        if (canShowInfo)
        {
            instantiatedInfoTextCanvas = Instantiate(infoTextCanvas, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z + offsetZ), Quaternion.identity);
            instantiatedInfoTextCanvas.transform.SetParent(this.transform);
            instantiatedInfoTextCanvas.GetComponent<Info>().RefreshInfoText(coffeeName + "\n" + describtion + "\n" + weight.ToString() + " gr.\n" + "Brew Time: ~" + brewTime.ToString() + "m",true);
            canShowInfo = false;
        }
    }
    void DestroyInfoText()
    {
        if (!canShowInfo)
        {
            canShowInfo = true;
            Destroy(instantiatedInfoTextCanvas);

        }
    }
}

class Coffee
{
    public string name { get; set; }
    public float weight { get; set; }
    public string describtion { get; set; }
    public float brewTime { get; set; }


    public Coffee(string _name, float _weight, string _describtion, float _brewTime)
    {
        this.name = _name;
        this.weight = _weight;
        this.describtion = _describtion;
        this.brewTime = _brewTime;

    }

}
