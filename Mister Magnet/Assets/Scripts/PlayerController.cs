using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 5.0f;

    [Header("Ground")]
    [SerializeField]
    private Transform groundPoint;
    [SerializeField]
    private float groundRadius = 0.2f;
    [SerializeField]
    private LayerMask groundLayers;

    private Rigidbody2D playerRigidBody;
    private SpriteRenderer spriteRenderer;
    public GameObject playerController;
    private Animator animator;

    private float horizontalInput, verticalInput;

    private bool facingRight = true;
    private bool upRight = true;

    void Start()
    {
        //We used the rigidbody of the parent so that the character will flip around the parent's pivot
        //and not its own which is set to the bottom of the sprite.
        playerRigidBody = playerController.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        verticalInput = Input.GetAxisRaw("Vertical");
        Flip(horizontalInput);
        if(IsGrounded())
            ReverseGravity(verticalInput);
    }

    private void FixedUpdate()
    {
        //move the player based on the physics update
        float horizontalMovement = horizontalInput * moveSpeed;
        playerRigidBody.velocity = new Vector2(horizontalMovement, playerRigidBody.velocity.y);
        RestrictMovement();
    }

    private void Flip(float movement)
    {
        //if we have positive input and not facing right (facing left)
        // OR
        //if we have negative input and we are facing right
        if (movement > 0 && !facingRight || movement < 0 && facingRight)
        {
            //toggle the boolean
            facingRight = !facingRight;
            spriteRenderer.flipX = !facingRight;
        }
    }
    private void ReverseGravity(float movement)
    {
        if (movement > 0 && upRight || movement < 0 && !upRight)
        {
            playerRigidBody.gravityScale = -playerRigidBody.gravityScale;
            Vector3 theScale = playerController.transform.localScale;
            theScale.y *= -1;
            playerController.transform.localScale = theScale;
            upRight = !upRight;
        }
    }
//* IsGround
    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPoint.position, groundRadius, groundLayers);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)//make sure that the gameobject we are colliding is not our own
                return true;
        }
        return false;
    }
    //*/

    void RestrictMovement()
    {
        //3 different spaces
        //1: World Space - position our objects in the scene; origin is at Vector3 0,0,0 in the center
        //2: Screen Space - based on your screen size
        //3: Viewport Space - a normalized value of your screen space

        //Get the two corners from our viewport and convert it into world point
        Vector3 upperRightCorner = Camera.main.ViewportToWorldPoint(Vector3.one),
                lowerLeftCorner = Camera.main.ViewportToWorldPoint(Vector3.zero);

        //set the limit of our xPosition and yPosition
        float restrictedX = Mathf.Clamp(playerController.transform.position.x, lowerLeftCorner.x+0.6f, upperRightCorner.x),
              restrictedY = Mathf.Clamp(playerController.transform.position.y, lowerLeftCorner.y, upperRightCorner.y);

        //assign the position based on the restricted values
        playerController.transform.position = new Vector3(restrictedX, playerController.transform.position.y, 0);
    }
}
