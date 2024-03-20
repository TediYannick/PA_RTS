using UnityEngine;
using UnityEngine.UI;

public class ButtonHeal : MonoBehaviour
{
    public GameObject heal;
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
        Instantiate(heal, casernePosition, Quaternion.identity);
        CaserneMenu.SetActive(false);

    }

}
