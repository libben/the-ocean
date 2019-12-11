using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Character Sub;
    private Character JacobFullBody;
    private Character AI;

    private Comment[][][] LevelDialogue;
    private Image ProfilePicRenderer;

    [SerializeField] private Sprite JacobFullBodyPic;
    [SerializeField] private Sprite SubPic;

    [SerializeField] private AudioSource ContinueNoise;

    void Awake()
    {
        ProfilePicRenderer = ProfilePicObj.GetComponent<Image>();
        Schaden = new Character("SCHADEN", SchadenProfilePic);
        Jacob = new Character("JACOB", JacobProfilePic);
        Brother = new Character("DILLON", BrotherProfilePic);
        GravityGlove = new Character("YOU FOUND THE GRAVITY GLOVE", GravGunPic);
        Sub = new Character("SUB CONTROLS", SubPic);
        JacobFullBody = new Character("CONTROLS", JacobFullBodyPic);
        AI = new Character("AI", AIPic);

        
        LevelDialogue = new Comment[3][][]; // for arcs
        LevelDialogue[1] = GenerateArc1Dialogue();
        LevelDialogue[2] = GenerateArc2Dialogue();
    }

    public void ShowGravityGunInstructions()
    {
        var comments = new Comment[1];
        comments[0] = new Comment(GravityGlove, "NOW, YOU CAN PRESS X TO GRAB A BOX. PRESS X AGAIN TO RELEASE.");
    }

    private Comment[][] GenerateArc1Dialogue()
    {
        var ArcDialogue = new Comment[11][];
        ArcDialogue[1] = new Comment[3];
        ArcDialogue[1][0] = new Comment(AI, "INTRUDER: YOUR PRESENCE HAS BEEN DETECTED. REMAIN STILL UNTIL OUR PERSONNEL ARRIVE TO ARREST YOU.");
        ArcDialogue[1][1] = new Comment(Jacob, "...");
        ArcDialogue[1][2] = new Comment(JacobFullBody, "PRESS RIGHT ARROW TO MOVE RIGHT, AND LEFT ARROW TO MOVE LEFT.");
        ArcDialogue[4] = new Comment[4];
        ArcDialogue[4][0] = new Comment(Schaden, "HELLO, THIS IS SCHADEN. YOU’RE QUITE CLEVER, MAKING IT THIS FAR INTO MY BASE. ");
        ArcDialogue[4][1] = new Comment(Schaden, "MY SENSORS SHOW ME YOUR POSITION, AND I CAN’T FATHOM HOW YOU GOT THERE. BORING THROUGH THE FLOOR, PERHAPS?");
        ArcDialogue[4][2] = new Comment(Schaden, "SO, WHO ARE YOU?");
        ArcDialogue[4][3] = new Comment(Jacob, "...");
        ArcDialogue[7] = new Comment[5];
        ArcDialogue[7][0] = new Comment(Schaden, "FURTHER AND FURTHER YOU COME, BUT WHY? MAYBE YOU ARE A FAN, COMING TO EMBRACE ME.");
        ArcDialogue[7][1] = new Comment(Jacob, "NO.");
        ArcDialogue[7][2] = new Comment(Schaden, "OH; HE SPEAKS. AI, ANALYZE THAT VOICE.");
        ArcDialogue[7][3] = new Comment(AI, "YES, SIR.");
        ArcDialogue[7][4] = new Comment(Jacob, "......");
        ArcDialogue[10] = new Comment[5];
        ArcDialogue[10][0] = new Comment(Schaden, "AI, WHAT IS YOUR ANALYSIS OF THIS INTRUDER’S VOICE?");
        ArcDialogue[10][1] = new Comment(AI, "VOICE DOES NOT MATCH ANY OF OUR USERS. HOWEVER, IT CLOSELY MATCHES BACKGROUND NOISE RECORDED ON");
        ArcDialogue[10][2] = new Comment(AI, "31 OCCASIONS FROM USER DILLON RICHTER’S HEADSET. GIVEN CENSUS DATA, PROBABILITY IS 80 PERCENT");
        ArcDialogue[10][3] = new Comment(AI, "THAT THE INTRUDER IS DILLON RICHTER’S BROTHER, JACOB.");
        ArcDialogue[10][4] = new Comment(Schaden, "NOT A USER AT ALL. SURPRISING. I’LL BE IN TOUCH.");
        return ArcDialogue;
    }

    private Comment[][] GenerateArc2Dialogue()
    {
        var ArcDialogue = new Comment[11][];
        ArcDialogue[0] = new Comment[19];
        ArcDialogue[0][0] = new Comment(Schaden, "STILL EVADING MY ROBOTIC GUARD? I’M PLEASED, AS IT GIVES US ANOTHER CHANCE TO TALK.");
        ArcDialogue[0][1] = new Comment(Schaden, "WHILE YOU WERE OUT THERE FLITTING ABOUT, I LISTENED TO THE CONVERSATIONS WE HAVE RECORDED BETWEEN YOU AND YOUR BROTHER.");
        ArcDialogue[0][2] = new Comment(Schaden, "YOU’RE QUITE ANGRY, AND IT’S BECAUSE YOU MISUNDERSTAND MY WORK.");
        ArcDialogue[0][3] = new Comment(Schaden, "IN OUR RECORDINGS OF YOU, YOU COMPARE MY TECHNOLOGY TO A DREAM, SAYING, \"WE ALL WAKE UP EVENTUALLY TO DISCOVER THAT THE DREAM LEFT NO MARK ON REALITY.\"");
        ArcDialogue[0][4] = new Comment(Schaden, "THAT’S BACKWARDS THINKING. GO TO ANY BEACH IN THE SO-CALLED \"REAL\" WORLD AND WRITE YOUR NAME ON THE SAND.");
        ArcDialogue[0][5] = new Comment(Schaden, "IN MOMENTS YOUR WORK IS WASHED AWAY. HOWEVER, I CAN SAVE THE POSITIONS OF VIRTUAL GRAINS OF SAND INDEFINITELY.");
        ArcDialogue[0][6] = new Comment(Schaden, "WITHIN THE WORLDS THAT I HAVE CREATED, NO EFFORT IS VOIDED OR FORGOTTEN. WE CAN REWIND ANY WORLD TO A PREVIOUS STATE.");
        ArcDialogue[0][7] = new Comment(Schaden, "TO INVEST IN A DIGITAL WORLD IS TO PROTECT YOUR WORK FOR FUTURE GENERATIONS.");
         ArcDialogue[0][8] = new Comment(Schaden, "HERE ON THE OCEAN FLOOR, THE SERVERS HOLDING THESE DIGITAL WORLDS ARE SHIELDED FROM THE WEATHERING OF TIME.");
        ArcDialogue[0][9] = new Comment(Schaden, "ALTHOUGH, HEH, WHETHER THEY ARE PROTECTED FROM YOU REMAINS TO BE SEEN.");
        ArcDialogue[0][10] = new Comment(Schaden, "THE ROOM YOU’RE IN IS A HOLOGRAPHIC VIRTUAL REALITY ENVIRONMENT I HAVE BEEN WORKING ON. I’VE SET IT TO DISPLAY ONE OF THE WORLDS I RUN: A MARS SIMULATION.");
        ArcDialogue[0][11] = new Comment(Schaden, "HERE, YOUR BROTHER IS TELLING HIS OWN STORY OF HOMESTEADING ON THE RED PLANET.");
        ArcDialogue[0][12] = new Comment(Brother, "JACOB? WHAT ARE YOU DOING ON MARS?");
        ArcDialogue[0][12] = new Comment(Jacob, "NOTHING. BECAUSE I’M NOT ON MARS, AND NEITHER ARE YOU. YOU’RE IN YOUR BEDROOM, PLAYING A GLORIFIED VIDEO GAME, AND I’M... SOMEWHERE ELSE.");
        ArcDialogue[0][13] = new Comment(Brother, "DO YOU ALWAYS HAVE TO BE CONDESCENDING, SOURPUSS?");
        ArcDialogue[0][14] = new Comment(Schaden, "YES, WOULD YOU RATHER HE RISKED HIS LIFE ATOP A TUBE OF ROCKET FUEL? HE CAN FIND ADVENTURE AND CHALLENGE JUST AS WELL IN MY VIRTUAL WORLDS,");
        ArcDialogue[0][15] = new Comment(Schaden, "AND LIVE A LONG, HAPPY LIFE. EVERY ACTION HE TAKES ON MARS WILL BE RECORDED, AND THE CIVILIZATION HE IS HELPING TO CREATE WILL BE ACCESSIBLE");
        ArcDialogue[0][16] = new Comment(Schaden, "FOR FUTURE GENERATIONS TO BUILD UPON, FOREVER.");
        ArcDialogue[0][17] = new Comment(Schaden, "STAY. MAKE SOMETHING THAT WILL LAST. I THINK THAT WHAT YOU TRULY WANT IS TO BOND WITH YOUR BROTHER, AND YOU CAN HAVE IT HERE.");
        ArcDialogue[0][18] = new Comment(Jacob, "...");
        ArcDialogue[1] = new Comment[5];
        ArcDialogue[1][0] = new Comment(Jacob, "I CAN'T.");
        ArcDialogue[1][1] = new Comment(Jacob, "DILLON’S NOT MAKING CIVILIZATION ON MARS, HE’S CHANGING 0’S TO 1’S ON A COMPUTER.");
        ArcDialogue[1][2] = new Comment(Jacob, "HUMANS EXIST IN A PHYSICAL, MESSY WORLD, AND IF WE WANT TO BENEFIT HUMANITY WE SHOULD BENEFIT THEM THERE.");
        ArcDialogue[1][3] = new Comment(Schaden, "AND AS SAND RUNS THROUGH THE HOURGLASS, EVERY BENEFIT YOU BRING WILL ERODE INTO NOTHING.");
        ArcDialogue[1][4] = new Comment(Schaden, "REGARDLESS, THIS IS THE END OF YOUR JOURNEY. THERE ARE NO SPIKES TO AVOID; WHATEVER DRILL YOU HAVE BEEN USING WON’T HELP HERE. I’M SORRY YOU CAME ALL THIS WAY ONLY TO TURN BACK.");
        ArcDialogue[2] = new Comment[1];
        ArcDialogue[2][0] = new Comment(Schaden, "MY GEOLOCATION SENSORS NEED TO BE REPLACED; THEY SAY YOU’RE ON THE OTHER SIDE OF THE BARRIER. HA!");
        ArcDialogue[3] = new Comment[1];
        ArcDialogue[3][0] = new Comment(Schaden, "WAIT, THIS ROOM’S SENSORS SAY THE SAME THING. ARE… ARE YOU ON THE OTHER SIDE?");
        ArcDialogue[4] = new Comment[5];
        ArcDialogue[4][0] = new Comment(Schaden, "WHAT. WAS. THAT.");
        ArcDialogue[4][1] = new Comment(Schaden, "WHAT ON EARTH WAS THAT?");
        ArcDialogue[4][2] = new Comment(Schaden, "HOW COULD YOU POSSIBLY HAVE MADE IT THIS FAR INTO THE BASE?");
        ArcDialogue[4][3] = new Comment(Jacob, "GOOD FORTUNE.");
        ArcDialogue[4][4] = new Comment(Schaden, "...");

        ArcDialogue[5] = new Comment[3];
        ArcDialogue[5][0] = new Comment(Schaden, "WHY ARE YOU IN MY BASE? YOU MERELY WANT YOUR BROTHER BACK, RIGHT? AS MUCH AS IT PAINS ME, I’LL CANCEL HIS ACCOUNT. JUST TURN BACK.");
        ArcDialogue[5][1] = new Comment(Jacob, "IT’S NOT JUST MY BROTHER, IT’S EVERYONE ELSE’S TOO.");
        ArcDialogue[5][2] = new Comment(Schaden, "...");
        return ArcDialogue;
    }

    public void ShowUnderwaterDialogue()
    {
        if (SceneCounter.counter == 1)
        {
            var comments = new Comment[5];
            comments[0] = new Comment(Jacob, "FOUND IT. MY SCHEMATICS SHOW THAT ONLY ONE ENTRANCE TO THE BASE IS OPEN. TO FORCE THE OTHER TWO TO OPEN, I’LL HAVE TO GO DEEP INTO THE BASE.");
            comments[1] = new Comment(Jacob, "THE AFT ENTRANCE, TO MY RIGHT, IS OPEN NOW. EVERY ENTRANCE WILL BE LIT, BUT IT SEEMS THAT EVERYTHING ELSE DOWN HERE WILL BE PAINFULLY DARK.");
            comments[2] = new Comment(AI, "HELLO, SUBSEA VESSEL. THIS IS AN AUTOMATED RADIO TRANSMISSION FROM SCHADEN VIRTUAL REALITY LABS. WE ARE NOT EXPECTING ANY DELIVERIES. PLEASE DEPART.");
            comments[3] = new Comment(Jacob, "...");
            comments[4] = new Comment(Sub,  "PRESS UP ARROW TO MOVE FORWARD, RIGHT ARROW TO TURN CLOCKWISE, AND LEFT ARROW TO TURN COUNTERCLOCKWISE");
            Show(comments, () => {});
        }
        else if (SceneCounter.counter == 5)
        {
            var comments = new Comment[1];
            comments[0] = new Comment(Jacob, "OK, LAST HATCH. THE SERVERS SHOULD BE ACCESSIBLE FROM THE BOW ENTRANCE OF THE BASE. THAT ENTRANCE APPEARS TO BE UP AND TO THE LEFT OF MY CURRENT LOCATION.");
            Show(comments, () => {});
        }
    }

    public void ShowHatchOpenDialogue()
    {
        if (Arc == 1)
        {
            var dialogue = new Comment[2];
            dialogue[0] = new Comment(AI, "ENTRANCE TO THE UNDERSIDE OF THE LABS IS NOW OPEN.");
            dialogue[1] = new Comment(Schaden, "HAHAHA... AND I THOUGHT MY ONE-ENTRANCE-OPEN POLICY WOULD BE ENOUGH TO MINIMIZE DAMAGES. I DIDN’T COUNT ON YOU, JACOB, DID I?");
            Show(dialogue, () => {SceneManager.LoadScene("OceanBase");});
        }
        else if (Arc == 2)
        {
            var dialogue = new Comment[1];
            dialogue[0] = new Comment(AI, "THE LAB’S BOW ENTRANCE IS NOW OPEN.");
            Show(dialogue, () => {SceneManager.LoadScene("OceanBase");});
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

    public void ShowHatchSightedDialogue()
    {
        var dialogue = new Comment[2];
        dialogue[0] = new Comment(Schaden, "CONFUSED? THE AI OF THIS STATION OBEYS ME. IT ONLY TOLD YOU THAT IT OPENED THE BOW ENTRANCE.");
        dialogue[1] = new Comment(Schaden, "I HATE TO HURT ANYONE, BUT I WON’T LET YOU DESTROY THE DIGITAL CULTURE MY USERS HAVE CREATED. MY ROBOTIC SENTRY IS ON ITS WAY.");
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