using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialougeTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            dialogueRunner.StartDialogue("YarnScript");
        }
    }
}
