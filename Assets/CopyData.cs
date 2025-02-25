using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CopyData : MonoBehaviour
{
    public Transform target;
    private void OnValidate()
    {
        foreach(Transform child in transform)
        {
            Tile tile = target.GetChild(child.GetSiblingIndex()).GetComponent<Tile>();
            tile.name = child.name;
            tile.description= child.GetComponent<Tile>().description;

        }
    }
}
