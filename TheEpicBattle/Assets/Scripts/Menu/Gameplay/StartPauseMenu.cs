﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPauseMenu : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            MenuManager.GoToMenu(MenuName.PauseGameplay);
        }
    }
}