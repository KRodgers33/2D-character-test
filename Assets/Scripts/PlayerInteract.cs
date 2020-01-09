using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Interactable interactable = null;
    [SerializeField] DialogueManager dialogueManager = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && interactable != null && !DialogueManager.isInteracting)
        {
            dialogueManager.StartDialogue(interactable.dialogue);
        }
    }
}
