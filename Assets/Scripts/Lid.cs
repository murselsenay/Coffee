using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lid : MonoBehaviour
{
    float offsetX;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = 4f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        
        if (!MoveCoffeeJar.instance.canDrag)
        {
            transform.position = new Vector3(transform.position.x + offsetX, 10, transform.position.z);
            transform.SetParent(null);
            MoveCoffeeJar.instance.canDrag = true;
        }
        
    }
}
