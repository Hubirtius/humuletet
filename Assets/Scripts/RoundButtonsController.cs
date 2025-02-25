using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtonsController : MonoBehaviour
{
    public Button buttonThrowDice;
    public Button buttonConsiderTile;
    public Button buttonEndturn;
    // Start is called before the first frame update
    void Start()
    {
        GameMaster.Instance.tourStateChanged.AddListener(tralal);
    }
    public void tralal(GameMaster.TourState state)
    {
        switch (state)
        {
            case GameMaster.TourState.PickTile:
                buttonThrowDice.interactable = false;
                buttonConsiderTile.interactable = false;
                buttonEndturn.interactable = false;
                break;
            case GameMaster.TourState.DiceThrow:
                buttonThrowDice.interactable = true;
                buttonConsiderTile.interactable = false;
                buttonEndturn.interactable = false;
                break;
            case GameMaster.TourState.EngageTile:
                buttonThrowDice.interactable = false;
                buttonConsiderTile.interactable = true;
                buttonEndturn.interactable = false;
                break;
            case GameMaster.TourState.EndTour:
                buttonThrowDice.interactable = false;
                buttonConsiderTile.interactable = false;
                buttonEndturn.interactable = true;
                break;
            default:
                buttonThrowDice.interactable = false;
                buttonConsiderTile.interactable = false;
                buttonEndturn.interactable = false;
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
