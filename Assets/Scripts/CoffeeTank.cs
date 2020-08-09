using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeTank : MonoBehaviour
{
    public GameObject coffeeBeanPrefab;
    public GameObject coffeeParticlePrefab;
    public int beansCount;
    internal int _beansCount = 20;
    public Transform spawnPoint;
    public Transform coffeeParticleSpawnPoint;
    List<GameObject> coffeeBeans = new List<GameObject>();
    public GameObject insCoffeeParticle = null;
    public static CoffeeTank instance;
    public bool grinding = false;



    [Header("Info Text Options")]
    bool canShowInfo = true;
    GameObject instantiatedInfoTextCanvas;
    public GameObject infoTextCanvas;
    public bool right;
    public bool bottom;
    float offsetX, offsetY, offsetZ;
    internal string coffeeName;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (right)
        {
            offsetX = 4f;
            offsetY = 2f;
            offsetZ = -1f;
        }
        if (bottom)
        {
            offsetX = 0f;
            offsetY = -1.8f;
            offsetZ = -1f;
        }
        insCoffeeParticle = Instantiate(coffeeParticlePrefab, coffeeParticleSpawnPoint.transform.position, Quaternion.identity);
        insCoffeeParticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGrind()
    {

        _beansCount = Potentiometer.instance.coffeeBeansCount;
        insCoffeeParticle.SetActive(true);
        GameManager.instance.canFade = true;
        StartCoroutine(SwicthSpotLightOn());
        StartCoroutine(DeleteBeans());
        StartCoroutine(GameManager.instance.fadingText("Grinding.."));
    }
    public void Fill()
    {

        StartCoroutine(FillTank());

    }
    public IEnumerator FillTank()
    {
        while (beansCount > 0)
        {
            beansCount--;
            coffeeBeans.Add(Instantiate(coffeeBeanPrefab, new Vector3(spawnPoint.transform.position.x + Random.Range(-0.5f, 0.5f), spawnPoint.transform.position.y, spawnPoint.transform.position.z + Random.Range(-0.5f, 0.5f)), Quaternion.identity));
            yield return new WaitForSeconds(0.01f);
        }

    }
    public IEnumerator SwicthSpotLightOn()
    {
        for (int i = 0; i < 30; i++)
        {
            CoffeeDispanser.spotLight.intensity += 1;
            yield return new WaitForSeconds(0.01f);
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
    public IEnumerator DeleteBeans()
    {
        for (int i = 0; i < Potentiometer.instance.coffeeBeansCount; i++)
        {

            Destroy(coffeeBeans[i]);
            _beansCount -= 1;
            yield return new WaitForSeconds(0.12f);
        }
    }

    void ShowInfoText()
    {
        if (canShowInfo)
        {
            instantiatedInfoTextCanvas = Instantiate(infoTextCanvas, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z + offsetZ), Quaternion.identity);
            instantiatedInfoTextCanvas.transform.SetParent(this.transform);
            instantiatedInfoTextCanvas.GetComponent<Info>().RefreshInfoText(_beansCount.ToString() + " gr." + coffeeName + "  Coffee", false);
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
