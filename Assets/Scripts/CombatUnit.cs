using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "unitInstance", menuName = "Unit/Combat")]
public class CombatUnit : ScriptableObject
{
    public enum UnitType
    {
        Tank,
        DPS,
        Heal
    };
    public bool isPlayable;
    public string unitName;
    public UnitType type;
    public GameObject unitPrefab;

    public int cost;
    public int healthPoints;
    public int strength;
    public int armor;
}