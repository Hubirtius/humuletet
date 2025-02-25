using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Tile> generationPrefabs = new List<Tile>();

    [SerializeField, HideInInspector] GenericDictionary<Vector3Int, Tile>[] rings;

    public GenericDictionary<Vector3Int, Tile>[] Rings { get => rings; }

    private void Awake()
    {
        for (int i = 0; i < Rings.Length; i++)
        {


            foreach (KeyValuePair<Vector3Int, Tile> kvp in Rings[i])
            {
                kvp.Value.map = this;
                kvp.Value.position = kvp.Key;
                kvp.Value.ringNumber = i;
            }
        }
    }
/*
    public void Editor_SpawnMap()
    {
        if (transform.childCount > 0)
        {
            Debug.LogWarning("Map is not empty, remove all children of this component to confirm erasing the map");
            return;
        }

        rings = new GenericDictionary<Vector3Int, Tile>[generationPrefabs.Count];

        for (int i = 0; i < generationPrefabs.Count; i++)
        {
            Rings[i] = new GenericDictionary<Vector3Int, Tile>();

            foreach (Vector3Int pos in MapHelper.GenerateRingCoordinates(i))
            {
                Tile tile = (PrefabUtility.InstantiatePrefab(generationPrefabs[i].gameObject) as GameObject).GetComponent<Tile>();
                tile.transform.position = pos;
                tile.transform.parent = transform;
                Rings[i].Add(pos, tile);
            }
        }
    }
*/
    public void DisableAllSelectable()
    {
        foreach(GenericDictionary<Vector3Int,Tile> ring in rings)
        {
            foreach(Tile tile in ring.Values)
            {
                tile.IsSelectable= false;
            }    
        }
    }

    public List<Tile> MoveCalculator(Tile startingTile, int lenght)
    {
        List<Tile> listCalculator = new List<Tile>();
        Queue<Tile> queue = new Queue<Tile>();
        Queue<Tile> nextQueue = new Queue<Tile>();
        List<Tile> checkedTiles = new List<Tile>();
        checkedTiles.Add(startingTile);
        queue.Enqueue(startingTile);
        for (int i=0;i<lenght;i++)
        {
            while(queue.Count>0)
            {
                Tile neighbour = queue.Dequeue();
                foreach(Tile tile in neighbour.GetNeighbours())
                {
                    if(!checkedTiles.Contains(tile))
                    {
                        nextQueue.Enqueue(tile);
                        checkedTiles.Add(tile);
                    }    
                }
            }
            queue =  nextQueue;
            nextQueue= new Queue<Tile>();
              
        }
           listCalculator = queue.ToList();
       
        return listCalculator;
    }

    public List<List<Tile>> GetPathsFromTileInRange(Tile startingTile, int range)
    {
        List<TilePath> paths = new List<TilePath>();

        List<TilePath> addNext = new List<TilePath>();
        List<TilePath> removeNext = new List<TilePath>();

        paths.Add(new TilePath(startingTile, startingTile));

        for(int i = 0; i < range; i++)
        {
            foreach(TilePath path in paths)
            {
                if(path.finished)
                {
                    continue;
                }

                List<Tile> allNeighbours = path.current.GetNeighbours();
                List<Tile> neighbours = new List<Tile>();
                // prune already visited
                foreach(Tile tile in allNeighbours)
                {
                    if(!path.tilesChecked.Contains(tile))
                    {
                        neighbours.Add(tile);
                    }
                }

                // finish if no more valid neighbours
                if(neighbours.Count == 0)
                {
                    path.finished = true;
                    continue;
                }

                // if only one valid, step
                if(neighbours.Count == 1)
                {
                    path.tilesChecked.Add(neighbours[0]);
                    path.current = neighbours[0];
                }

                //if more than one valid, branch
                if(neighbours.Count > 1)
                {
                    foreach(Tile neighbour in neighbours)
                    {
                        TilePath newPath = path.Copy(); 

                        newPath.tilesChecked.Add(neighbour);
                        newPath.current = neighbour;

                        addNext.Add(newPath);
                    }

                    removeNext.Add(path);
                }
            }
            foreach (TilePath path in removeNext)
            {
                paths.Remove(path);
            }
            removeNext.Clear();
            foreach(TilePath path in addNext)
            {
                paths.Add(path);
            }
            addNext.Clear();
        }

        List<List<Tile>> justPaths = new List<List<Tile>>();
        foreach(TilePath path in paths)
        {
            justPaths.Add(path.tilesChecked);
        }

        return justPaths;
    }

    internal class TilePath
    {
        public Tile start;
        public List<Tile> tilesChecked;
        public Tile current;
        public bool finished;

        public TilePath(Tile start, Tile current)
        {
            tilesChecked = new List<Tile>();
            tilesChecked.Add(current);
            this.current = current;
            this.start = start;
            finished = false;
        }

        public TilePath() { }

        public TilePath Copy()
        {
            return new TilePath()
            {
                tilesChecked = new List<Tile>(tilesChecked),
                current = current,
                finished = finished,
                start = start
            };
        }
    }
}
