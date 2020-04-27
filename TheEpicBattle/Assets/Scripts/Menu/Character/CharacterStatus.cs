using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour {

    [SerializeField]
    Text Warrior;

    [SerializeField]
    Text Neutral;

    [SerializeField]
    Text Mage;

    // Start is called before the first frame update
    void Start() {

        PlayerConfigUtils.Initialize();

        Warrior.text = "HP: " + PlayerConfigUtils.PlayerWarriorHP +
            "\nMP: " + PlayerConfigUtils.PlayerWarriorMP +
            "\nSTR: " + PlayerConfigUtils.PlayerWarriorSTR +
            "\nINT: " + PlayerConfigUtils.PlayerWarriorINT +
            "\nDEF: " + PlayerConfigUtils.PlayerWarriorDEF +
            "\nMDEF: " + PlayerConfigUtils.PlayerWarriorMDEF +
            "\nSPD: " + PlayerConfigUtils.PlayerWarriorSPD;

        Neutral.text = "HP: " + PlayerConfigUtils.PlayerNeutralHP +
            "\nMP: " + PlayerConfigUtils.PlayerNeutralMP +
            "\nSTR: " + PlayerConfigUtils.PlayerNeutralSTR +
            "\nINT: " + PlayerConfigUtils.PlayerNeutralINT +
            "\nDEF: " + PlayerConfigUtils.PlayerNeutralDEF +
            "\nMDEF: " + PlayerConfigUtils.PlayerNeutralMDEF +
            "\nSPD: " + PlayerConfigUtils.PlayerNeutralSPD;

        Mage.text = "HP: " + PlayerConfigUtils.PlayerMageHP +
            "\nMP: " + PlayerConfigUtils.PlayerMageMP +
            "\nSTR: " + PlayerConfigUtils.PlayerMageSTR +
            "\nINT: " + PlayerConfigUtils.PlayerMageINT +
            "\nDEF: " + PlayerConfigUtils.PlayerMageDEF +
            "\nMDEF: " + PlayerConfigUtils.PlayerMageMDEF +
            "\nSPD: " + PlayerConfigUtils.PlayerMageSPD;

    }
}
