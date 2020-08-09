using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text statusText;
    public static GameManager instance;
    public Button fillBtn;
    internal bool canFade;
    internal bool canGrind = true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        fillBtn.interactable = false;
        statusText.text = "Please push the red  \nbutton to start  \ngrinding.";
    }

    // Update is called once per frame
    void Update()
    {
        if (CoffeeTank.instance.insCoffeeParticle != null)
        {
            if (CoffeeTank.instance._beansCount == 0)
            {
                fillBtn.interactable = true;
                canFade = false;
                statusText.text = "Done !";
                StartCoroutine(SwicthSpotLightOff());
                GameObject.FindGameObjectWithTag("StartButton").GetComponent<BoxCollider>().enabled = true;
                CoffeeTank.instance.insCoffeeParticle.SetActive(false);
                if (MeshDeformer.instance!=null)
                {
                    MeshDeformer.instance.canDeform = true;
                   

                }
              
            }
                
        }
    }

    public IEnumerator SwicthSpotLightOff()
    {
        for (int i = 0; i < 30; i++)
        {
            CoffeeDispanser.spotLight.intensity -= 1;
            yield return new WaitForSeconds(0.01f);
        }
    }
    public IEnumerator fadingText(string text)
    {
        while (canFade)
        {
            GameManager.instance.statusText.text = text;
            yield return new WaitForSeconds(0.5f);
            GameManager.instance.statusText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

}
