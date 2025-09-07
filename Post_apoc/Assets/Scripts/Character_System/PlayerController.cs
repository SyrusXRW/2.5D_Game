using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;
    public SpriteRenderer theSr;
    public List<Item> inventory = new List<Item>();
    public void Add(Item item)
    {
        Debug.Log("ADDED");
        inventory.Add(item);
    }
    public void Remove(Item item)
    {
        inventory.Remove(item);
    }
    private bool movingBackwards;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //if (DialogueManager.Instance.isDialogueActive)
        //{
            //moveSpeed = 5f;
            //Debug.Log(message: "Pls");
            //return;
        //}
    

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);
        theRB.rotation = Quaternion.Euler(new Vector3(moveInput.x, theRB.velocity.y, theRB.velocity.z));

        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        }else
        {
            isGrounded = false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        }


        if(!theSr.flipX && moveInput.x < 0)
        {
            theSr.flipX = true;
        } else if (theSr.flipX && moveInput.x > 0)
        {
            theSr.flipX = false;
        }

        if(!movingBackwards && moveInput.y > 0)
        {
            movingBackwards = true;
        }else if(movingBackwards && moveInput.y < 0)
        {
            movingBackwards = false;
        }
    }
   
}
