using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;
    internal float minYLimit=10;
    internal float maxYLimit=12;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.6f, 4.2f), Mathf.Clamp(transform.position.y, minYLimit, maxYLimit), Mathf.Clamp(transform.position.z, -22f, -12f));
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
