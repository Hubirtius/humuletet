using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Treasure Adventure Card")]
public class Treasure : AdventureCard
{
    public static string typeOfCard = "treasure";
    public int gold;
    public int strenght;
    public int agility;
    public int inteligence;
    public int healthPoints;

    private SetText setName;
    private SetText setDescription;
    //private PlayerCard pc = new PlayerCard();
    //private PlayerCard pc = ScriptableObject.CreateInstance<PlayerCard>();



    protected override void OnActivate()
    {
        setName = GameObject.FindGameObjectWithTag("CardName").GetComponent<SetText>();
        setName.ChangeText(cardName);
        setDescription = GameObject.FindGameObjectWithTag("CardDescription").GetComponent<SetText>();
        setDescription.ChangeText(cardDescription);


        owner.stats.Gold += (float)gold;
        owner.stats.Health += (float)healthPoints;
        owner.stats.Strength += (float)strenght;
        owner.stats.Agility += (float)agility;
        owner.stats.Inteligence += (float)inteligence;
        //owner.AddSomeStatistic(gold = Gold,);
        //Debug.Log("Test" + healthPoints);
    }
}
