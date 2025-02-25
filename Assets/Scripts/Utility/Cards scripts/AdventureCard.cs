using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdventureCard : ScriptableObject
{
    public int cardId;
    public string typeCard;
    public string cardName;
    public string cardDescription;
    public int cardPriority;
    [HideInInspector]
    public PlayerCard owner;

    public void Activate()
    {
        OnActivate();
    }
    protected abstract void OnActivate();
    

}