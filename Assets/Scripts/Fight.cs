using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;

public class Fight
{ 
    public UnityEvent FightEnded;

    private PlayerCard playerCard;
    private DangerousOpponent dangerousOpponent;
    
    public Fight(PlayerCard player, DangerousOpponent opponent)
    {
        playerCard = player;
        dangerousOpponent = opponent;
    }
    public void Start()
    {
        
        Debug.Log($"walka {playerCard}, {dangerousOpponent.cardName},");
        int mocGracza;
        int mocPrzeciwnika;
        var playerStats = GameMaster.Instance.currentPlayer.stats;
        string mainParameters = dangerousOpponent.stats.CheckHighestParameters();
        mocGracza = (int)playerStats.GetValueByName(mainParameters);
        mocPrzeciwnika = (int)dangerousOpponent.stats.GetValueByName(mainParameters);
        FightUI.Instance.SetPlayerProperty(); 
        FightUI.Instance.SetOpponentProperty(dangerousOpponent.cardName, dangerousOpponent.stats);
        FightUI.Instance.SetMainParameters(mocGracza, mocPrzeciwnika);

        

        mocGracza = PlayerThrowDice(mocGracza);
        mocPrzeciwnika = OpponentThrowDice(mocPrzeciwnika);

        playerStats.Health -= Mathf.Clamp(mocPrzeciwnika - mocGracza,0,float.PositiveInfinity);
        if(mocGracza-mocPrzeciwnika > 0)
        {
            playerStats.Gold += 1;
        }    
        FightEnded?.Invoke();
        GameMaster.Instance.EndFight();
    }
    /*public string CheckHighestParameters()
    {
        var max = Mathf.Max(dangerousOpponent.strenght, dangerousOpponent.agility, dangerousOpponent.intelligence);
        if (max == dangerousOpponent.strenght) return nameof(dangerousOpponent.strenght);
        if (max == dangerousOpponent.agility) return nameof(dangerousOpponent.agility);
       
        return nameof(dangerousOpponent.intelligence);
        
    }
    */
    public int PlayerThrowDice(int mocGracza)
    {
        int wynik = Dice.ThrowDice();
        FightUI.Instance.SetIconsOnPlayerDice(wynik);
        wynik += mocGracza;
        FightUI.Instance.SetPlayerSummaryScore(wynik);
        return wynik;
    }
    public int OpponentThrowDice(int mocPrzeciwnika)
    {
        int wynik = Dice.ThrowDice();
        FightUI.Instance.SetIconsOnOpponentDice(wynik);
        wynik += mocPrzeciwnika;
        FightUI.Instance.SetOpponentSummaryScore(wynik);
        return wynik;
    }
    

}
