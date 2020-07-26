using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeDispanser : MonoBehaviour
{
    public float range = 1.5f;

    public GameObject espressoHolder;
    public static Light spotLight;
    // Start is called before the first frame update
    void Start()
    {
        spotLight = gameObject.transform.GetChild(2).GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToEspressoHolder = Vector3.Distance(transform.GetChild(1).position, espressoHolder.transform.GetChild(0).position);
        if (distanceToEspressoHolder < range)
        {
            ButtonScript.instance.canStartGrinding = true;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.GetChild(1).position, range);
    }
}
