using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour {

    /// <summary>
    /// Go to Menu
    /// </summary>
    public void HandleBackButtonOnClickEvent() {
        AudioManager.Play(AudioName.Menu);
        MenuManager.GoToMenu(MenuName.Back);
    }
}
