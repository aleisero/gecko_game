using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public GameObject narText;
    public Image img;
    public Sprite newBG;

    public CanvasGroup goHomeButton;

    //Dialogue lists
    public List<string> currentList;

    public List<string> introList = new List<string>();
    public List<string> arriveHomeList = new List<string>();
    public int dialogPos;

    // Start is called before the first frame update
    void Start()
    {
        //initialize Lists
        introList.Add("At last, the day has come … after all this time, you’re finally fulfilling your wildest wishes … your deepest dreams … your darkest desires ….! Yes, that’s right: you’re buying a gecko.");
        introList.Add("Choose a lizard!");
        introList.Add("...actually, looks like they only have one kind of lizard available today…");
        introList.Add("It’s a Chinese Cave Gecko!");
        introList.Add("Good choice.");
        introList.Add("Alright, time to choose a name for your new little buddy. Hmmm…");
        introList.Add("Oh? You already chose one? What a good name!");
        introList.Add("Now choose some items to care for your new gecko.");

        //arriveHomeList
        arriveHomeList.Add("You idiot, you think your lizard’s gonna like that barran tank? Where’s the intrigue? The mystery? Everything’s on display! This is no good. No good at all. Clearly, you lack the decision making powers necessary to own a living thing.");
        arriveHomeList.Add("You call that a home?? There’s no bedroom. There’s no bathroom. There’s nowhere to sleep! This is a scandal. I’m not letting you put your new lizard in that shamble of a tank.");
        arriveHomeList.Add("Ah, now there’s an acceptable lizard home. Alright, now let’s get your lizard acquainted with their new space.");
        arriveHomeList.Add("How beautiful! Wonderful! Any gecko would be lucky to live in this tank. In fact, any number of species would be. Are you renting? No? Well then… let’s get your lizard acquainted with their new home.");
        arriveHomeList.Add("");
        arriveHomeList.Add("");


        currentList = introList;

        //display the first item from the list
        narText.GetComponent<Text>().text = introList[0];
        dialogPos = 0;

        //disable GoHomeButton
        turnOffGoHome();
    }

    public void changeDialogue()
    {
        if (dialogPos + 1 == currentList.Count)
        {
            clearDialogue();
        }
        else 
        {
            dialogPos++;
            narText.GetComponent<Text>().text = currentList[dialogPos];
        }
    }

    public void clearDialogue()
    {
        dialogPos = 0;

        if (currentList == introList)
        {
            //enable GoHomeButton
            goHomeButton.GetComponent<CanvasGroup>().alpha = 1f;
            goHomeButton.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        //when called this clears the current dialogue box
        //https://answers.unity.com/questions/971009/make-ui-elements-invisible.html
        this.GetComponent<CanvasGroup>().alpha = 0f; //this makes everything transparent
        this.GetComponent<CanvasGroup>().blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    public void showDialogue()
    {
        //set the current text to position 0 of currentList
        narText.GetComponent<Text>().text = currentList[dialogPos];
        //show text box and make it clickable
        this.GetComponent<CanvasGroup>().alpha = 1f; 
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void exitInventory()
    {
        //set currentList to arriveHomeList
        currentList = arriveHomeList;
        //change first item depending on inventory contents

       //check inventory contents
       //set dialogPos accordingly
       //one item: 0
       //any # items, no hide: 1
       //any # items, including hide and crickets: 2
       //all items: 3

        narText.GetComponent<Text>().text = currentList[dialogPos];

        //change BG
        img.sprite = newBG;

        //showDialogue
        showDialogue();

        turnOffGoHome();
    }

    public void turnOffGoHome()
    {
        //disable goHomeButton
        goHomeButton.GetComponent<CanvasGroup>().alpha = 0f;
        goHomeButton.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

}
