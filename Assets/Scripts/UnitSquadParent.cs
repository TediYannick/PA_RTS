using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitSquadParent : MonoBehaviour
{
    private GameObject target_unit;
    private GameObject child_prefab;
    private List<GameObject> child_units;
    
    void Start()
    {
        child_units = new List<GameObject>();

        for (int i = 0; i < 6; i++)
        {
            Vector3 relative_spawn = new Vector3(i%4, 0.33f, i/4);
            GameObject temp_unit = Instantiate(child_prefab, transform.position + (relative_spawn * 3.0f), transform.rotation);
            //temp_unit.GetComponent<NavMeshAgent>().SetDestination(target_unit.GetComponent<UnitMovement>().hit.point);
            child_units.Add(temp_unit);
        }
    }
    
    void Update()
    {
        transform.position += (target_unit.transform.position - transform.position).normalized * 3.0f;
    }
}
