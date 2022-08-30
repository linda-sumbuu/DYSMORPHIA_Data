using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneB : MonoBehaviour
{
    public NextScene nextScene;
    public DialogueUI dialogueUI;
    void Start()
    {
        StartCoroutine(PlayDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueUI.isClosed == true)
        {
            nextScene.LoadNextLevel();
        }
    }

    IEnumerator PlayDialogue()
    {
        yield return new WaitForSeconds(1);
        dialogueUI.ShowDialogue(dialogueUI.cutsceneDialogue);
    }
}
