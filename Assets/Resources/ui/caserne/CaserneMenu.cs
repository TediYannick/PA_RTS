using UnityEngine;

public class CaserneMenuOpener : MonoBehaviour 
{
    public GameObject Caserne; 
    public GameObject CaserneMenu;  
    public CameraController CameraController;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.transform.gameObject;

                if (objectHit == Caserne)
                {
                    CaserneMenu.SetActive(true);

                    CameraController.DisableCameraController();
                
                }
            }
        }
    }
}
