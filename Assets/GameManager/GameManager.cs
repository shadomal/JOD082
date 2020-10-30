using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum STATE
    {
        WAITING,
        INITIALIZING,
        INGAME,
        REBOOTING
    }
    public enum STATE_GAME
    {
        START_TURN,
        STOP_TURN

    }

    [Header("Jogadores Vars")]
    [SerializeField] private GameObject[] players = new GameObject[4];
    [Header("Turno Vars")]
    private int turnos;
    private int MaxTurnos;
    private float turnTime;


    void Awake()
    {
        turnos = 10;
        MaxTurnos = 10;
        turnTime = 360;
        
    }

    private STATE_GAME state;
    public STATE_GAME GetStateGame() => this.state;

    public void SetStateGame(STATE_GAME state)
    {
        this.state = state;

        //enviar estado atual para os usuários
    }

    public void initTurn()
    {
        if (this.GetStateGame() == STATE_GAME.START_TURN)
        {
            return;
        }

        this.SetStateGame(STATE_GAME.START_TURN);

        // coletar 2 membros aleatórios;

        // teleportar usuários até a localização da arena

        // entregar buffs/debuffs/items
    }
    public void stopTurn()
    {
        if (this.GetStateGame() == STATE_GAME.STOP_TURN)
        {
            return;
        }
        this.SetStateGame(STATE_GAME.STOP_TURN);

        // teleportar os usuários até a localização de especs
    }

    public void GetPlayers()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    //Criar um método pra troca os jogador quando acabar o tempo
    //Checar se um jogador morreu
}
