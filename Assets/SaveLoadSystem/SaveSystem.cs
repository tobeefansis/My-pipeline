using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void Save(string key, List<string> values)
    {
        var data = new Data(){values = values};
        var dataString = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key,dataString);
    }
    public static void Save(string key, string value)
    {
        var data = new Data(){value = value};
        var dataString = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key,dataString);
    }
}
