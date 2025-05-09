using System.Runtime.Serialization.Formatters;
using UnityEditor.Rendering;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    static public Vector3 worldPrevFrame;
    static public Vector3 mouseDelta;
    static public Vector3 worldCurrFrame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //mouse button is down display position
        if(Input.GetMouseButton(0)) 
        {
            worldCurrFrame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDelta = worldPrevFrame - worldCurrFrame;
            worldPrevFrame = worldCurrFrame;
           
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            worldCurrFrame = Vector3.zero;
            mouseDelta = Vector3.zero;
            worldPrevFrame = Vector3.zero;

        }
       // Debug.Log("current Position " + worldCurrFrame);
    }
}
