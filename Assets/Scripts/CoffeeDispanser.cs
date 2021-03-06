﻿using System.Collections;
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
    void FixedUpdate()
    {
        float distanceToEspressoHolder = Vector3.Distance(transform.GetChild(1).position, espressoHolder.transform.position);
        if (distanceToEspressoHolder < range)
        {
            ButtonScript.instance.canStartGrinding = true;
            GrindedCoffeeTank.instance.minYLimit = 10f;
            GrindedCoffeeTank.instance.maxYLimit = 12f;
            GrindedCoffeeTank.instance.checkDispanserPosition = true;
            GrindedCoffeeTank.instance.dispanser = gameObject.transform.GetChild(1).gameObject;
        }
        else
        {
            ButtonScript.instance.canStartGrinding = false;
            GrindedCoffeeTank.instance.minYLimit = 10f;
            GrindedCoffeeTank.instance.maxYLimit = 12f;
            GrindedCoffeeTank.instance.checkDispanserPosition = false;
            GrindedCoffeeTank.instance.dispanser =null;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.GetChild(1).position, range);
    }
}
