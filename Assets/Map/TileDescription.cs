using UnityEngine;

[CreateAssetMenu(fileName = "Tile Description", menuName = "Tile Description")]
public class TileDescription : ScriptableObject
{
    public string tileName;
    [TextArea(20, 20)] public string description;
}


