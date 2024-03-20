using UnityEngine;
using UnityEngine.UI;

public class ButtonDPS : MonoBehaviour
{
    public GameObject DPS;
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
        Instantiate(DPS, casernePosition, Quaternion.identity);
        CaserneMenu.SetActive(false);

    }

}
