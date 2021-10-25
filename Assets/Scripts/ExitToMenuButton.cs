using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ExitToMenuButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ExitToMenu);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ExitToMenu);
    }

    private void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
