using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionHandler : MonoBehaviour
{
    public Transform cameraCoffeeSelectionPosition;
    public Transform cameraCoffeeGrindingPosition;
    float deltaTime = 0.0f;
    Vector3 startPosition;


    public static CameraPositionHandler instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        transform.position = cameraCoffeeSelectionPosition.position;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }
 


   /* void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f,1.0f, 1.0f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }*/
    public void GoToGrindingPosition()
    {

        StartCoroutine(GoToGrindingPositionCoroutine());
        transform.rotation = Quaternion.Euler(25, 0, 0);
    }


    public IEnumerator GoToGrindingPositionCoroutine()
    {
        
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / 2f;
            transform.position = Vector3.Lerp(startPosition, cameraCoffeeGrindingPosition.position, t);
            yield return null;
        }
    }
}
