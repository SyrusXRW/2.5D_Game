using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Yarn.Unity.Example
{
    public class PlayerController : MonoBehaviour
    {
        public Rigidbody theRB;
        public float moveSpeed, jumpForce;
        
<<<<<<< Updated upstream
        public float interactionRadius = 2.0f;
        private Vector2 moveInput;

=======
<<<<<<< Updated upstream
    }
    // Update is called once per frame
    void Update()
    {
        //if (DialogueManager.Instance.isDialogueActive)
        //{
=======
        public float interactionRadius = 2.0f;
        private Vector2 moveInput;

        public Animator anim; 

>>>>>>> Stashed changes
        public LayerMask whatIsGround;
        public Transform groundPoint;
        private bool isGrounded;
        public SpriteRenderer theSr;
        public List<Item> inventory = new List<Item>();

        private DialogueAdvanceInput dialogueInput;

        void Start()
        {
            dialogueInput = FindObjectOfType<DialogueAdvanceInput>();
            dialogueInput.enabled = false;
        }
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
        // Update is called once per frame
        void Update()
        {
            //if (DialogueManager.Instance.isDialogueActive)
            //{
<<<<<<< Updated upstream
=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
            //moveSpeed = 5f;
            //Debug.Log(message: "Pls");
            //return;
            //}
            // Remove all player control when we're in dialogue
            if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
            {
                return;
            }

            // every time we LEAVE dialogue we have to make sure we disable the input again
            if (dialogueInput.enabled)
            {
                dialogueInput.enabled = false;
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                CheckForNearbyNPC();
            }

            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
=======
>>>>>>> Stashed changes
            moveInput.Normalize();

            theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);
            theRB.rotation = Quaternion.Euler(new Vector3(moveInput.x, theRB.velocity.y, theRB.velocity.z));

<<<<<<< Updated upstream
=======
            anim.SetFloat("moveSpeed", theRB.velocity.magnitude);

>>>>>>> Stashed changes
            RaycastHit hit;
            if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                theRB.velocity += new Vector3(0f, jumpForce, 0f);
            }


            if (!theSr.flipX && moveInput.x < 0)
            {
                theSr.flipX = true;
            }
            else if (theSr.flipX && moveInput.x > 0)
            {
                theSr.flipX = false;
            }

            if (!movingBackwards && moveInput.y > 0)
            {
                movingBackwards = true;
            }
            else if (movingBackwards && moveInput.y < 0)
            {
                movingBackwards = false;
            }

        }
        public void CheckForNearbyNPC()
<<<<<<< Updated upstream
=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        {
            var allParticipants = new List<NPC>(FindObjectsOfType<NPC>());
            var target = allParticipants.Find(delegate (NPC p)
            {
                return string.IsNullOrEmpty(p.talkToNode) == false && // has a conversation node?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= interactionRadius;
            });
            if (target != null)
            {
                // Kick off the dialogue at this node.
                FindObjectOfType<DialogueRunner>().StartDialogue(target.talkToNode);
                // reenabling the input on the dialogue
                dialogueInput.enabled = true;
            }
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;

            // Flatten the sphere into a disk, which looks nicer in 2D
            // games
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1, 1, 0));

            // Need to draw at position zero because we set position in the
            // line above
            Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
        }

    }
}
