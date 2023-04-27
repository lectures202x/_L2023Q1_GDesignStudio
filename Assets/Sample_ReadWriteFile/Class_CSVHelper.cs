using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVHelper
{
    String FilePath;

    // CSV Common Structure
    List<String> Keys;                      // Row Names
    List<String> Values;                    // Row Values
    Dictionary<string, List<String>> Col;   // Single Column 
    List<Dictionary<String, List<String>>> CSVData; // Collection of Cols

    // Target CSV
    MixboxCSV CSV;

    public CSVHelper()
    {
        FilePath = "mixbox_csv";
        TextAsset Result = ReadFile(FilePath);
        String[] Lines = GetLines(Result);

        MixboxCSV MB = new MixboxCSV(Lines);
        MB.PrintHeaders();
        
    }

    public TextAsset ReadFile(string _FilePath)
    {
        FilePath = _FilePath;
        TextAsset textAsset = Resources.Load(FilePath) as TextAsset;
        return textAsset;
    }

    public String[] GetLines(TextAsset _TextAsset)
    {
        String File = _TextAsset.text;
        String[] Lines = File.Split('\n');
        return Lines;
    }

    public String[] GetVariablesFromLine(string _Line)
    {
        _Line = _Line.Trim();
        String[] Variables = _Line.Split(',');
        return Variables;
    }



    /*
    public void Read(string _FilePath)
    {
        FilePath = _FilePath;
        TextAsset MyFile = Resources.Load("mixbox_csv") as TextAsset;
        String File = MyFile.text;
        //print(File);

        String[] Lines = File.Split('\n');
        //print(Lines.Length);

        int startIndex = 0;
        int endIndex = Lines.Length;
        if (hasHeader)
        {
            startIndex = 1;
            endIndex = endIndex - 1;
        }

        for (int i = startIndex; i < endIndex; i++)
        {
            String[] Line = Lines[i].Split(",");
            //print(i + ":" + Line[0] + "\t" + Line[1] + "\t" + Line[2] + "\t" + Line[3]);
            string Source = Line[0];
            string Target = Line[1];
            string Type = Line[2];
            float Weight = float.Parse(Line[3]);
            _MixboxItem MyItem = new _MixboxItem(Source, Target, Type, Weight);

            if (!Sources.ContainsKey(Source))
            {
                List<_MixboxItem> MyItems = new List<_MixboxItem>();
                MyItems.Add(MyItem);
                Sources.Add(Source, MyItems);
            }
            else
            {
                Sources[Source].Add(MyItem);
            }
        }

        Debug.Log("Sources:" + Sources.Count);


        // 특정한 
        List<string> SourceWithSpecificTarget = new List<string>();
        string TargetValue = "포스트잇";
        foreach (KeyValuePair<string, List<_MixboxItem>> Pair in Sources)
        {
            for (int i = 0; i < Pair.Value.Count; i++)
            {
                string Target = Pair.Value[i].GetTarget();
                if (Target == TargetValue)
                {
                    string Source = Pair.Value[i].GetSource();
                    Debug.Log(Source);
                    SourceWithSpecificTarget.Add(Source);
                }
            }
        }

        for (int i = 0; i < SourceWithSpecificTarget.Count; i++)
        {
            Debug.Log("[" + i + "]" + SourceWithSpecificTarget[i]);
        }

    */
    

}
