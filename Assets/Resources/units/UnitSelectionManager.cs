using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
   public static UnitSelectionManager Instance { get; set; }

   //liste des unités sélectionnées
   public List<GameObject> allUnitsList = new List<GameObject>();
   public List<GameObject> unitsSelected = new List<GameObject>();

   public LayerMask clickable;
   public LayerMask ground;
   public GameObject groundMarker;

   private Camera cam;
   private void Awake()  
   {
      if (Instance != null && Instance != this) 
         // Il ne peut y avoir que une instance de ce script
      {
         Destroy(gameObject);
      }
      else
      {
         Instance = this;
      }
   }

   public void Start()
   {
      cam = Camera.main;
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0)) // Action sur click gauche
      {
         RaycastHit hit;
         Ray ray = cam.ScreenPointToRay(Input.mousePosition);
         // Si le raycast touche un objet clickable 
         if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
         {
            if (Input.GetKey(KeyCode.LeftShift))//Shift+clic gauche pour la multisélection
            {
               MultiSelect(hit.collider.gameObject);
            }
            else
            {
               SelectByClicking(hit.collider.gameObject);
            }
         }
         // Si on le touche pas d'objet
         else
         {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
               DeselectAll();
            }

         }
      }

      if (Input.GetMouseButtonDown(1) && unitsSelected.Count >0)// pose une marque au sol sur click droit
      {
         RaycastHit hit;
         Ray ray = cam.ScreenPointToRay(Input.mousePosition);

         if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
         {
            groundMarker.transform.position = hit.point;
            groundMarker.SetActive(false);
            groundMarker.SetActive(true);
         }



      }
   }

   public void DeselectAll()//Déselectionne les unités
   {
      foreach (var unit in unitsSelected)
      {
         EnableUnitMovement(unit, false);
         SelectionIndicatorUp(unit, false);
      }
      unitsSelected.Clear();
   }
   private void SelectByClicking(GameObject unit)
      // Déselectionne les unités et ajoute celles qu'on sélectionne à la liste des unités selectinnées
   {
      DeselectAll();
      unitsSelected.Add(unit);
      SelectionIndicatorUp(unit, true);
      EnableUnitMovement(unit, true);
   }

   private void MultiSelect(GameObject unit)//Multiselection d'unité (je rapelle avec shift)
   {
      if (unitsSelected.Contains(unit) == false)
      {
         unitsSelected.Add(unit);
         SelectionIndicatorUp(unit, true);
         EnableUnitMovement(unit, true);
         //Si la liste ne contient pas l'unité l'ajoute à la liste et active son mouvement
      }
      else
      {
         EnableUnitMovement(unit, false);
         SelectionIndicatorUp(unit, false);
         unitsSelected.Remove(unit);
         //Si la liste contient l'unité la déselectionne 
      }
      
   }
   private void EnableUnitMovement(GameObject unit, bool shouldMove)//Active ou désactive le mouvement d'une unité
   {
      unit.GetComponent<UnitMovement>().enabled = shouldMove;
   }

   private void SelectionIndicatorUp(GameObject unit, bool Visible)// Active ou désactive l'indicateur de sélection
   {
      unit.transform.GetChild(0).gameObject.SetActive(Visible);
   }
	public void DragSelect(GameObject unit)
	{
		if(unitsSelected.Contains(unit) == false)
			{
				unitsSelected.Add(unit);
			SelectionIndicatorUp(unit, true);
				EnableUnitMovement(unit, true);
			}
	}
}
