using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Go to the game
    /// </summary>
    public void HandleResumeButtonOnClickEvent() {
        AudioManager.Play(AudioName.Menu);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleExitButtonOnClickEvent() {
        AudioManager.Stop();
        AudioManager.Play(AudioName.Menu);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.ExitGameplay);

    }
}
