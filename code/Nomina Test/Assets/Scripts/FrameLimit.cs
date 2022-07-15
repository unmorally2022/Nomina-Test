using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrameLimit : MonoBehaviour
{

    [SerializeField]
    GameObject LimitTop, LimitLeft, LimitRight;
    void Start()
    {
        Camera cam = Camera.main;
        Vector3 point = new Vector3();
        point = cam.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height, cam.nearClipPlane));
        point.y += 0.5f; point.z = 0;
        //LimitTop = GameObject.CreatePrimitive(PrimitiveType.Cube);
        LimitTop.transform.position = point;

        point = cam.ScreenToWorldPoint(new Vector3(0, Screen.height/2, cam.nearClipPlane));
        point.x -= 0.5f; point.z = 0;
        //LimitLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        LimitLeft.transform.position = point;

        point = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height/2, cam.nearClipPlane));
        point.x += 0.5f; point.z = 0;
        //LimitRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        LimitRight.transform.position = point;


    }

    void OnGUI()
    {
        
    }
}
