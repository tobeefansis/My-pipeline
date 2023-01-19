using System.Collections.Generic;
using UnityEngine;

public static class LoadSystem
{
    public static List<string> LoadValues(string key)
    {
        var dataString =   PlayerPrefs.GetString(key);
        var data = JsonUtility.FromJson<Data>(dataString);
        return data==null ? new List<string>() : data.values;
    }
    public static string LoadValue(string key)
    {
        var dataString =   PlayerPrefs.GetString(key);
        var data = JsonUtility.FromJson<Data>(dataString);
        return data==null ? "" : data.value;
    }
}
