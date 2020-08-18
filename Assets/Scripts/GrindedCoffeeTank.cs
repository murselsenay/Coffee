using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindedCoffeeTank : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;
    internal float minYLimit;
    internal float maxYLimit;
    internal bool canDrag = false;



    internal bool checkDispanserPosition = false;
    internal GameObject dispanser;

    public static GrindedCoffeeTank instance;


    [Header("Info Text Options")]
    public GameObject infoTextCanvas;
    public bool right;
    public bool bottom;
    float startPositionX, startPositionY;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, startPositionX, startPositionX), Mathf.Clamp(transform.position.y, startPositionY, startPositionY), Mathf.Clamp(transform.position.z, -20f,-15f));
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;

    }
}
