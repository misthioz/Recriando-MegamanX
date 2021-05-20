using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody2D    rb;
    private Animator       anim;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        gameManager.player = this; 

    }

    
    void Update()
    {
        //se estiver em qualquer estado que não seja a gameplay, para a execução
        if(gameManager.currentState != GameState.GAMEPLAY)
        {
            return;
        }
        
    }

    #region  MEUS MÉTODOS

    public void SpawnDone()
    {
        anim.SetTrigger("Spawn");
    }

    #endregion
}
