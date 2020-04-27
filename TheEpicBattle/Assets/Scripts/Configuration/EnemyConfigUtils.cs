/// <summary>
/// Provides access to configuration data
/// </summary>
public static class EnemyConfigUtils {

    #region Properties
    static EnemyConfigData configData;

    // Enemy class functions
    public static int EnemyHP {
        get { return configData.EnemyHP; }
    }

    public static int EnemyMP {
        get { return configData.EnemyMP; }
    }

    public static int EnemySTR {
        get { return configData.EnemySTR; }
    }

    public static int EnemyINT {
        get { return configData.EnemyINT; }
    }

    public static int EnemyDEF {
        get { return configData.EnemyDEF; }
    }

    public static int EnemyMDEF {
        get { return configData.EnemyMDEF; }
    }

    public static int EnemySPD {
        get { return configData.EnemySPD; }
    }

    #endregion
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize() {
        configData = new EnemyConfigData();
    }
}