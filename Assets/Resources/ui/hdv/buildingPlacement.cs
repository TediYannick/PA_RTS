using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    public GameObject caserne; 
    private GameObject previewCaserne; 
    public LayerMask ignoreLayer; 

    void Update()
    {
        if (ButtonCaserne.isPlacing)
        {
            if (previewCaserne == null)
            {
              
                previewCaserne = Instantiate(caserne, Vector3.zero, Quaternion.identity);
                previewCaserne.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f); 
            }

           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~ignoreLayer))
            {
               
                previewCaserne.transform.position = hit.point + hit.normal * 0.5f;
            }

            if (Input.GetMouseButtonDown(0)) 
            {
               
                Instantiate(caserne, previewCaserne.transform.position, Quaternion.identity);
                ButtonCaserne.isPlacing = false;
                Destroy(previewCaserne); 
            }
        }
        else
        {
            if (previewCaserne != null && previewCaserne.activeSelf)
            {
                Destroy(previewCaserne);
            }
        }
    }
}
