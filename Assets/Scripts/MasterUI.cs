using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MasterUI : MonoBehaviour
{
    public GameObject panelFightUi;
    public GameObject panelWin;
    public GameObject panelLose;
   // public GameObject restartButtonW;
   // public GameObject restartButtonL;
    public RawImage iconDiceResult;

    private static MasterUI _instance;
    private MasterUI()
    {

    }

    public static MasterUI Instance
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

    public void PanelFightUIOn()
    {
        
       
            panelFightUi.SetActive(true);
       
    }
    public void PanelFightUIOff()
    {
        
       
            panelFightUi.SetActive(false);
        
    }
    public void WinTheGame()
    {
        
        panelWin.SetActive(true);
        
    }
    public void DidntWinGame() 
    {
        panelLose.SetActive(true);
        
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResultIconOnDiceThrow(int diceResult)
    {
        Texture2D result = DiceIcons.Instance.GetDiceTexture(diceResult);
        iconDiceResult.texture = result;
    }  
    public void ClearDiceIcon()
    {
        Texture2D texture = DiceIcons.Instance.GetDiceTexture(0);
        iconDiceResult.texture = texture;
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
