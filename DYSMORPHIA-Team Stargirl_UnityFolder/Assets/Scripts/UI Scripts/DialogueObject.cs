using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    //[SerializeField][TextArea] private string[] names;
    

    public string[] Dialogue => dialogue;
   // public string[] Name => names;
}
