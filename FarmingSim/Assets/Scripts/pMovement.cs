using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class pMovment : MonoBehaviour
{
    Rigidbody2D pRB;
    [SerializeField] float pMoveSpeed = 5;
    [SerializeField] Vector2 pMoveVector;
    InputAction moveAction;
    InputAction tillAction;
    
    //float, int, bool, GAMEOBJECT!!

    [SerializeField] List<Sprite> pSprites;
    SpriteRenderer pSpriteRenderer;

    


    void Start()
    {
        pRB = GetComponent<Rigidbody2D>();
        pSpriteRenderer = GetComponent<SpriteRenderer>();
        pInput();
        
    }


    void FixedUpdate()
    {

        pMoveVector = moveAction.ReadValue<Vector2>();
        pRB.linearVelocity = pMoveVector * pMoveSpeed;

        pDirectionMod();
    }


    void pInput()
    {

        //add actions here

        moveAction = InputSystem.actions.FindAction("Move");

        tillAction = InputSystem.actions.FindAction("Attack");

    }

    void pDirectionMod()
    {
        
        



        //Changing and/or fliping sprite depending on player direction

        if(pMoveVector.magnitude > 0)
        {

            //Plater moves

            if(pMoveVector.x > 0 && pMoveVector.y == 0)
            {
                //RIGHT
                pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(-1, 1, 1);

            }
            if (pMoveVector.x < 0 && pMoveVector.y == 0)
            {
                //LEFT
                pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(1, 1, 1);

            }




            if (pMoveVector.x == 0 && pMoveVector.y > 0)
            {
                //UP
                pSpriteRenderer.sprite = pSprites[1];
            }
            if (pMoveVector.x == 0 && pMoveVector.y < 0)
            {
                //DOWN
                pSpriteRenderer.sprite = pSprites[0];
            }





            if (pMoveVector.x > 0 && pMoveVector.y > 0)
            {
                //DIAGONAL UP RIGHT
                pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (pMoveVector.x < 0 && pMoveVector.y > 0)
            {
                //DIAGONAL UP LEFT
                pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(1, 1, 1);
            }



            if (pMoveVector.x > 0 && pMoveVector.y < 0)
            {
                //DIAGONAL DOWN RIGHT
                pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (pMoveVector.x < 0 && pMoveVector.y < 0)
            {
                //DIAGONAL DOWN LEFT
                pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(1, 1, 1);
            }


        }  

        






    }


    void pTillTile()
    {
        if (tillAction.WasPerformedThisFrame())
        {
            //Hitta bättre sätt att till tile 
        }
    }


}