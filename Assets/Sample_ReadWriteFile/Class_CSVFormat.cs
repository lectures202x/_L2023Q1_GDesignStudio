using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Mixbox
{
    // CSV Properties
    public bool hasHeader;
    public int startIndex, endIndex;
    public bool hasLineNumbers;
    public List<string> Header; // Col Names

    // Mixbox CSV Column Info
    int numCol = 4;
    string Source;
    string Target;
    string Type;
    float Weight;    

    public Mixbox(string[] _Lines)
    {
        hasHeader = true;
        hasLineNumbers = false;

        if (hasHeader)
        {
            SetHeader(_Lines);
            startIndex = 1;
            endIndex = _Lines.Length - 1;
        }
    }

    public void SetRow(string _Line)
    {
        _Line = _Line.Trim();
        string[] _Variables = _Line.Split(',');
        if (_Variables.Length == numCol)
        {
            Source = _Variables[0];
            Target = _Variables[1];
            Type = _Variables[2];
            Weight = float.Parse(_Variables[3]);
        }
    }

    public void SetHeader(string[] _Lines)
    {
        if (hasHeader)
        {
            Header = new List<string>();
            string HeaderLine = _Lines[0].Trim();
            string[] _HeaderNames = HeaderLine.Split(',');
            if (_HeaderNames.Length == numCol)
            {
                for (int i = 0; i < numCol; i++)
                {
                    Header.Add(_HeaderNames[i]);
                }
            }
        }
    }

    public void PrintHeaders()
    {
        if (hasHeader)
        {
            for (int i = 0; i < Header.Count; i++)
            {
                Debug.Log(Header[i]);
            }
        }
        else
        {
            Debug.Log("NO HEADERS");
        }
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

