using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileInspectorUI : MonoBehaviour
{
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI descriptionField;

    public void SetTileData(Tile tile)
    {
        nameField.text = tile.description.tileName;
        descriptionField.text = tile.description.description;
    }
}
