using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_UI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private void Start()
    {
        if (SaveManager.instance.IsNewGame())
        {
            OpenTurorial();
        }
    }
    private void OpenTurorial()
    {
        canvas.SetActive(true);
    }


    public void CloseTurorial()
    {
        canvas.SetActive(false);
    }
}
