using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Opponent Adventure Card")]
public class DangerousOpponent : AdventureCard
{
    public static string typeOfCard = "opponent";

    public string kindOfOpponent;
    public PlayerStats stats;
    
    private SetText setName;
    private SetText setDescription;
    



    protected override void OnActivate()
    {

        setName = GameObject.FindGameObjectWithTag("CardName").GetComponent<SetText>();
        setName.ChangeText(cardName);
        setDescription = GameObject.FindGameObjectWithTag("CardDescription").GetComponent<SetText>();
        setDescription.ChangeText(cardDescription);

    }
}
