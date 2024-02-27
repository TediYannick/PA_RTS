using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitSelectionManager.Instance.allUnitsList.Add(gameObject);
		//ajoute une unité dans la liste des unité selectionnées
    }

    private void onDestroy()
    {
        UnitSelectionManager.Instance.allUnitsList.Remove(gameObject);
		//retire une unité dans la liste des unité selectionnées
    }
    
}
