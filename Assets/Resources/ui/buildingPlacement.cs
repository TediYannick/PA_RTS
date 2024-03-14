using UnityEngine;

public class PlaceCube : MonoBehaviour
{
    public GameObject cubePrefab; // Assurez-vous d'assigner ici aussi le prefab de votre cube
    private GameObject previewCube; // Référence au cube de prévisualisation
    public LayerMask ignoreLayer; // LayerMask pour ignorer le cube

    void Update()
    {
        if (ButtonCaserne.isPlacing)
        {
            if (previewCube == null)
            {
                // Instancier le cube de prévisualisation
                previewCube = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
                previewCube.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f); // Réduire l'opacité
            }

            // Mettre à jour la position de la prévisualisation en fonction du curseur de la souris
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~ignoreLayer))
            {
                // Calculer la position de la prévisualisation en fonction de la normale de la surface
                previewCube.transform.position = hit.point + hit.normal * 0.5f;
            }

            if (Input.GetMouseButtonDown(0)) // 0 pour le clic gauche de la souris
            {
                // Place le cube à la position de la prévisualisation
                Instantiate(cubePrefab, previewCube.transform.position, Quaternion.identity);
                ButtonCaserne.isPlacing = false; // Désactive le mode placement
                Destroy(previewCube); // Détruire la prévisualisation
            }
        }
        else
        {
            if (previewCube != null && previewCube.activeSelf)
            {
                // Supprimer la prévisualisation s'il n'est pas en mode placement
                Destroy(previewCube);
            }
        }
    }
}
