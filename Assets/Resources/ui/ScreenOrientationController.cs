using UnityEngine;

public class ScreenOrientationController : MonoBehaviour
{
    void Start()
    {
        // Bloquer l'orientation en mode paysage
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
