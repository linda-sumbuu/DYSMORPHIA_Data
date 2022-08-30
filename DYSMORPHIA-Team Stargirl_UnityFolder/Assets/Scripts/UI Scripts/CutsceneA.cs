using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneA : MonoBehaviour
{
    public DialogueUI dialogueUI;
    public int counter;
    public GameObject photo;
    public NextScene nextScene;
    // Start is called before the first frame update
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

        if (counter == 7)
        {
            photo.SetActive(true);
        }

        if (dialogueUI.isClosed == true)
        {
            nextScene.LoadNextLevel();
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
