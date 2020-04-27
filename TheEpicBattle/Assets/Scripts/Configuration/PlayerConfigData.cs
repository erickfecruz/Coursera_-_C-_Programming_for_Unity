using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class PlayerConfigData {
    #region Fields

    const string ConfigurationDataFileName = "PlayerConfiguration.csv";

    // Player configuration data
    static int WHP = 200;
    static int WMP = 100;
    static int WSTR = 20;
    static int WINT = 10;
    static int WDEF = 6;
    static int WMDEF = 3;
    static int WSPD = 20;
    static int MHP = 120;
    static int MMP = 200;
    static int MSTR = 10;
    static int MINT = 30;
    static int MDEF = 3;
    static int MMDEF = 6;
    static int MSPD = 20;
    static int NHP = 160;
    static int NMP = 150;
    static int NSTR = 15;
    static int NINT = 15;
    static int NDEF = 5;
    static int NMDEF = 5;
    static int NSPD = 20;

    #endregion

    #region Properties
    // Warrior class functions
    public int PlayerWarriorHP {
        get { return WHP; }
    }

    public int PlayerWarriorMP {
        get { return WMP; }
    }

    public int PlayerWarriorSTR {
        get { return WSTR; }
    }

    public int PlayerWarriorINT {
        get { return WINT; }
    }

    public int PlayerWarriorDEF {
        get { return WDEF; }
    }

    public int PlayerWarriorMDEF {
        get { return WMDEF; }
    }

    public int PlayerWarriorSPD {
        get { return WSPD; }
    }

    // Mage class functions
    public int PlayerMageHP {
        get { return MHP; }
    }

    public int PlayerMageMP {
        get { return MMP; }
    }

    public int PlayerMageSTR {
        get { return MSTR; }
    }

    public int PlayerMageINT {
        get { return MINT; }
    }

    public int PlayerMageDEF {
        get { return MDEF; }
    }

    public int PlayerMageMDEF {
        get { return MMDEF; }
    }

    public int PlayerMageSPD {
        get { return MSPD; }
    }

    // Neutral class functions
    public int PlayerNeutralHP {
        get { return NHP; }
    }

    public int PlayerNeutralMP {
        get { return NMP; }
    }

    public int PlayerNeutralSTR {
        get { return NSTR; }
    }

    public int PlayerNeutralINT {
        get { return NINT; }
    }

    public int PlayerNeutralDEF {
        get { return NDEF; }
    }

    public int PlayerNeutralMDEF {
        get { return NMDEF; }
    }

    public int PlayerNeutralSPD {
        get { return NSPD; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads player configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the player configuration data
    /// </summary>
    public PlayerConfigData() {

        // read and save configuration data from file
        StreamReader input = null;
        try {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e) {
            Console.WriteLine("Error");
        }
        finally {
            // always close input file
            if (input != null) {
                input.Close();
            }
        }

    }

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues) {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(',');
        WHP = int.Parse(values[0]);
        WMP = int.Parse(values[1]);
        WSTR = int.Parse(values[2]);
        WINT = int.Parse(values[3]);
        WDEF = int.Parse(values[4]);
        WMDEF = int.Parse(values[5]);
        WSPD = int.Parse(values[6]);
        MHP = int.Parse(values[7]);
        MMP = int.Parse(values[8]);
        MSTR = int.Parse(values[9]);
        MINT = int.Parse(values[10]);
        MDEF = int.Parse(values[11]);
        MMDEF = int.Parse(values[12]);
        MSPD = int.Parse(values[13]);
        NHP = int.Parse(values[14]);
        NMP = int.Parse(values[15]);
        NSTR = int.Parse(values[16]);
        NINT = int.Parse(values[17]);
        NDEF = int.Parse(values[18]);
        NMDEF = int.Parse(values[19]);
        NSPD = int.Parse(values[20]);
    }

    #endregion
}
