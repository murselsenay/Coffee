using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class MeshDeformer : MonoBehaviour
{
    // If checked normals of the mesh will be recalculated after every deformation
    public bool recalculateNormals;

    // If checked MeshCollider will be updated after every deformation
    public bool collisionDetection;

    Mesh mesh;
    MeshCollider meshCollider;
    List<Vector3> vertices;
    public GameObject sphere;
    public static MeshDeformer instance;
    Vector3 dir;
    public bool canDeform=false;
    // Start is called before the first frame update
    void Start()
    {
        getMeshInfos();
        instance = this;
    }
    public void getMeshInfos()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
        vertices = mesh.vertices.ToList();
    }
    /* Deforms this mesh
       point: The point from which deformation of the mesh starts
       radius: The maximum radius to which the deformation affects
       stepRadius: The small step value of the maximum radius
      
    */

    public void Deform(Vector3 point, float radius, float stepRadius)
    {
        if (canDeform)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                Vector3 vi = transform.TransformPoint(vertices[i]);
                float distance = Vector3.Distance(point, vi);
                dir = transform.position - vertices[i];
                for (float r = 0.0f; r < radius; r += stepRadius)
                {
                    if (distance < r)
                    {
                        Vector3 deformation = dir;
                        vertices[i] += transform.InverseTransformPoint(deformation);
                        break;
                    }
                }
              
            }
            
        }
        
        if (recalculateNormals)
            mesh.RecalculateNormals();

        if (collisionDetection)
        {
            meshCollider.sharedMesh = null;
            meshCollider.sharedMesh = mesh;
        }
        mesh.SetVertices(vertices);
    }
}