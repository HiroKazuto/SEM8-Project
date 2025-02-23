using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteScript : MonoBehaviour
{
    public TextMeshProUGUI noteText;
    [TextArea]
    public string noteContent;
    // Update is called once per frame
    public void AssignText()
    {
        if(noteText!=null)
        {
            noteText.text = noteContent;
        }
    }
}
