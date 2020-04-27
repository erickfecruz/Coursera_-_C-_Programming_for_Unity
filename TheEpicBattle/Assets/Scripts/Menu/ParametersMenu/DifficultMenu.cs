using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultMenu : MonoBehaviour {

    /// <summary>
    /// Go to Back
    /// </summary>
    public void HandleBackButtonOnClickEvent() {
        AudioManager.Play(AudioName.Menu);
        MenuManager.GoToMenu(MenuName.BackDifficult);
    }

    /// <summary>
    /// Easy Difficult
    /// </summary>
    public void HandleEasyButtonOnClickEvent() {
        AudioManager.Play(AudioName.Menu);
        MenuManager.GoToMenu(MenuName.EasyDifficult);
    }

    /// <summary>
    /// Normal Difficult
    /// </summary>
    public void HandleNormalButtonOnClickEvent() {
        AudioManager.Play(AudioName.Menu);
        MenuManager.GoToMenu(MenuName.NormalDifficult);
    }

    /// <summary>
    /// Hard Difficult
    /// </summary>
    public void HandleHardButtonOnClickEvent() {
        AudioManager.Play(AudioName.Menu);
        MenuManager.GoToMenu(MenuName.HardDifficult);
    }
}
