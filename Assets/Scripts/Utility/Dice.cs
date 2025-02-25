using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dice
{
    public static int ThrowDice()
    {
        int random;
        random = Mathf.RoundToInt((Random.value*5)+1);
       
        return random;
    }
    public static int RandomizeCard(int ammount)
    {
        
        int random;
        if (ammount > 0)
        {
            random = UnityEngine.Random.Range(1, ammount);
            return random;
        }
        else
        {
            random = 0;
            return random;
        }
        
    }
    

    
}
