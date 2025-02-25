using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TileInteractions : MonoBehaviour
{
    public enum TilesTypes
    { 
        DrawOneCard,
        DrawTwoCards, 
        DrawThreeCards,
        FightWithLastBoss
    }
    public Talia talia;
    public PlayerStats blackDragonStats;


    public AdventureCard DrawOneAdventuresCards()
    {
        DangerousOpponent dangerousOpponentChoosenCard;
        Treasure treasureChoosenCard;

      
        AdventureCard wybranaKarta = talia.GetCard();
        Debug.Log("wylosowana zosta³a:" + wybranaKarta.GetType());
        wybranaKarta.owner = GameMaster.Instance.currentPlayer;
        
        if( wybranaKarta is DangerousOpponent)
        {
            
            dangerousOpponentChoosenCard = (DangerousOpponent)wybranaKarta;
            Debug.Log("o statystykach:" + dangerousOpponentChoosenCard.stats.Agility);
            dangerousOpponentChoosenCard.Activate();
            
        }
        else if( wybranaKarta.typeCard == "Treasure")
        {
            treasureChoosenCard = (Treasure)wybranaKarta;
            treasureChoosenCard.Activate();
        }
        return wybranaKarta;
    }
    public void DrawTwoAdventuresCards()
    {

    }
    public void DrawThreeAdventuresCards()
    {

    }
    public DangerousOpponent FightWithBlackDragon()
    {
        
        DangerousOpponent blackDragon = ScriptableObject.CreateInstance<DangerousOpponent>();
        blackDragon.cardName = "Czarny Smok";
        blackDragon.stats = blackDragonStats;
        blackDragon.kindOfOpponent = "Dragon";
        blackDragon.cardId = 100;

        return blackDragon;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // debug.loh(karta.Gettype)
}
