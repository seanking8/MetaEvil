using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public Animator anim;
    public GameObject weaponInHand;
    public GameObject hand;
    public AudioSource walkSound;
    public AudioSource swingSound;
    public AudioSource gameOverSound;

    public PlayerStats pstats;
    public Interactable focus;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true; // Will be useful for dialog or if we want player to stay still
    float CooldownTimer;
    float Cooldown = 2;//Cooldown to attack speed
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool canrun = false;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float movementDirectionY = moveDirection.y;
        if (isRunning == true)
        {
            canrun = PlayerStats.playerhasStanima();
        }

        float curSpeedX = canMove ? (canrun ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0; //Will cancel if false (can move), if left shift is not held down normal speed
        float curSpeedY = canMove ? (canrun ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;

        // if (curSpeedX != 0 || curSpeedY != 0)
        // {
        //     walkSound.Play();
        // } else if (curSpeedX == 0 && curSpeedY == 0)
        // {
        //     walkSound.Pause();
        // }

        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f && !walkSound.isPlaying)
        {
            //Make faster is running
            walkSound.Play();
        }
        else if (characterController.velocity.magnitude < 0.2f)
        {
            walkSound.Pause();
        }

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //Test to see unity colab
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;

        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (Input.GetKeyDown(KeyCode.X) && PlayerStats.playerhasStanima()) //Needs to check if player has x stam
        {//Move back

            characterController.Move(-this.transform.forward * 5);
        }


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        //Player interaction
        if (Input.GetMouseButtonDown(0) && Time.time > CooldownTimer)
        {


            //Below is to get what player is targeting
            //Creates ray of where player is looking
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            //If ray hits object
            if (Physics.Raycast(ray, out hit, 100))
            {

                //  Debug.Log("hit");
                NpcScript NPC = hit.collider.GetComponent<NpcScript>();
                Animator bossAnim = hit.collider.GetComponent<Animator>();
                if (NPC != null)
                {


                    //  weaponInHand = GameObject.Find("/Player/PlayerIdle/Armature/Bone/Bone.001/Bone.001_R/Bone.001_R.001/Bone.001_R.002/Bone.001_R.003/Bone.001_R.004/Hand/TempHand");//Gets Hand game object

                    if (hand.transform.GetChild(0) != null)//Checks if gameobject was found. OR no item equiped 
                    {

                        GameObject Child = null;
                        try
                        {
                            anim.SetTrigger("Attack");
                            swingSound.Play();

                            Child = hand.transform.GetChild(0).gameObject;//Gets Equiped item
                            int attackval = Child.GetComponent<ItemInfo>().value;//Needs to get temphand

                            NPC.PlayHurtSound();
                            NPC.npcHealth = (int)(NPC.npcHealth - attackval);//changes health
                            bossAnim.SetTrigger("ImpactTr"); //impact animation
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Fail " + e.StackTrace);

                        }//No item held, Patch this later to check for item equiped
                    }

                }

            }
        }
        else
        {

        }

    }
    public void editmove(bool value)
    {
        canMove = value;

    }
    public GameObject getLooking() //Gets what the player is looking at.
    {
        //Below is to get what player is targeting
        //Creates ray of where player is looking
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        //If ray hits object
        if (Physics.Raycast(ray, out hit, 100))
        {

            return hit.collider.gameObject;
        }
        return null;



    }
    public void increasespeed(float increase)
    {
        walkingSpeed = walkingSpeed + increase;
        runningSpeed = runningSpeed + increase;
    }
}

