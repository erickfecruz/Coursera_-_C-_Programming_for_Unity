/// <summary>
/// Provides access to configuration data
/// </summary>
public static class PlayerConfigUtils {
    #region Properties
    static PlayerConfigData configData;

    // Warrior class functions
    public static int PlayerWarriorHP {
        get { return configData.PlayerWarriorHP; }
    }

    public static int PlayerWarriorMP {
        get { return configData.PlayerWarriorMP; }
    }

    public static int PlayerWarriorSTR {
        get { return configData.PlayerWarriorSTR; }
    }

    public static int PlayerWarriorINT {
        get { return configData.PlayerWarriorINT; }
    }

    public static int PlayerWarriorDEF {
        get { return configData.PlayerWarriorDEF; }
    }

    public static int PlayerWarriorMDEF {
        get { return configData.PlayerWarriorMDEF; }
    }

    public static int PlayerWarriorSPD {
        get { return configData.PlayerWarriorSPD; }
    }

    // Mage class functions
    public static int PlayerMageHP {
        get { return configData.PlayerMageHP; }
    }

    public static int PlayerMageMP {
        get { return configData.PlayerMageMP; }
    }

    public static int PlayerMageSTR {
        get { return configData.PlayerMageSTR; }
    }

    public static int PlayerMageINT {
        get { return configData.PlayerMageINT; }
    }

    public static int PlayerMageDEF {
        get { return configData.PlayerMageDEF; }
    }

    public static int PlayerMageMDEF {
        get { return configData.PlayerMageMDEF; }
    }

    public static int PlayerMageSPD {
        get { return configData.PlayerMageSPD; }
    }

    // Neutral class functions
    public static int PlayerNeutralHP {
        get { return configData.PlayerNeutralHP; }
    }

    public static int PlayerNeutralMP {
        get { return configData.PlayerNeutralMP; }
    }

    public static int PlayerNeutralSTR {
        get { return configData.PlayerNeutralSTR; }
    }

    public static int PlayerNeutralINT {
        get { return configData.PlayerNeutralINT; }
    }

    public static int PlayerNeutralDEF {
        get { return configData.PlayerNeutralDEF; }
    }

    public static int PlayerNeutralMDEF {
        get { return configData.PlayerNeutralMDEF; }
    }

    public static int PlayerNeutralSPD {
        get { return configData.PlayerNeutralSPD; }
    }
    #endregion
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize() {
        configData = new PlayerConfigData();
    }
}