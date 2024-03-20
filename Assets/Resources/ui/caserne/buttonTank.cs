using UnityEngine;
using UnityEngine.UI;

public class ButtonTank : MonoBehaviour
{
    public GameObject tank;
    public GameObject CaserneMenu;
    public CameraController CameraController;
    public Vector3 casernePosition; 

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

   void OnClick()
    {    
        CameraController.EnabledCameraController();
        Instantiate(tank, casernePosition, Quaternion.identity);
        CaserneMenu.SetActive(false);

    }

}
