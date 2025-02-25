using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static class MapHelper
{
    public static Vector3Int[] GenerateRingCoordinates(int ring)
    {
        if(ring < 0)
        {
            Debug.LogError("Ring number cannot be lower than 0");
            return new Vector3Int[] { }; // return empty ring
        }

        if(ring == 0)
        {
            return new Vector3Int[] { new Vector3Int(0, 0, 0) };
        }


        Vector3Int[] ringCoordinates = new Vector3Int[ring * 8];


        for (int i = 0; i < ring * 2; i++)
        {
            // x on positive y
            ringCoordinates[i] = new Vector3Int(-ring + i, 0, ring);
        }

        for (int i = 0; i < ring * 2; i++)
        {
            // y on positive x
            ringCoordinates[(ring * 2 ) + i] = new Vector3Int(ring, 0, ring - i);
        }

        for (int i = 0; i < ring * 2; i++)
        {
            // x on negative y
            ringCoordinates[(ring * 4) + i] = new Vector3Int(ring - i, 0, -ring);
        }

        for (int i = 0; i < ring * 2; i++)
        {
            // y on negative x
            ringCoordinates[(ring * 6) + i] = new Vector3Int(-ring, 0, -ring + i);
        }

        return ringCoordinates;
    }
}
