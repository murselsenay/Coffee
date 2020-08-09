using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoffeeJar : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    internal float minYLimit;
    internal float maxYLimit;
    internal bool canDrag = false;



    internal bool checkDispanserPosition = false;
    internal GameObject dispanser;

    GameObject lid;

    public static MoveCoffeeJar instance;


    [Header("Info Text Options")]
    bool canShowInfo = false;
    GameObject instantiatedInfoTextCanvas;
    public GameObject infoTextCanvas;
    public bool right;
    public bool bottom;
    float offsetX, offsetY, offsetZ;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        lid = gameObject.transform.GetChild(1).gameObject;
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

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.6f, 4.2f), Mathf.Clamp(transform.position.y, minYLimit, maxYLimit), Mathf.Clamp(transform.position.z, -22f, -13f));
       
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    private void OnMouseUp()
    {
        if (checkDispanserPosition)
        {
            if (dispanser != null)
            {
                transform.position = dispanser.transform.position;
            }

        }
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    private void OnMouseDrag()
    {
        if (canDrag)
            transform.position = GetMouseWorldPos() + mOffset;


    }


    private void OnMouseOver()
    {
       // ShowInfoText();
    }
    private void OnMouseExit()
    {
       // DestroyInfoText();
    }
    void ShowInfoText()
    {
        if (canShowInfo)
        {
            instantiatedInfoTextCanvas = Instantiate(infoTextCanvas, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z + offsetZ), Quaternion.identity);
            instantiatedInfoTextCanvas.transform.SetParent(this.transform);
            instantiatedInfoTextCanvas.GetComponent<Info>().RefreshInfoText("40 gr. Grinding " + CoffeeTank.instance.coffeeName, false);
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
