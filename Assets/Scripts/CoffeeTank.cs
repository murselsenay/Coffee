using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeTank : MonoBehaviour
{
    public GameObject coffeeBeanPrefab;
    public GameObject coffeeParticlePrefab;
    public GameObject info;
    public Text infoText;
    public int beansCount;
    internal int _beansCount;
    public Transform spawnPoint;
    public Transform coffeeParticleSpawnPoint;
    List<GameObject> coffeeBeans = new List<GameObject>();
    public GameObject insCoffeeParticle = null;
    public static CoffeeTank instance;
    public bool grinding = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Fill();
        insCoffeeParticle = Instantiate(coffeeParticlePrefab, coffeeParticleSpawnPoint.transform.position, Quaternion.identity);
        insCoffeeParticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGrind()
    {
        insCoffeeParticle.SetActive(true);
        GameManager.instance.canFade = true;
        StartCoroutine(SwicthSpotLightOn());
        StartCoroutine(DeleteBeans());
        StartCoroutine(GameManager.instance.fadingText("Grinding.."));
    }
    public void Fill()
    {
        _beansCount = beansCount;
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
        infoText.text = _beansCount.ToString() + " gr. Coffee";
        info.SetActive(true);
    }
    private void OnMouseExit()
    {
        info.SetActive(false);
    }
    public IEnumerator DeleteBeans()
    {
        for (int i = 0; i < coffeeBeans.Count; i++)
        {
            Destroy(coffeeBeans[i]);
            _beansCount -= 1;
            yield return new WaitForSeconds(0.12f);
        }
    }
}
