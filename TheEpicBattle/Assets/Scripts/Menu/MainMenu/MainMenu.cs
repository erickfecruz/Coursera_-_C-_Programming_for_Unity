using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    /// <summary>
    /// Go to Menu
    /// </summary>
    public void HandlePlayButtonOnClickEvent() {
        MenuManager.GoToMenu(MenuName.Play);
        AudioManager.Play(AudioName.Menu);
    }

    /// <summary>
    /// Go to Help
    /// </summary>
    public void HandleHelpButtonOnClickEvent() {
        MenuManager.GoToMenu(MenuName.Help);
        AudioManager.Play(AudioName.Menu);
    }

    /// <summary>
    /// Go to Quit
    /// </summary>
    public void HandleQuitButtonOnClickEvent() {
        MenuManager.GoToMenu(MenuName.Quit);
    }

}
