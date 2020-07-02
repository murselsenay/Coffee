using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcosphereBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    /* Deforms this mesh
      point: The point from which deformation of the mesh starts
      radius: The maximum radius to which the deformation affects
      stepRadius: The small step value of the maximum radius
  
   */
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButton (0)) {
            if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                if (hit.transform.gameObject.tag == "DeformableMesh") {
                                                             //Deform(Vector3 point, float radius, float stepRadius)
                    hit.transform.GetComponent<MeshDeformer>().Deform (hit.point, 0.25f, 0.01f);
                }
            }
        }
    }
}