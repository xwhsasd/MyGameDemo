using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPC: MonoBehaviour
{
    public NPCConversation myConversation;
    [SerializeField] private GameObject tips;
    public bool isTalked = false;
    public string id;

    [ContextMenu("Generate checkpoint id")]
    private void GenerateId()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void TagTalk()
    {
        tips.SetActive(false);
        isTalked = true;
    }

    private void OnMouseOver()
    {
        if (isTalked)
           return;

        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(myConversation);
            TagTalk();
        }
    }
}
