using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;
    public string id = " ";
    public bool activationStatus;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if(id == " ")
            GenerateId();
    }

    [ContextMenu("Generate checkpoint id")]
    private void GenerateId()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null && !activationStatus)
        {
            ActivateCheckpoint();
        }
    }

    public void ActivateCheckpoint()
    {
        activationStatus = true;
        AudioManager.instance.PlaySFX(5, transform);
        anim.SetBool("Active", true);
    }
}
