using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPathVisualiser : MonoBehaviour
{
    public LineRenderer lineRendererPrefab;
    public List<Gradient> gradients = new List<Gradient>();
    public Vector3 offset = Vector3.zero;

    private List<LineRenderer> spawnedRenderers = new List<LineRenderer>();

    private void Awake()
    {
        foreach(Gradient gradient in gradients)
        {
            SpawnPath(gradient);
        }
    }


    public void SetPaths(List<List<Tile>> paths)
    {
        HideAllRenderers();
        for(int i = 0; i < paths.Count; i++)
        {
            SetPath(i, paths[i]);
        }
    }

    private void SpawnPath(Gradient gradient)
    {
        LineRenderer myRenderer = Instantiate(lineRendererPrefab.gameObject).GetComponent<LineRenderer>();
        myRenderer.colorGradient = gradient;
        spawnedRenderers.Add(myRenderer);
        myRenderer.enabled = false;
    }

    private void SetPath(int index, List<Tile> path)
    {
        LineRenderer myRenderer = spawnedRenderers[index];
        myRenderer.enabled = true;

        Vector3[] positions = new Vector3[path.Count];
        for (int i = 0; i < path.Count; i++)
        {
            positions[i] = path[i].position + offset;
        }

        myRenderer.positionCount = positions.Length;
        myRenderer.SetPositions(positions);
    }

    public void HideAllRenderers()
    {
        foreach(var renderer in spawnedRenderers)
        {
            renderer.enabled = false;
        }
    }
}
