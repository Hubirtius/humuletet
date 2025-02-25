using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInspector : MonoBehaviour
{
    public TileInspectorUI previewUI;
    private Tile target;

    public bool IsDisplaying
    {
        get
        {
            return target != null;
        }
    }

    public static TileInspector singleton;

    private void Awake()
    {
        Debug.Assert(singleton == null, "More than one tile inspectors are present");
        singleton = this;

        previewUI.gameObject.SetActive(false);
    }

    public void SetTarget(Tile target)
    {
        this.target = target;
        previewUI.gameObject.SetActive(true);
        previewUI.SetTileData(target);
    }

    public void ResetTarget()
    {
        this.target = null;
        previewUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(IsDisplaying)
        {
            previewUI.transform.position = Input.mousePosition;
        }
    }
}
