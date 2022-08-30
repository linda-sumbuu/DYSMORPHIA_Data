using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D RB;
    private bool isFacingRight = true;
    public DialogueUI dialogueUI;
    private bool isDone = false;
    private bool isDialogue2 = false;
    private bool isDialogue3 = false;
    private bool isDialogue4 = false;
    public GameObject popUpText;
    public GameObject tutorial1;
    public GameObject tutorial2;
    //public GameObject crossFade;
    public NextScene nextScene;
    public Animator playerAnim;
    //private bool isSpoken = false;

    public GameObject mirrorObject;
    public GameObject mirrorUI;
    void Start()
    {
        RB = RB.GetComponent<Rigidbody2D>();
        playerAnim = playerAnim.GetComponent<Animator>();
        popUpText.SetActive(false);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        StartCoroutine(PlayDialogue());
        mirrorUI.SetActive(false);
        //crossFade.SetActive(false);
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        RB.velocity = new Vector2(moveInput * moveSpeed, RB.velocity.y);
        

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }

        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        if(isDone == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueUI.dialogueBox.SetActive(true);
                dialogueUI.ShowDialogue(dialogueUI.testDialogue);
                isDone = false;
            }
        }

        if(isDialogue2 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueUI.dialogueBox.SetActive(true);
                dialogueUI.ShowDialogue(dialogueUI.secondDialogue);
                isDialogue2 = false;
            }
        }

        if(isDialogue3 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueUI.dialogueBox.SetActive(true);
                dialogueUI.ShowDialogue(dialogueUI.cutsceneDialogue);
                isDialogue2 = false;
            }
        }

        if(isDialogue4 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               
                nextScene.LoadNextLevel();
            }
        }

        if (Mathf.Abs(moveInput) > 0 && RB.velocity.y == 0)
        {
            playerAnim.SetBool("IsWalk", true);
           
        }


        else
        {
            playerAnim.SetBool("IsWalk", false);
            
        }


    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        UnityEngine.Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Evidence1")
        {
            isDone = true;
            popUpText.SetActive(true);
        }

       if(collision.gameObject.tag == "Witness1")
        {
            isDialogue2 = true;
            popUpText.SetActive(true);
        }

       if(collision.gameObject.tag == "Sign2")
        {
            isDialogue3 = true;
            popUpText.SetActive(true);
        }

       if(collision.gameObject.name == "BlankWallPier (1)")
        {
            tutorial1.SetActive(true);
        }

        if (collision.gameObject.name == "BlankWallPier (2)")
        {
            tutorial2.SetActive(true);
        }

        if (collision.gameObject.tag == "SceneLoader1")
        {
            
            nextScene.LoadNextLevel();
            //fadeAnimator.SetTrigger("Fade");

        }

        if (collision.gameObject.tag == "Spirit1")
        {
            isDialogue4 = true;
            popUpText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Evidence1")
        {
            
            popUpText.SetActive(false);
        }

        if (collision.gameObject.tag == "Witness1")
        {
           
            popUpText.SetActive(false);
            Destroy(mirrorObject);
            mirrorUI.SetActive(true);
        }
        if (collision.gameObject.tag == "Sign2")
        {
        
            popUpText.SetActive(false);
        }

      

        if (collision.gameObject.name == "BlankWallPier (1)")
        {
            tutorial1.SetActive(false);
            Destroy(tutorial1.gameObject);
        }

        if (collision.gameObject.name == "BlankWallPier (2)")
        {
            tutorial2.SetActive(false);
            Destroy(tutorial2.gameObject);
        }

       

    }

    IEnumerator PlayDialogue()
    {
        yield return new WaitForSeconds(1);
        dialogueUI.ShowDialogue(dialogueUI.startDialogue);
    }

   


}
