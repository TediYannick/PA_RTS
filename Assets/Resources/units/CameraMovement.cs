using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f; // Vitesse de défilement de la molette de la souris et du zoom par pincement
    public float dragSpeed = 20f; // Vitesse de déplacement de la caméra lors du glissement à la souris ou au doigt

    private Vector3 dragOrigin;
    private float initialTouchDistance;
    private Vector3 initialCameraPosition;
    private bool isDragging = false;

    void Update()
    {
        // Contrôle de défilement de la molette de la souris
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // Ajustez ici si vous voulez que le zoom avant/arrière soit influencé par l'angle
        transform.Translate(0, 0, scroll * scrollSpeed, Space.Self);

        // Contrôle de déplacement de la caméra avec le clic de la souris ou le toucher
        if (Input.GetMouseButtonDown(2) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (Input.touchCount == 1)
            {
                dragOrigin = Input.GetTouch(0).position;
            }
            else
            {
                dragOrigin = Input.mousePosition;
            }
            isDragging = true;
        }

        if (isDragging && (Input.GetMouseButton(2) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)))
        {
            Vector3 currentPos;
            if (Input.touchCount == 1)
            {
                currentPos = Input.GetTouch(0).position;
            }
            else
            {
                currentPos = Input.mousePosition;
            }

            Vector3 pos = Camera.main.ScreenToViewportPoint(currentPos - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

            // Ajustement pour tenir compte de la rotation de la caméra
            Vector3 forward = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;
            Vector3 right = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.right;
            move = pos.x * dragSpeed * right + pos.y * dragSpeed * forward;

            // Appliquer le mouvement
            transform.Translate(-move, Space.World);
        }

        if (Input.GetMouseButtonUp(2) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            isDragging = false;
        }

        // Contrôle de zoom par pincement
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            transform.Translate(0, 0, deltaMagnitudeDiff * scrollSpeed * Time.deltaTime, Space.Self);
        }
    }
}
