using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameMaster : MonoBehaviour
{
    public enum TourState
    {
        DiceThrow,
        PickTile,
        EngageTile,
        Fight,
        EndTour

    }

    public TourState tourState
    {  get => _tourState;
        private set
        {
            _tourState = value;
            tourStateChanged.Invoke(value);
        }
    }
    
   


    public static GameMaster Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            Debug.Assert(_instance == null, "GameMaster already exists");
            _instance = value;
        }
    }

    public Pionek pionek;
    public Map map;
    public MapPathVisualiser pathVisualiser;
    public PlayerCard currentPlayer;
    public TileInteractions tileInteractions;
    public UnityEvent<TourState> tourStateChanged;

    private static GameMaster _instance;
    private TourState _tourState = TourState.DiceThrow;
    

    private void Awake()
    {
        Instance = this;
       

    }
    public void Start()
    {
        MasterUI.Instance.PanelFightUIOff();
    }
    public void NextTour()
    {
        if (tourState != TourState.EndTour) return;
        tourState = TourState.DiceThrow;
        MasterUI.Instance.PanelFightUIOff();
    }
    public void ThrowDice()
    {
        if (tourState != TourState.DiceThrow) return;
        int result = Dice.ThrowDice();
        MasterUI.Instance.ResultIconOnDiceThrow(result);
        List<List<Tile>> paths = map.GetPathsFromTileInRange(pionek.Tile, result);
        pathVisualiser.SetPaths(paths);
        foreach(List<Tile> path in paths)
        {
            path.Last().IsSelectable = true;
        }

        /* old solution of path finder
        List<Tile> tiles = map.MoveCalculator(pionek.Tile,result);
        foreach(Tile tile in tiles)
        {
            tile.IsSelectable = true;
        }
        */

        tourState = TourState.PickTile;
    }
    public void SelectTile(Tile tile)
    {
        if(tourState == TourState.PickTile)
        {
            pionek.Tile = tile;
            tourState= TourState.EngageTile;
            map.DisableAllSelectable();
            pathVisualiser.HideAllRenderers();
            
        }    
    }
    public void ConsiderTile()
    {
        if (tourState != TourState.EngageTile) return;
        Tile currentTile = pionek.Tile;
        MasterUI.Instance.ClearDiceIcon();
        if (currentTile.tileProperties == TileInteractions.TilesTypes.DrawOneCard)
        {
            var card = tileInteractions.DrawOneAdventuresCards();
            if(card is DangerousOpponent opponent)
            {
                StartFight(opponent);
                if (currentPlayer.stats.Health < 0)
                {
                    MasterUI.Instance.DidntWinGame();
                }
                return;
            }

        }
        if(currentTile.tileProperties == TileInteractions.TilesTypes.FightWithLastBoss)
        {
            var opponent = tileInteractions.FightWithBlackDragon();
            StartFight(opponent);
            if(currentPlayer.stats.Health > 0)
            {
                MasterUI.Instance.WinTheGame();
            }
            else
            {
                MasterUI.Instance.DidntWinGame();
            }
            return;
        }
        if(currentPlayer.stats.Health <0)
        {
            MasterUI.Instance.DidntWinGame();
        }
        tourState = TourState.EndTour;

    }
    public void StartFight(DangerousOpponent opponent)
    {
        if (tourState != TourState.EngageTile) return;

        var fight = new Fight(currentPlayer,opponent);
        tourState = TourState.Fight;
        MasterUI.Instance.PanelFightUIOn();
        fight.Start();

       
    }
    public void EndFight()
    {
        if (tourState != TourState.Fight) return;
        tourState = TourState.EndTour;
        
        
    }
    void Update()
    {
        if(Tile.debugTile!=null)
        {
            Tile.debugTile.DebugTest();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(Dice.ThrowDice());
        }    
    }
}
