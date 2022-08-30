 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public DialogueUI dialogueUI;
    public int counter;
    public GameObject photo;
    public NextScene nextScene;
    public GameObject popUpText;
    public GameObject spaceText;
    public GameObject cryingScreen;
    void Start()
    {
        StartCoroutine(PlayDialogue());
        photo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonClick();
            //Debug.Log("nani");
        }

        if(counter == 26)
        {
            photo.SetActive(true);
        }


        if(counter == 31)
        {
            cryingScreen.SetActive(true);
        }

        if(dialogueUI.isClosed == true)
        {
            spaceText.SetActive(false);
            popUpText.SetActive(true);
            photo.SetActive(true);
        }
    }

    public void ButtonClick()
    {
        counter++;
    }

    

    IEnumerator PlayDialogue()
    {
        yield return new WaitForSeconds(1);
        dialogueUI.ShowDialogue(dialogueUI.cutsceneDialogue);
    }
}
