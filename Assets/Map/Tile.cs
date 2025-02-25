using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class Tile : MonoBehaviour
{
    //DEBUG
    public static Tile debugTile;
    //DEBUG END
    public TileDescription description;
    public Map map;
    public Vector3Int position;
    public int ringNumber;
    public GameObject spotLight;
    public List<Tile> additionalNeighbours;
    public TileInteractions.TilesTypes tileProperties;
    

    private bool isSelectable = false;

    public bool IsSelectable
    {
        get
        {
           return isSelectable;
        }
        set
        {
            isSelectable = value;
            spotLight.SetActive(value);
        }
    }
    private void Awake()
    {
        Debug.Assert(description != null, "Tile has no description, please supply a description to all tiles");
        Debug.Assert(description.name != "default name", "Tile has a placeholder description");
    }

    private void OnMouseEnter()
    {
        TileInspector.singleton.SetTarget(this);
        debugTile = this;
    
    }
    public void OnMouseDown()
    {
        if(true)
        {
            if(IsSelectable)
            {
                GameMaster.Instance.SelectTile(this);
            }
        }
    }
    public void DebugTest()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            List<Tile> list = GetNeighbours();
            Debug.Log($"My position: {position} Neighbours: \n s1:{list[0].position},  s2:{list[1].position}");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            int move = Dice.ThrowDice();
            Debug.Log($"Roll:{move}");
            Debug.Log("posible moves:");
            foreach (Tile tile in map.MoveCalculator(this, move))
            {
                Debug.Log(tile.position);
            }
        }
    }
    private void OnMouseExit()
    {
        TileInspector.singleton.ResetTarget();
        debugTile= null;
    }
    public List<Tile> GetNeighbours()
    {
        List <Tile> tilesNeighbors = new List<Tile>();
        foreach (Tile tile in additionalNeighbours)
        {
            tilesNeighbors.Add(tile);
        }
        if (System.Math.Abs(position.x) == System.Math.Abs(position.z))
        {
            Tile n1 = map.Rings[ringNumber][new Vector3Int(position.x - System.Math.Sign(position.x), position.y, position.z )];
            Tile n2 = map.Rings[ringNumber][new Vector3Int(position.x, position.y, position.z - System.Math.Sign(position.z))];
            tilesNeighbors.Add(n1);
            tilesNeighbors.Add(n2);
            return tilesNeighbors; 
        }
        if (System.Math.Abs(position.x)==ringNumber)
        {
            Tile n1 = map.Rings[ringNumber][new Vector3Int(position.x, position.y, position.z + 1)];
            Tile n2 = map.Rings[ringNumber][new Vector3Int(position.x, position.y, position.z - 1)];
            tilesNeighbors.Add(n1); 
            tilesNeighbors.Add(n2);
        }
        if (System.Math.Abs(position.z) == ringNumber)
        {
            Tile n1 = map.Rings[ringNumber][new Vector3Int(position.x+1, position.y, position.z)];
            Tile n2 = map.Rings[ringNumber][new Vector3Int(position.x-1, position.y, position.z)];
            tilesNeighbors.Add(n1);
            tilesNeighbors.Add(n2);
        }
        return tilesNeighbors;
    }
    private void OnDrawGizmos()
    {
        foreach (Tile tile in additionalNeighbours)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, tile.transform.position);
        }
    }
}
