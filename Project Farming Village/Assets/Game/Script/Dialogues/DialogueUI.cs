using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private Image characterimage;
    [SerializeField] private TMP_Text nameLabel;

    public bool IsOpen { get; private set; }
    public bool IsUIOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
        //GetComponent<TypewriterEffect>().Run(textToType: "nah, i'd win\nIdiot SkibidiPT", textLabel);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        IsUIOpen = true;
        dialogueBox.SetActive(true);

        characterimage.sprite = dialogueObject.CharacterSprite;
        nameLabel.text = dialogueObject.CharacterName;
        characterimage.gameObject.SetActive(true);



        StartCoroutine(routine: StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);

            textLabel.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.Responses != null && dialogueObject.HasResponses) break; 

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textLabel);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                typewriterEffect.Stop();
            }
        }
    }

    public void CloseDialogueBox()
    { 
        IsOpen = false;
        IsUIOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        nameLabel.text = string.Empty;
    }
}

