using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mainSpeed = 0.03f;
    float zoomSpeed = 5.0f;
    float rotationSpeed = 1.0f;

    float maxHeight = 12.0f;
    float minHeight = 5.0f;

    private Vector2 mousePosOrigin;
    private Vector2 mousePos;
    
    float horiAxis;
    float vertAxis;
    private float zoomAxis;
    
    void Update()
    {
        //Bouger la caméra avec le clavier
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horiAxis = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horiAxis = 1f;
        }
        else
        {
            horiAxis = 0;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            vertAxis = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            vertAxis = -1f;
        }
        else
        {
            vertAxis = 0;
        }
        //Bouger la caméra avec la souris
        if (Input.GetMouseButtonDown(2))
        {
            mousePosOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            mousePos = Input.mousePosition;

            horiAxis = (mousePos - mousePosOrigin).x/30;
            vertAxis = (mousePos - mousePosOrigin).y/30;
        }
        
        //Acceleration du mouvement de la caméra avec la touche 'Shift'
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mainSpeed = 0.06f;
            zoomSpeed = 20.0f;
            rotationSpeed = 2.0f;
        }
        else
        {
            mainSpeed = 0.03f;
            zoomSpeed = 10.0f;
            rotationSpeed = 1.0f;
        }
        
        float horiScrollSpeed = transform.position.y * mainSpeed * horiAxis;
        float vertScrollSpeed = transform.position.y * mainSpeed * vertAxis;
        float scrollSpeed = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        //Limitation du zoom / Extrémités de l'altitude du caméra
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
        GetCameraRotation();
    }

    void GetCameraRotation()
    {
        float rotateAxis;
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.PageUp))
        {
            rotateAxis = -1 * rotationSpeed;
            transform.rotation *= Quaternion.Euler(new Vector3(0, rotateAxis, 0));
        }

        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.PageDown))
        {
            rotateAxis = 1 * rotationSpeed;
            transform.rotation *= Quaternion.Euler(new Vector3(0, rotateAxis, 0));
        }
    }
}
