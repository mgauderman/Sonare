﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }

    void OnTriggerEnter(Collider col)
    {
        if ( col.tag == "Player" )
        {
            TriggerDialogue();
        }
    }
}
