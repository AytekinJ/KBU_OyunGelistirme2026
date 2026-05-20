using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    MainMenu = 0,
    Game = 1
}

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Awake()
    {
        // UI da butona basıldığında çalışacak metodun atama yöntemi
        playButton.onClick.AddListener(PlayButtonClicked);
    }

    private void PlayButtonClicked()
    {
        Debug.Log("Play Button Clicked");
        
        // Oyun sahnesine geçiş
        SceneManager.LoadScene("Game");
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
    }
}
