using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    float offsetX, offsetY, offsetZ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RefreshInfoText(string text, bool isButtonActive)
    {
        transform.GetChild(1).GetComponent<Text>().text = text;
        if (isButtonActive)
            transform.GetChild(1).gameObject.SetActive(true);
        if (!isButtonActive)
        {
            transform.GetChild(2).gameObject.SetActive(false);
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 50);
        }

    }
}
