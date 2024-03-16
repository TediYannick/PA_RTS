using UnityEngine;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    
    public GameObject buildingMenu;

    public GameObject CaserneMenu;

    public CameraController CameraController;

  

    void Start()
    {
        
        Button button = GetComponent<Button>();

        
        button.onClick.AddListener(OnClick);
    }

    
    void OnClick()
    {
        
        buildingMenu.SetActive(false);
        CaserneMenu.SetActive(false);
        CameraController.EnabledCameraController();
    }
}
