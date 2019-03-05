using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{

    public Button nextButton;
    public CanvasGroup dialogueBox;
    public Sprite newBG;
    public Image img;

    public Button lizard;

    // Start is called before the first frame update
    void Start()
    {
        //https://docs.unity3d.com/ScriptReference/UI.Button-onClick.html
        //nextButton.onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        Debug.Log("nextButton clicked");

        //change the background sprite
        //https://docs.unity3d.com/ScriptReference/UI.Image-sprite.html
        img.sprite = newBG;

    }

    public void clearDialogue()
    {
        //when called this clears the current dialogue box
        //https://answers.unity.com/questions/971009/make-ui-elements-invisible.html
        dialogueBox.alpha = 0f; //this makes everything transparent
        dialogueBox.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    public void lizardClick()
    {
        Debug.Log("lizard was clicked");
    }
}
