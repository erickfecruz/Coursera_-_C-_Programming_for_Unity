using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {

    [SerializeField]
    Toggle male;

    [SerializeField]
    Toggle female;

    [SerializeField]
    Toggle warrior;

    [SerializeField]
    Toggle neutral;

    [SerializeField]
    Toggle mage;

    /// <summary>
    /// Go to Back
    /// </summary>
    public void HandleBackButtonOnClickEvent() {
        AudioManager.Play(AudioName.Menu);
        MenuManager.GoToMenu(MenuName.BackCharacter);
    }

    /// <summary>
    /// Easy Difficult
    /// </summary>
    public void HandleNextButtonOnClickEvent() {
        AudioManager.Play(AudioName.Menu);

        // Gender options
        if (male.isOn)
            Options.SetPlayerGender(Gender.Male);
        else if (female.isOn)
            Options.SetPlayerGender(Gender.Female);

        // Class options
        if (warrior.isOn)
            Options.SetPlayerClass(Class.Warrior);
        else if (neutral.isOn)
            Options.SetPlayerClass(Class.Neutral);
        else if (mage.isOn)
            Options.SetPlayerClass(Class.Mage);

        MenuManager.GoToMenu(MenuName.NextCharacter);
    }
}
