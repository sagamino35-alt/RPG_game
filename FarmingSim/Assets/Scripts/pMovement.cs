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

    public Animator pAnimator;
    public bool LookingUp;
    public bool LookingDown;
    public bool LookingLeft;
    public bool LookingRight;
    public bool isMoving;


    //float, int, bool, GAMEOBJECT!!

    [SerializeField] List<Sprite> pSprites;
    SpriteRenderer pSpriteRenderer;

    


    void Start()
    {
        pRB = GetComponent<Rigidbody2D>();
        pSpriteRenderer = GetComponent<SpriteRenderer>();
        pInput();
        pAnimator = GetComponent<Animator>();


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
            isMoving = true;
            
            //Player moves direction

            if (pMoveVector.x > 0 && pMoveVector.y == 0)
            {
                //RIGHT
                //pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(1, 1, 1);
                LookingUp = false;
                LookingDown = false;
                LookingRight = true;
                LookingLeft = false;
                

            }
            if (pMoveVector.x < 0 && pMoveVector.y == 0)
            {
                //LEFT
                //pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(-1, 1, 1);
                LookingUp = false;
                LookingDown = false;
                LookingLeft = true;
                LookingRight = false;

            }




            if (pMoveVector.x == 0 && pMoveVector.y > 0)
            {
                //UP
                //pSpriteRenderer.sprite = pSprites[1];
                LookingUp = true;
                LookingDown = false;
                LookingLeft = false;
                LookingRight = false;
            }
            if (pMoveVector.x == 0 && pMoveVector.y < 0)
            {
                //DOWN
                //pSpriteRenderer.sprite = pSprites[0];
                LookingUp = false;
                LookingDown = true;
                LookingLeft = false;
                LookingRight = false;
            }





            if (pMoveVector.x > 0 && pMoveVector.y > 0)
            {
                //DIAGONAL UP RIGHT
                //pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(1, 1, 1);
                LookingUp = false;
                LookingDown = false;
                LookingRight = true;
                LookingLeft = false;
            }
            if (pMoveVector.x < 0 && pMoveVector.y > 0)
            {
                //DIAGONAL UP LEFT
                //pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(-1, 1, 1);
                LookingUp = false;
                LookingDown = false;
                LookingRight = false;
                LookingLeft = true;
            }



            if (pMoveVector.x > 0 && pMoveVector.y < 0)
            {
                //DIAGONAL DOWN RIGHT
                //pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(1, 1, 1);
                LookingUp = false;
                LookingDown = false;
                LookingRight = true;
                LookingLeft = false;
            }
            if (pMoveVector.x < 0 && pMoveVector.y < 0)
            {
                //DIAGONAL DOWN LEFT
                //pSpriteRenderer.sprite = pSprites[2];
                transform.localScale = new Vector3(-1, 1, 1);
                LookingUp = false;
                LookingDown = false;
                LookingRight = false;
                LookingLeft = true;

            }


        }
        else
        {
            isMoving = false;
        }



        pAnimator.SetBool("IsMoving", isMoving);
        pAnimator.SetBool("Up", LookingUp);
        pAnimator.SetBool("Down", LookingDown);
        pAnimator.SetBool("Right", LookingRight);
        pAnimator.SetBool("Left", LookingLeft);





    }


    void pTillTile()
    {
        if (tillAction.WasPerformedThisFrame())
        {
            //Hitta bättre sätt att till tile 
        }
    }


}