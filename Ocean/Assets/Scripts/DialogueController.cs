using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheOcean
{
public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject DialogueBox;
    [SerializeField] private Text CharacterName;
    [SerializeField] private Text DialogueText;
    [SerializeField] private GameObject ProfilePicObj;

    [SerializeField] private Sprite JacobProfilePic;
    [SerializeField] private Sprite BrotherProfilePic;
    [SerializeField] private Sprite SchadenProfilePic;
    [SerializeField] private Sprite GravGunPic;
    [SerializeField] private Sprite AIPic;
    public bool DialogueActive;

    [SerializeField] private int Arc;

    private Character Schaden;
    private Character Jacob;
    private Character Brother;
    private Character GravityGlove;
    private Character AI;

    private Comment[][][] LevelDialogue;
    private Image ProfilePicRenderer;

    [SerializeField] private AudioSource ContinueNoise;

    void Awake()
    {
        ProfilePicRenderer = ProfilePicObj.GetComponent<Image>();
        Schaden = new Character("Schaden", SchadenProfilePic);
        Jacob = new Character("Jacob", JacobProfilePic);
        Brother = new Character("Brother", BrotherProfilePic);
        GravityGlove = new Character("Gravity Glove", GravGunPic);
        AI = new Character("AI", AIPic);

        
        LevelDialogue = new Comment[3][][]; // for arcs
        LevelDialogue[1] = GenerateArc1Dialogue();
        LevelDialogue[2] = GenerateArc2Dialogue();
    }

    private Comment[][] GenerateArc1Dialogue()
    {
        var ArcDialogue = new Comment[11][];
        ArcDialogue[1] = new Comment[2];
        ArcDialogue[1][0] = new Comment(AI, "Intruder: your presence has been detected. Remain still until our personnel arrive to arrest you.");
        ArcDialogue[1][1] = new Comment(Jacob, "...");
        ArcDialogue[4] = new Comment[4];
        ArcDialogue[4][0] = new Comment(Schaden, "Hello, this is Schaden. You’re quite clever, making it this far into my base.");
        ArcDialogue[4][2] = new Comment(Schaden, "My sensors show me your position, and I can’t fathom how you got there. Boring through the floor, perhaps?");
        ArcDialogue[4][2] = new Comment(Schaden, "So, who are you?");
        ArcDialogue[4][3] = new Comment(Jacob, "...");
        ArcDialogue[7] = new Comment[5];
        ArcDialogue[7][0] = new Comment(Schaden, "Further and further you come, but why? Maybe you are a fan, coming to embrace me.");
        ArcDialogue[7][1] = new Comment(Jacob, "No.");
        ArcDialogue[7][2] = new Comment(Schaden, "Oh; he speaks. AI, analyze that voice.");
        ArcDialogue[7][3] = new Comment(AI, "Yes, sir.");
        ArcDialogue[7][4] = new Comment(Jacob, "......");
        ArcDialogue[10] = new Comment[5];
        ArcDialogue[10][0] = new Comment(Schaden, "AI, what is your analysis of this intruder’s voice?");
        ArcDialogue[10][1] = new Comment(AI, "Voice does not match any of our users. However, it closely matches background noise");
        ArcDialogue[10][2] = new Comment(AI, "recorded on 31 occasions from user Dillon Richter’s headset. Given census data,");
        ArcDialogue[10][3] = new Comment(AI, "probability is 80% that the intruder is Dillon Richter’s brother, Jacob.");
        ArcDialogue[10][4] = new Comment(Schaden, "Not a user at all. Surprising. I’ll be in touch.");
        return ArcDialogue;
    }

    private Comment[][] GenerateArc2Dialogue()
    {
        var ArcDialogue = new Comment[11][];
        ArcDialogue[0] = new Comment[17];
        ArcDialogue[0][0] = new Comment(Schaden, "Still evading my robotic guard? I’m pleased, as it gives us another chance to talk.");
        ArcDialogue[0][1] = new Comment(Schaden, "While you were out there flitting about, I listened to the conversations we have recorded between you and your brother.");
        ArcDialogue[0][2] = new Comment(Schaden, "You’re quite angry, and it’s because you misunderstand my work.");
        ArcDialogue[0][3] = new Comment(Schaden, "In our recordings of you, you compare my technology to a dream, saying, \"We all wake up eventually to discover that the dream left no mark on reality.\"");
        ArcDialogue[0][4] = new Comment(Schaden, "That’s backwards thinking. Go to any beach in the so-called \"real\" world and write your name on the sand.");
        ArcDialogue[0][5] = new Comment(Schaden, "In moments your work is washed away. However, I can save the positions of virtual grains of sand indefinitely.");
        ArcDialogue[0][6] = new Comment(Schaden, "Within the worlds that I have created, no effort is voided or forgotten. We can rewind any world to a previous state.");
        ArcDialogue[0][7] = new Comment(Schaden, "To invest in a digital world is to protect your work for future generations.");
         ArcDialogue[0][8] = new Comment(Schaden, "Here on the ocean floor, the servers holding these digital worlds are shielded from the weathering of time.");
        ArcDialogue[0][9] = new Comment(Schaden, "Although, heh, whether they are protected from you remains to be seen.");
        ArcDialogue[0][10] = new Comment(Schaden, "The room you’re in is a holographic virtual reality environment I have been working on. I’ve set it to display one of the worlds I run: a Mars simulation.");
        ArcDialogue[0][11] = new Comment(Schaden, "Here, your brother is telling his own story of homesteading on the red planet.");
        ArcDialogue[0][12] = new Comment(Brother, "Jacob? What are you doing on Mars?");
        ArcDialogue[0][12] = new Comment(Jacob, "Nothing. Because I’m not on Mars, and neither are you. You’re in your bedroom, playing a glorified video game, and I’m… somewhere else.");
        ArcDialogue[0][13] = new Comment(Brother, "Do you always have to be condescending, sourpuss?");
        ArcDialogue[0][14] = new Comment(Schaden, "Yes, would you rather he risked his life atop a tube of rocket fuel? He can find adventure and challenge just as well in my virtual worlds, and live a long, happy life.");
        ArcDialogue[0][15] = new Comment(Schaden, "Everything action he takes on Mars will be recorded, and the civilization he is helping to create will be accessible for future generations to build upon, forever.");
        ArcDialogue[0][15] = new Comment(Schaden, "Stay. Make something that will last. I think that what you truly want is to bond with your brother, and you can have it here.");
        ArcDialogue[0][16] = new Comment(Jacob, "...");
        ArcDialogue[1] = new Comment[5];
        ArcDialogue[1][0] = new Comment(Jacob, "I can’t.");
        ArcDialogue[1][1] = new Comment(Jacob, "Dillon’s not making civilization on Mars, he’s changing 0’s to 1’s on a computer.");
        ArcDialogue[1][2] = new Comment(Jacob, "Humans exist in a physical, messy world, and if we want to benefit humanity we should benefit them there.");
        ArcDialogue[1][3] = new Comment(Schaden, "And as sand runs through the hourglass, every benefit you bring will erode into nothing.");
        ArcDialogue[1][4] = new Comment(Schaden, "Regardless, this is the end of your journey. There are no spikes to avoid; whatever drill you have been using won’t help here. I’m sorry you came all this way only to turn back.");
        ArcDialogue[2] = new Comment[1];
        ArcDialogue[2][0] = new Comment(Schaden, "My geolocation sensors need to be replaced; they say you’re on the other side of the barrier. Ha!");
        ArcDialogue[3] = new Comment[1];
        ArcDialogue[3][0] = new Comment(Schaden, "Wait, this room’s sensors say the same thing. Are… are you on the other side?");
        ArcDialogue[4] = new Comment[5];
        ArcDialogue[4][0] = new Comment(Schaden, "What. Was. That.");
        ArcDialogue[4][1] = new Comment(Schaden, "What on EARTH was that?");
        ArcDialogue[4][2] = new Comment(Schaden, "How could you possibly have made it this far into the base?");
        ArcDialogue[4][3] = new Comment(Jacob, "Good fortune.");
        ArcDialogue[4][4] = new Comment(Schaden, "...");

        ArcDialogue[5] = new Comment[3];
        ArcDialogue[5][0] = new Comment(Schaden, "Why are you in my base? You merely want your brother back, right? As much as it pains me, I’ll cancel his account. Just turn back.");
        ArcDialogue[5][1] = new Comment(Jacob, "It’s not just my brother, it’s everyone else’s too.");
        ArcDialogue[5][2] = new Comment(Schaden, "...");
        return ArcDialogue;
    }

    public void ShowUnderwaterDialogue(int index)
    {
        if (index == 0)
        {
            var comments = new Comment[4];
            comments[0] = new Comment(Jacob, "Found it. My schematics show that only one entrance to the base is open. To force the other two to open, I’ll have to go deep into the base.");
            comments[1] = new Comment(Jacob, "The aft entrance, to my right, is open now. Every entrance is supposed to be lit up, but it seems that everything else down here will be painfully dark.");
            comments[2] = new Comment(AI, "Hello, subsea vessel. This is an automated radio transmission from Schaden Virtual Reality Labs. We are not expecting any deliveries. Please depart.");
            comments[3] = new Comment(Jacob, "...");
            Show(comments, () => {});
        }
        else if (index == 1)
        {
            var comments = new Comment[2];
            comments[0] = new Comment(Jacob, "Ok, last hatch. The servers should be accessible from the bow entrance of the base.");
            comments[1] = new Comment(Jacob, "That entrance appears to be up and to the left of my current location.");
            Show(comments, () => {});
        }
    }

    public void ShowHatchOpenDialogue()
    {
        if (Arc == 1)
        {
            var dialogue = new Comment[3];
            dialogue[0] = new Comment(AI, "Entrance to the underside of the labs is now open.");
            dialogue[1] = new Comment(Schaden, "Hahaha… and I thought my one-entrance-open policy would be enough to minimize damages.");
            dialogue[2] = new Comment(Schaden, "I didn’t count on you, Jacob, did I?");
            Show(dialogue, () => {/* load outdoors */});
        }
        else if (Arc == 2)
        {
            var dialogue = new Comment[1];
            dialogue[0] = new Comment(AI, "The lab’s bow entrance is now open.");
            Show(dialogue, () => {/* load outdoors */});
        }
    }

    private Comment[] CurrentDialogue;
    private int CurrentDialogueIndex;
    private System.Action ToDoAfterDialogue = null;

    private void Show(Comment[] comments, System.Action then)
    {
        DialogueActive = true;
        CurrentDialogueIndex = 0;
        ToDoAfterDialogue = then;
        CurrentDialogue = comments;
        Display(comments[0]);
    }

    private void Display(Comment comment)
    {
        DialogueBox.SetActive(true);
        DialogueText.text = comment.Phrase;
        CharacterName.text = comment.Speaker.Name;
        ProfilePicRenderer.sprite = comment.Speaker.ProfilePic;
    }

    void ShowHatchSightedDialogue()
    {
        var dialogue = new Comment[2];
        dialogue[0] = new Comment(Schaden, "Confused? The AI of this station obeys me. It only told you that it opened the bow entrance.");
        dialogue[1] = new Comment(Schaden, "I hate to hurt anyone, but I won’t let you destroy the digital culture my users have created. My robotic sentry is on its way.");
        Show(dialogue, null);
    }

    public void NotifyNewLevel(GameObject lvl)
    {
        int index = lvl.GetComponent<Level>().GetIndex();
        if (LevelDialogue[Arc][index] != null && LevelDialogue[Arc][index].Length > 0)
        {
            Show(LevelDialogue[Arc][index], null);
            // prevent this room from being triggered multiple times
            LevelDialogue[Arc][index] = null;
        }
    }

    void AdvanceDialogue()
    {
        CurrentDialogueIndex++;
        if (CurrentDialogueIndex >= CurrentDialogue.Length)
        {
            DialogueActive = false;
            DialogueBox.SetActive(false);
            if (ToDoAfterDialogue != null) {
                ToDoAfterDialogue();
            }
        }
        else
        {
            Display(CurrentDialogue[CurrentDialogueIndex]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueActive && Input.GetButtonDown("E"))
        {
            ContinueNoise.Play();
            AdvanceDialogue();
        }
    }
}

class Character
{
    public string Name;
    public Sprite ProfilePic;
    public Character(string name, Sprite profilePic)
    {
        this.Name = name;
        this.ProfilePic = profilePic;
    }
}

class Comment
{
    public Character Speaker;
    public string Phrase;
    public Comment(Character speaker, string phrase)
    {
        Speaker = speaker;
        Phrase = phrase;
    }
}
}