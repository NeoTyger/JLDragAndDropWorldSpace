using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCastGrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = 6f;
            
            Debug.Log(Input.mousePosition);
            Debug.Log(Camera.main.ScreenToWorldPoint(mouseScreenPos));
            
            Vector3 rayOrigin = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            Vector3 rayDirection = Vector3.forward;
            Ray ray = new Ray(rayOrigin, rayDirection);
            Debug.DrawRay(rayOrigin, rayDirection, Color.green);

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
                {
                    if (hitInfo.transform.name.Contains("Sphere"))
                    {
                        hitInfo.transform.position = rayOrigin;
                    }
                }
            }
        }
    }
}
