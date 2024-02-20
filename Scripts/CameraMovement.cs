using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mainSpeed = 0.03f;
    float zoomSpeed = 10.0f;
    float rotationSpeed;

    float maxHeight = 2.5f;
    float minHeight = 1.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mainSpeed = 0.06f;
            zoomSpeed = 20.0f;
        }
        else
        {
            mainSpeed = 0.03f;
            zoomSpeed = 10.0f;
        }
        
        float horiScrollSpeed = transform.position.y * mainSpeed * Input.GetAxis("Horizontal");
        float vertScrollSpeed = transform.position.y * mainSpeed * Input.GetAxis("Vertical");
        float scrollSpeed = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        if ((transform.position.y >= maxHeight)&&(scrollSpeed>0))
        {
            scrollSpeed = 0;
        }
        else if ((transform.position.y <= minHeight)&&(scrollSpeed<0))
        {
            scrollSpeed = 0;
        }

        if ((transform.position.y + scrollSpeed) > maxHeight)
        {
            scrollSpeed = maxHeight - transform.position.y;
        }
        else if ((transform.position.y + scrollSpeed) < minHeight)
        {
            scrollSpeed = minHeight - transform.position.y;
        }
        Vector3 vertScroll = new Vector3(0, scrollSpeed, 0);
        Vector3 ltrlScroll = horiScrollSpeed * transform.right;
        Vector3 fowardScroll = transform.forward;
        fowardScroll.y = 0;
        fowardScroll.Normalize();
        fowardScroll *= vertScrollSpeed;

        Vector3 scrollMovement = vertScroll + ltrlScroll + fowardScroll;

        transform.position += scrollMovement;


    }
}
