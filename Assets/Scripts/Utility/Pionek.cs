using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pionek : MonoBehaviour
{
    public float moveDurationToPosition;
    public float speed;
    [SerializeField]private Tile tile;

    public Tile Tile { get => tile; set => tile = value; }

    private Vector3 someUp = new Vector3( 0.0f,0.1f,0.0f);

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Assert(tile != null);
        transform.position = tile.position + someUp;
    }
   

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,tile.position + someUp,speed*Time.deltaTime);
    }
    
}

/*
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1f * Time.deltaTime * speed, 0, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //if(transform.position.x)
            transform.Translate(1f * Time.deltaTime * speed, 0, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate( 0,0, -1f * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,0,1f * Time.deltaTime * speed, Space.World);
        }
        */