using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialougeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI dialougeText;
    public TextMeshProUGUI cursorText;
    [TextArea]
    public string dialougeContent;
    [TextArea]
    public string cursorContent;
    // Update is called once per frame
    public void AssignText()
    {
        if(dialougeText!=null)
        {
            dialougeText.text = dialougeContent;
        }
        if(cursorText!=null)
        {
            cursorText.text = cursorContent;
        }
    }
}
