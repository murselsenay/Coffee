﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text statusText;
    public static GameManager instance;
    public Button fillBtn;
    internal bool canFade;
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
                CoffeeTank.instance.insCoffeeParticle.SetActive(false);
                MeshDeformer.instance.canDeform = true;
            }
                
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