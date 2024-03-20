using UnityEngine;

public class CaserneMenuOpener : MonoBehaviour 
{
    public GameObject Caserne; 
    public GameObject CaserneMenu;  
    public CameraController CameraController;
    public ButtonDPS ButtonDPS;
    public ButtonTank ButtonTank;
    public ButtonHeal ButtonHeal;
    

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
                    ButtonDPS.casernePosition = Caserne.transform.position;
                    ButtonTank.casernePosition = Caserne.transform.position;
                    ButtonHeal.casernePosition = Caserne.transform.position;
                    CaserneMenu.SetActive(true);
                    CameraController.DisableCameraController();
                
                }
            }
        }
    }
}
