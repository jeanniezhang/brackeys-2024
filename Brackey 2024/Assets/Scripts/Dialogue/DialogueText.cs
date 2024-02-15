using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/New Dialogue Container")]
public class DialogueText : ScriptableObject
{
    //script used for creating a datafile that stores all our text

    public string speakerName;

    [TextArea(5, 10)]
    public string[] paragraphs;
}
