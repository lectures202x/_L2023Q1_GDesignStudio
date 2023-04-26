using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MixboxItem
{
    string Source;
    string Target;
    string Type;
    float Weight;

    public _MixboxItem(string source, string target, string type, float weight)
    {
        Source = source;
        Target = target;
        Type = type;
        Weight = weight;
    }

    public string GetSource()
    {
        return Source;
    }

    public string GetTarget()
    {
        return Target;
    }
    /*
    public string GetType()
    {
        return Type;
    }
    */
    public float GetWeight()
    {
        return Weight;
    }
    public void Show()
    {
        Debug.Log(Source + " " + Target + " " + Type + " " + Weight);
    }
}

