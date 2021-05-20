using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    READY, SPAWN, GAMEPLAY
}
public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public PlayerControl player;
    public GameState currentState;

    [Header("Cutscene Inicial")]
        public Transform spawnPoint; //posiçao em que o personagem spawna, no caso de um checkpoint, sera atualizado
        public float offSetYSpawn;
        public float spawnRaySpeed;
    #region MÉTODOS UNITY
    void Start()
    {
        
    }

   
    void Update()
    {
        GameStateManager();

        if(Input.GetButtonDown("Jump"))
        {
            SetGameState(GameState.SPAWN);
        }
    }

    #endregion

    #region MEUS MÉTODOS

    public void SetGameState(GameState newState)
    {
        currentState = newState;

        switch(currentState)
        {
            case GameState.SPAWN:
                player.transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y+offSetYSpawn);
                break;
            
            case GameState.GAMEPLAY:
                break;
        }
    }

    public void GameStateManager()
    {
        switch(currentState)
        {
            case GameState.SPAWN:
                player.transform.position = Vector2.MoveTowards(player.transform.position, spawnPoint.position, spawnRaySpeed*Time.deltaTime);
                if(player.transform.position == spawnPoint.position)
                {
                    SetGameState(GameState.GAMEPLAY); //quando chegar no target muda pra gameplay
                }
                break;
        }
    }

    #endregion
}
