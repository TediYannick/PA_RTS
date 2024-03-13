using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHandle : MonoBehaviour
{
    public CombatUnit _unit;
    public Transform unitParent;
    void Start()
    {
        GameObject unit = Instantiate(_unit.unitPrefab, transform.position, Quaternion.identity, unitParent);
    }
}
