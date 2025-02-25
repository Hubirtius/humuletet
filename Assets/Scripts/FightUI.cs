using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class FightUI : MonoBehaviour
{
    private static FightUI _instance;

    public TextMeshProUGUI nazwaGracza;
    public TextMeshProUGUI nazwaPrzeciwnika;
    public TextMeshProUGUI streG;
    public TextMeshProUGUI agiG;
    public TextMeshProUGUI inteG;
    public TextMeshProUGUI streP;
    public TextMeshProUGUI agiP;
    public TextMeshProUGUI inteP;
    public TextMeshProUGUI sumaMocyG;
    public TextMeshProUGUI sumaMocyP;
    public TextMeshProUGUI podstawowaMocG;
    public TextMeshProUGUI podstawowaMocP;
    public RawImage kostkaGracza;
    public RawImage kostkaPrzeciwnika;
    


    private FightUI()
    {
        
    }

    public static FightUI Instance
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
   
    public void SetOpponentProperty(string name, PlayerStats stats)
    {
        nazwaPrzeciwnika.SetText(name);
        streP.SetText("Si³a: " + stats.Strength);
        agiP.SetText("Zrêcznoœæ: " + stats.Agility);
        inteP.SetText("Inteligencja: " + stats.Inteligence);
        //string originalName;
        // originalName = nazwaGracza.name;
        // nazwaGracza.SetText(originalName);


    }
    public void SetPlayerProperty()
    {
        streG.SetText("Si³a: " + GameMaster.Instance.currentPlayer.stats.Strength);
        agiG.SetText("Zrêcznoœæ: " + GameMaster.Instance.currentPlayer.stats.Agility);
        inteG.SetText("Inteligencja: " + GameMaster.Instance.currentPlayer.stats.Inteligence);
    }
    public void SetMainParameters(int playerMainParameter,int opponentMainParameter)
    {
        podstawowaMocG.SetText("Podstawowa moc: " + playerMainParameter);
        podstawowaMocP.SetText("Podstawowa moc: " + opponentMainParameter);
    }
    public void SetIconsOnPlayerDice(int diceValue)
    {
        Texture2D icon = DiceIcons.Instance.GetDiceTexture(diceValue);
        kostkaGracza.texture = icon; 
    }
    public void SetIconsOnOpponentDice(int diceValue)
    {
        Texture2D icon = DiceIcons.Instance.GetDiceTexture(diceValue);
        kostkaPrzeciwnika.texture = icon;
    }
    public void SetPlayerSummaryScore(int sumaWynikuGracza)
    {
        sumaMocyG.SetText("Koñcowy Wynik: " + sumaWynikuGracza);
    }
    public void SetOpponentSummaryScore(int sumaWynikuPrzeciwnika)
    {
        sumaMocyP.SetText("Koñcowy Wynik: " + sumaWynikuPrzeciwnika);
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
