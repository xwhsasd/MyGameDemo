
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName = "MainScene";
    [SerializeField] private GameObject continueButton;
    [SerializeField] UI_FadeScreen fadeScreen;

    [SerializeField] private Color noDataColor;
    private Image skillImage;
    private bool hasSaveData;

    private void Start()
    {
        hasSaveData = SaveManager.instance.HasSavedData();

        skillImage = continueButton.GetComponent<Image>();

        if (!hasSaveData)
        {
            skillImage.color = noDataColor;
        }
        else
        {
            skillImage.color = Color.white;
            Debug.Log("has save data");
        }
    }

    public void ContinueGame()
    {
        if (hasSaveData)
            StartCoroutine(LoadSceneWithFadeEffect(1.5f));
        else
            Debug.Log("No save data");
    }

    public void NewGame()
    {
        SaveManager.instance.DeleteSavedData();
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    IEnumerator LoadSceneWithFadeEffect(float _delay)
    {
        fadeScreen.FadeOut();

        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(sceneName);
    }

}
