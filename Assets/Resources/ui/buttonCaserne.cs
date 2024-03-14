using UnityEngine;
using UnityEngine.UI;

public class ButtonCaserne : MonoBehaviour
{
    public GameObject caserne;
    public static bool isPlacing = false;
    public GameObject buildingMenu;
    public CameraController CameraController;


    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        isPlacing = true;
        buildingMenu.SetActive(false);
        CameraController.EnabledCameraController();
    }
}
