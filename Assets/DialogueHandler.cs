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

    public CanvasGroup StoreSlots;

    //Dialogue lists
    public List<string> currentList;

    private List<string> introList = new List<string>();
    private List<string> arriveHomeList = new List<string>();

    private List<string> cricketList = new List<string>();
    private List<string> plantsList = new List<string>();
    private List<string> branchList = new List<string>();
    private List<string> waterDishList = new List<string>();
    private List<string> rockList = new List<string>();
    private List<string> heatLampList = new List<string>();

    private List<string> hideList1 = new List<string>();
    private List<string> hideList2 = new List<string>();
    private List<string> hideList3 = new List<string>();
    private List<string> hideList4 = new List<string>();
    private List<string> hideList5 = new List<string>();

    private List<string> lizardList = new List<string>();

    private List<string> goodEndList = new List<string>();
    private List<string> okayEndList = new List<string>();
    private List<string> badEndList = new List<string>();
    private List<string> bandEndList = new List<string>();

    public int dialogPos;
    public int hideListCounter;

    public bool isDiaShowing;

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

        //object lists
        cricketList.Add("That’ll keep your new lizard full!");
        plantsList.Add("Yeup, fake plants. Work like a charm.");
        rockList.Add("A nice sunny spot.");
        branchList.Add("Good for climbing on!");
        waterDishList.Add("Ahh yes, the hydration station.");
        heatLampList.Add("Gotta stay toasty warm when you’re cold-blooded, huh?");

        //hideList
        hideList1.Add("Yeah, your lizard is in there, alright.");
        hideList2.Add("You’re really gonna keep poking at it?");
        hideList3.Add("Your lizard is nocturnal. It’s asleep, you dumbass.");
        hideList4.Add("Come on, leave him be already.");
        hideList5.Add("Oh, wonderful. You've made it mad.");

        hideListCounter = 1;

        //lizardList
        lizardList.Add("Woah, woah, hey, we’re not ready for that --");
        lizardList.Add("Lizard: Narrator, shut up, will you? You’re more obnoxious than they are.");
        lizardList.Add("Okay, alright… Clearly I’m not wanted nor respected here. *door slam noise*");

        //goodEndList
        goodEndList.Add("Lizard: Sorry about the glare. That’s just how I look in the dead of night, but since it’s you I can make an exception.");
        goodEndList.Add("Lizard: I mean after all, this place is pretty cushy, huh? And the all-you-can-eat buffet is included!");
        goodEndList.Add("Lizard: Mmmm, crickets.");
        goodEndList.Add("Lizard: I think this is gonna be pretty cool.");
        goodEndList.Add("You put your lizard back in the tank and he retreats into the hide to get some more sleep. You then enjoy the rest of your mutually beneficial lizard and lizard-owner relationship!");

        //okayEndList
        okayEndList.Add("Lizard: So I know you’re pretty new at this, but listen.");
        okayEndList.Add("Lizard: This tank’s a home. A shiny, brand new home. The countertops and tile all shine. But you open up the refrigerator and it’s totally empty.");
        okayEndList.Add("Lizard: So what I’m telling you is you need to high-tail it to the grocery store. Pick up some chops, yeah? A few snacks? Maybe do some meal prep when you get back?");
        okayEndList.Add("Lizard: I mean, it’s up to you. But if you don’t, you can’t expect me to stick around. That’s all I’m saying.");
        okayEndList.Add("You’ve been threatened but you have another chance. You buy your lizard some crickets and spend your days in quiet, isolated fear.");

        //badEndList
        badEndList.Add("Lizard: Listen, you probably mean well, but this is no kinda home for a guy like me.");
        badEndList.Add("Lizard: You expect me to sit there and let you stare at me at all hours?");
        badEndList.Add("Lizard: That’s like being in a zoo, you know.");
        badEndList.Add("Lizard: I wouldn’t call that comfortable.");
        badEndList.Add("Lizard: Maybe you should try it.");
        badEndList.Add("You get shoved into a human-sized tank to get stared at 24/7. A taste of your own medicine");

        //bandEndList
        bandEndList.Add("Lizard: That rhythmic tapping….");
        bandEndList.Add("Lizard: Hey, are you a drummer?");
        bandEndList.Add("Lizard: You are? That’s great! Listen, I’ve been looking for a drummer for ages… wanna join my alternative rock garage punk lizard band?");
        bandEndList.Add("Lizard: Don’t worry that you’re not a drummer. You can play a lizard-sized drum set anyways. It’ll be great!");
        bandEndList.Add("You and your new lizard form a band with some of the other, un-adopted lizards from the pet shop! Your music takes off with your lizard as the band’s front man.");
        bandEndList.Add("Congratulations, you’re going on a world tour!!!!");

        currentList = introList;

        //display the first item from the list
        narText.GetComponent<Text>().text = introList[0];
        dialogPos = 0;
        isDiaShowing = true;

        //disable GoHomeButton
        turnOffGoHome();
        //disable Store Slots canvas group
        StoreSlots.GetComponent<CanvasGroup>().alpha = 0f;
        StoreSlots.GetComponent<CanvasGroup>().blocksRaycasts = false;
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
        isDiaShowing = false;

        if (currentList == introList)
        {
            //enable GoHomeButton
            goHomeButton.GetComponent<CanvasGroup>().alpha = 1f;
            goHomeButton.GetComponent<CanvasGroup>().blocksRaycasts = true;

            //enable Store Slots canvas group
            StoreSlots.GetComponent<CanvasGroup>().alpha = 1f;
            StoreSlots.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        //when called this clears the current dialogue box
        //https://answers.unity.com/questions/971009/make-ui-elements-invisible.html
        this.GetComponent<CanvasGroup>().alpha = 0f; //this makes everything transparent
        this.GetComponent<CanvasGroup>().blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    public void showDialogue()
    {
        isDiaShowing = true;
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

        //disable Store Slots canvas group
        StoreSlots.GetComponent<CanvasGroup>().alpha = 0f;
        StoreSlots.GetComponent<CanvasGroup>().blocksRaycasts = false;

        turnOffGoHome();
    }

    public void turnOffGoHome()
    {
        //disable goHomeButton
        goHomeButton.GetComponent<CanvasGroup>().alpha = 0f;
        goHomeButton.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void crickets()
    {
        if (!isDiaShowing)
        {
            currentList = cricketList;
            showDialogue();
        }
    }

    public void plants()
    {
        if (!isDiaShowing)
        {
            currentList = plantsList;
            showDialogue();
        }
    }

    public void branch()
    {
        if (!isDiaShowing)
        {
            currentList = branchList;
            showDialogue();
        }
    }

    public void waterDish()
    {
        if (!isDiaShowing)
        {
            currentList = waterDishList;
            showDialogue();
        }
    }

    public void rock()
    {
        if (!isDiaShowing)
        {
            currentList = rockList;
            showDialogue();
        }
    }

    public void heatLamp()
    {
        if (!isDiaShowing)
        {
            currentList = heatLampList;
            showDialogue();
        }
    }

    public void hide()
    {
        if (!isDiaShowing || hideListCounter == 6)
        {
            if (hideListCounter == 1)
            {
                currentList = hideList1;
            }
            else if (hideListCounter == 2)
            {
                currentList = hideList2;
            }
            else if (hideListCounter == 3)
            {
                currentList = hideList3;
            }
            else if (hideListCounter == 4)
            {
                currentList = hideList4;
            }
            else if (hideListCounter == 5)
            {
                currentList = hideList5;
            }
            showDialogue();
            hideListCounter++;
        }
    }
}