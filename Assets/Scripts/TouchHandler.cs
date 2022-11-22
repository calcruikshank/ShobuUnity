using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{


    void Update()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                RaycastHit2D hit = Physics2D.Raycast(t.position, -Vector2.up);

                if (hit.collider != null)
                {
                    Debug.Log(hit);
                }
            }
        }

        else
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, -Vector2.up);

            if (hit.collider != null)
            {
                Debug.Log(hit);
            }
        }
        
    }
}
