using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f; // Vitesse de défilement de la molette de la souris
    public float edgeScrollSpeed = 20f; // Vitesse de déplacement de la caméra lorsque le pointeur atteint le bord de l'écran
    public float edgeScrollZoneSize = 500f; // Taille de la zone sensible aux bords de l'écran

    void Update()
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

        // Appliquer le mouvement
        transform.Translate(move, Space.World);
    }
}
