using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f; // Vitesse de défilement de la molette de la souris
    public float edgeScrollSpeed = 20f;  // Vitesse de déplacement de la caméra lorsque le pointeur atteint le bord de l'écran
    public float edgeScrollZoneSize = 50f; // Taille de la zone sensible aux bords de l'écran
    public float pinchZoomSensitivity = 0.1f;
    public float touchMovementSensitivity = 0.5f;

    private Vector2 previousTouchPosition1;
    private Vector2 previousTouchPosition2;

    void Update()
    {
        if (IsMobilePlatform())
        {
            HandleMobileInput();
        }
        else
        {
            HandlePCInput();
        }
    }

    bool IsMobilePlatform()
    {
        return Application.isMobilePlatform;
    }

    void HandlePCInput()
    {
        // Contrôle de défilement de la molette de la souris
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, scroll * scrollSpeed, Space.Self);

        // Contrôle de déplacement de la caméra lorsque le pointeur atteint le bord de l'écran
        Vector3 mousePosition = Input.mousePosition;
        Vector3 move = Vector3.zero;

        if (mousePosition.x < edgeScrollZoneSize)
        {
            move += Vector3.left * edgeScrollSpeed * Time.deltaTime;
        }
        else if (mousePosition.x > Screen.width - edgeScrollZoneSize)
        {
            move += Vector3.right * edgeScrollSpeed * Time.deltaTime;
        }

        if (mousePosition.y < edgeScrollZoneSize)
        {
            move += Vector3.back * edgeScrollSpeed * Time.deltaTime;
        }
        else if (mousePosition.y > Screen.height - edgeScrollZoneSize)
        {
            move += Vector3.forward * edgeScrollSpeed * Time.deltaTime;
        }

        transform.Translate(move, Space.World);
    }

    void HandleMobileInput()
    {
        //déplacement de la camera 
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {

                Vector2 deltaPosition = touch.deltaPosition;
                transform.Translate(-deltaPosition.x * touchMovementSensitivity * Time.deltaTime, 0, -deltaPosition.y * touchMovementSensitivity * Time.deltaTime, Space.World);

            }
        }

        //zoom
        else if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            transform.Translate(0, 0, -deltaMagnitudeDiff * pinchZoomSensitivity * Time.deltaTime, Space.Self);
        }
    }
}
