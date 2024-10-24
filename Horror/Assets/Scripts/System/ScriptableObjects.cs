using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InventoryObject", order = 1)]
public class InventoryObject : ScriptableObject
{
    public string objectName;
    public int objectCount = 1;
    public Object objectPrefab;
}
