using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Talia : MonoBehaviour
{
    public List<AdventureCard> talia;
    public AdventureCard RandomCard()
    {
        return talia[Random.Range(0, talia.Count)];
    }
    public AdventureCard GetCard()
    {
        var prefab = RandomCard();
        var card = Instantiate(prefab);
        return card;
    }
    /*
    public static Dictionary<int,AdventureCard> FindAllCards()
    {
        
        Dictionary<int,AdventureCard> stack = new Dictionary<int, AdventureCard>();
        var dCards = Resources.FindObjectsOfTypeAll<DangerousOpponent>();
        //var karty = Resources.LoadAll<AdventureCard>( "Assets / AdventureCards");
        int i = 0;
        foreach (var card in dCards)
        {
            if (card.typeCard == "DangerousOpponent")
            {
                //Debug.Log("xD3");

                stack.Add(i, card);
                Debug.Log(card.name);
                i++;
            }
        }
        var tCards = Resources.FindObjectsOfTypeAll<Treasure>();
        foreach (var card in tCards)
        {
            if (card.typeCard == "Treasure")
            {
                //Debug.Log("xD3");

                stack.Add(i, card);
                Debug.Log(card.name);
                i++;
            }
        }
        return stack;
    }
    */
    // Start is called before the first frame update
    void Start()
    {

        /*
       // Debug.Log("xD");
       Dictionary<int,AdventureCard> talia = new Dictionary<int, AdventureCard>();
       DangerousOpponent wybranaKartaPrzeciwnika;
       Treasure wybranaKartaStatystyk;
       talia = FindAllCards();
       foreach (var card in talia)
       {
           if (card.Value.typeCard == "DangerousOpponent")
           {
               wybranaKartaPrzeciwnika = (DangerousOpponent)card.Value;
               //Debug.Log("xD2");
               Debug.Log(wybranaKartaPrzeciwnika.name);
               Debug.Log(wybranaKartaPrzeciwnika.agility);
           }
           if(card.Value.typeCard == "Treasure")
           {
               wybranaKartaStatystyk = (Treasure)card.Value;
               Debug.Log(wybranaKartaStatystyk.name);
               Debug.Log(wybranaKartaStatystyk.healthPoints);
           }
       }
*/
    }
         
   /* public AdventureCard GetCard()
    {
        Dictionary<int, AdventureCard> talia = new Dictionary<int, AdventureCard>();
        //DangerousOpponent wybranaKartaPrzeciwnika;
        //Treasure wybranaKartaStatystyk;
        talia = FindAllCards();
        int numerKarty = Dice.RandomizeCard(talia.Count);    
        foreach (var card in talia)
        {
            //Debug.Log(card.Key);
            if (card.Key+1 == numerKarty)
            {
                return card.Value;
            }

        }
        throw new UnityException("B³¹d");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
   */
}
