using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Options {

    static Class playerClass;
    static Gender playerGender;
    static Difficult playerDifficult;

    #region GetFunctions
    public static Class PlayerClass {
        get { return playerClass; }
    }

    public static Gender PlayerGender {
        get { return playerGender; }
    }

    public static Difficult PlayerDifficult {
        get { return playerDifficult; }
    }
    #endregion

    #region SetFunctions
    public static void SetPlayerClass (Class newClass) {
        playerClass = newClass;
    }

    public static void SetPlayerGender (Gender newGender) {
        playerGender = newGender;
    }

    public static void SetPlayerDifficult (Difficult newDifficult) {
        playerDifficult = newDifficult;
    }
    #endregion

    public static void Initialize() {
        playerClass = Class.Warrior;
        playerGender = Gender.Male;
        playerDifficult = Difficult.Easy;
    }
}

