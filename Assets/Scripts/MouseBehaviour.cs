
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    float deltaTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButton (0)) {
            if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
                if (hit.transform.gameObject.tag == "DeformableMesh") {
                    hit.transform.GetComponent<MeshDeformer> ().Deform (hit.point, 0.15f, 0.1f, -0.15f, -0.2f, hit.barycentricCoordinate);
                }
            }
        }
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (Input.GetAxisRaw("Horizontal")<0f)
        {
            transform.Rotate(0f, -1f, 0f,Space.World);
        }
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            transform.Rotate(0f, 1f, 0f, Space.World);
        }
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            transform.Translate(0f, 0f, -0.1f, Space.World);
        }
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            transform.Translate(0f, 0f, 0.1f, Space.World);
        }

    }
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
