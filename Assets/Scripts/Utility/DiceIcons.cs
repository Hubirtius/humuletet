using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceIcons : MonoBehaviour
{
    public Texture2D dice1;
    public Texture2D dice2;
    public Texture2D dice3;
    public Texture2D dice4;
    public Texture2D dice5;
    public Texture2D dice6;
    public Texture2D dice0;

    private static DiceIcons _instance;

    private DiceIcons()
    {

    }

    public static DiceIcons Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            Debug.Assert(_instance == null, "FightUI already exists");
            _instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public Texture2D GetDiceTexture(int diceValue)
    {
        switch (diceValue)
        {
            case 1: return dice1;

            case 2: return dice2;

            case 3: return dice3;

            case 4: return dice4;

            case 5: return dice5;

            case 6: return dice6;

            default: return dice0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
