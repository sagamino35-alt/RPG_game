using UnityEngine;
using UnityEngine.InputSystem;

public class pMovment : MonoBehaviour
{
    Rigidbody2D pRB;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] Vector2 moveVector;
    InputAction moveAction;

    public bool isFacingRight;
    public bool isFacingDown;



    void Start()
    {
        pRB = GetComponent<Rigidbody2D>();
        pInput();
        isFacingRight = true;
        isFacingDown = true;
    }


    void FixedUpdate()
    {

        moveVector = moveAction.ReadValue<Vector2>();
        pRB.linearVelocity = moveVector * moveSpeed;

        pDirecrionMod();
    }


    void pInput()
    {
        moveAction = InputSystem.actions.FindAction("Move");



    }

    void pDirecrionMod()
    {
        //cheching direction of movement
        if (moveVector.x > 0)
        {
            isFacingRight = true;
        }
        else if (moveVector.x < 0)
        {
            isFacingRight = false;
        }

        if (moveVector.y > 0)
        {
            isFacingDown = false;
        }
        else if (moveVector.y < 0)
        {
            isFacingDown = true;
        }



        //Fliping sprite depending on player direction

        if (isFacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!isFacingRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (isFacingDown)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!isFacingDown)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }






    }







}