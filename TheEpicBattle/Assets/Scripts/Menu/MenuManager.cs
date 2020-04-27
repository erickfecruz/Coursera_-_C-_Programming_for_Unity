using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager {

    public static void GoToMenu(MenuName menu) {
        switch (menu) {
            
            // Main Menu
            case MenuName.Help:
                SceneManager.LoadScene("Help");
                break;
            case MenuName.Play:
                Options.Initialize();
                SceneManager.LoadScene("Difficult");
                break;
            case MenuName.Quit:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Back:
                SceneManager.LoadScene("MainMenu");
                break;

            // Difficult Menu
            case MenuName.BackDifficult:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.EasyDifficult:
                Options.SetPlayerDifficult(Difficult.Easy);
                SceneManager.LoadScene("Character");
                break;
            case MenuName.NormalDifficult:
                Options.SetPlayerDifficult(Difficult.Normal);
                SceneManager.LoadScene("Character");
                break;
            case MenuName.HardDifficult:
                Options.SetPlayerDifficult(Difficult.Hard);
                SceneManager.LoadScene("Character");
                break;

            // Character Menu
            case MenuName.BackCharacter:
                SceneManager.LoadScene("Difficult");
                break;
            case MenuName.NextCharacter:
                SceneManager.LoadScene("Gameplay");
                break;

            // Pause Menu
            case MenuName.PauseGameplay:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.ExitGameplay:
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }
}
