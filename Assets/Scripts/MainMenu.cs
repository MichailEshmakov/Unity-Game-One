using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private int GameSceneIndex;
    [SerializeField] private int CreditsSceneIndex;

    private void OnEnable()
    {
        PlayButton.onClick.AddListener(Play);
        CreditsButton.onClick.AddListener(ShowCredits);
        ExitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        PlayButton.onClick.RemoveListener(Play);
        CreditsButton.onClick.RemoveListener(ShowCredits);
        ExitButton.onClick.RemoveListener(Exit);
    }

    private void OnValidate()
    {
        GameSceneIndex = Mathf.Clamp(GameSceneIndex, 0, int.MaxValue);
        CreditsSceneIndex = Mathf.Clamp(CreditsSceneIndex, 0, int.MaxValue);
    }

    private void Play()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    private void ShowCredits()
    {
        SceneManager.LoadScene(CreditsSceneIndex);
    }

    private void Exit() 
    {
        Application.Quit();
    }




}
