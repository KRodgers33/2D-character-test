using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static bool isInteracting = false;

    [SerializeField] TMP_Text dialogueText = null; 
    [SerializeField] GameObject[] optionButtons = null;

    private Dialogue dialogue;
    private int dialogueIndex = 0;
    private float dialogueWait = 0f;
    private bool canContinueDialogue = false;

    private void Update()
    {
        if (dialogueWait > 0f)
        { 
            dialogueWait -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && isInteracting && canContinueDialogue && dialogueWait <= 0)
        {
            NextDialogue();
        }
    }

    public void StartDialogue(Dialogue d)
    {
        dialogue = d;
        isInteracting = true;
        dialogueIndex = 0;
        UpdateDialogue();
    }

    public void NextDialogue()
    {
        dialogueIndex++;
        UpdateDialogue();
    }

    public void DialogueOption1()
    {
        dialogue = dialogue.dialogueTree[0];
        dialogueIndex = 0;
        UpdateDialogue();
    }

    public void DialogueOption2()
    {
        dialogue = dialogue.dialogueTree[1];
        dialogueIndex = 0;
        UpdateDialogue();
    }

    public void DialogueOption3()
    {
        dialogue = dialogue.dialogueTree[2];
        dialogueIndex = 0;
        UpdateDialogue();
    }

    private void UpdateDialogue()
    {
        if (dialogueIndex + 1 > dialogue.text.Length)
        {
            EndDialogue();
            return;
        }
        dialogueText.text = dialogue.text[dialogueIndex];
        dialogueWait = 0.125f;
        canContinueDialogue = (dialogueIndex + 1 < dialogue.text.Length || dialogue.dialogueTree.Length == 0);
    
        if (canContinueDialogue)
        {
            HideDialogueButtons();
        }
        else
        {
            UpdateDialogueButtons();
        }
    }

    private void EndDialogue()
    {
        isInteracting = false;
        dialogueText.text = "";
        HideDialogueButtons();
    }

    private void UpdateDialogueButtons()
    {
        for (int i = 0; i < dialogue.dialogueTree.Length; i++)
        {
            optionButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogue.dialogueTree[i].previewText;
            optionButtons[i].SetActive(true);
        }
    }

    private void HideDialogueButtons()
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].SetActive(false);
        }
    }
}
