using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchLight : MonoBehaviour
{
    private Player player;
    private bool hasSwitchToState = false;

    private void Start()
    {
        player = PlayerManager.instance.player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasSwitchToState)
            return;
        if (collision.GetComponent<Player>() != null)
        {
            hasSwitchToState = true;
            player.CatchLight(transform);
        }
    }

    private void Update()
    {
        if (hasSwitchToState)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine("CatchDelay");
            }
    }

    public IEnumerator CatchDelay()
    {
        yield return new WaitForSeconds(.5f);
        hasSwitchToState = false;
    }

}
