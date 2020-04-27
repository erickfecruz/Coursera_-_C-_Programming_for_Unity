using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class EnemyConfigData {
    #region Fields

    const string ConfigurationDataFileName = "EnemyConfiguration.csv";

    // Enemy configuration data
    static int EHP = 130;
    static int EMP = 50;
    static int ESTR = 12;
    static int EINT = 12;
    static int EDEF = 3;
    static int EMDEF = 3;
    static int ESPD = 20;
    #endregion

    #region Properties
    // Enemy class functions
    public int EnemyHP {
        get { return EHP; }
    }

    public int EnemyMP {
        get { return EMP; }
    }

    public int EnemySTR {
        get { return ESTR; }
    }

    public int EnemyINT {
        get { return EINT; }
    }

    public int EnemyDEF {
        get { return EDEF; }
    }

    public int EnemyMDEF {
        get { return EMDEF; }
    }

    public int EnemySPD {
        get { return ESPD; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads enemy configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the enemy configuration data
    /// </summary>
    public EnemyConfigData() {

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
        EHP = int.Parse(values[0]);
        EMP = int.Parse(values[1]);
        ESTR = int.Parse(values[2]);
        EINT = int.Parse(values[3]);
        EDEF = int.Parse(values[4]);
        EMDEF = int.Parse(values[5]);
        ESPD = int.Parse(values[6]);
    }

    #endregion
}
