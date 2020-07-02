using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    private Touch touch;
    private float speed;

    private Vector3 mOffset;

    private float mZCoord;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z + touch.deltaPosition.y * speed);
            }
        }
        transform.position =new Vector3(Mathf.Clamp(transform.position.x, -3.6f, 4.2f), Mathf.Clamp(transform.position.y, 0, 2f), Mathf.Clamp(transform.position.z, -1f, 5f));
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
