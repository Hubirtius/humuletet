using System;
using System.Diagnostics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public UnityEvent OnChange = new UnityEvent();

    [SerializeField]
    private float gold;
    public float Gold 
    {
        get => gold; 
        set
        {
            gold = value;
            OnChange.Invoke();
        }
    }
    [SerializeField]
    private float health;
    public float Health 
    { 
        get => health; 
        set
        {
            health = value;
            OnChange.Invoke();
        }
    }
    [SerializeField]
    private float strenght;
    public float Strength 
    { 
        get => strenght; 
        set 
        {
            strenght = value;
            OnChange.Invoke();
        } 
    }
    [SerializeField]
    private float agility;
    public float Agility 
    {
        get => agility; 
        set 
        {
            agility = value;
            OnChange.Invoke();
        }
    }
    [SerializeField]

    private float inteligence;
    public float Inteligence
    {
        get => inteligence; set
        {
            inteligence = value;
            OnChange.Invoke();
        }
    }
    
    public float GetValueByName(string name) => name switch
        {

            "inteligence" => Inteligence,               // Kurwa switch XD
            "strenght" => Strength,
            _ => Agility
        };
    public string CheckHighestParameters()
    {
        var max = Mathf.Max(strenght, agility, inteligence);
        if (max == strenght) return nameof(strenght);
        if (max == agility) return nameof(agility);

        return nameof(inteligence);

    }

}
