using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private PlayerStatTargets targets;
    public PlayerStats stats;
    
    
    private void Awake()
    {
        stats.OnChange.AddListener(UpdateStats);
        
    }

    public void UpdateStats()
    {
        targets.Update(stats);
    }
    /*
    public void AddSomeStatistic(int gold=0, int health = 0, int strenght = 0, int agility = 0, int intelligence = 0)
    {

        stats.Gold += (float)gold;
        stats.Health += (float)health;
        stats.Strength += (float)strenght;
        stats.Agility += (float)agility;
        stats.Inteligence += (float)intelligence;

    }
    */
    private IEnumerator Start()
    {
        yield return 1;
        stats.OnChange.Invoke();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            stats.Gold += 1f;
            stats.Health += 1f;
            stats.Strength += 1f;
            stats.Agility += 1f;
            stats.Inteligence += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            stats.Gold -= 1f;
            stats.Health -= 1f;
            stats.Strength -= 1f;
            stats.Agility -= 1f;
            stats.Inteligence -= 1f;
        }
    }
}

[System.Serializable]
public struct PlayerStatTargets
{
    public TextMeshProUGUI gold;
    public TextMeshProUGUI health;

    public TextMeshProUGUI strenght;
    public TextMeshProUGUI agility;
    public TextMeshProUGUI inteligence;

    public void Update(PlayerStats stats)
    {
        gold.text = stats.Gold.ToString();
        health.text = stats.Health.ToString();
        strenght.text = stats.Strength.ToString();
        agility.text = stats.Agility.ToString();
        inteligence.text = stats.Inteligence.ToString();
    }
}
