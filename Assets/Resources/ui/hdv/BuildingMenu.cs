using UnityEngine;

public class BuildingMenuOpener : MonoBehaviour 
{
    public GameObject hdv; // L'objet à cliquer(hdv)
    public GameObject BuildingMenu;  // Le menu à ouvrir lorsque l'objet est cliqué (buildingMenu)

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

                if (objectHit == hdv)
                {
                    BuildingMenu.SetActive(true);

                    CameraController.DisableCameraController();
                
                }
            }
        }
    }
}
