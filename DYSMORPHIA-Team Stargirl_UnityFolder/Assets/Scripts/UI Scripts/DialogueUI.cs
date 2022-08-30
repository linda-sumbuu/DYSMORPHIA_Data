using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] public DialogueObject testDialogue;
    [SerializeField] public DialogueObject secondDialogue;
    [SerializeField] public DialogueObject cutsceneDialogue;
    [SerializeField] public DialogueObject startDialogue;
    public bool isClosed;
    //[SerializeField] public DialogueObject nameDialogue;

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        //CloseDialogueBox();
        dialogueBox.SetActive(false);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        isClosed = true;
        //textLabel.text = string.Empty;
    }
}
