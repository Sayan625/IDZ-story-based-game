using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Npc : MonoBehaviour
{
    public GameObject button;
    public DialogueRunner dialogueRunner;

    public string name;

    private void OnTriggerStay(Collider other)
    {
        print("triggered");
        button.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        button.SetActive(false);

    }

    public void OnTalk() {
        dialogueRunner.StartDialogue(name);
    }
}
