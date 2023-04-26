using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_ReadWriteFileAndVisualize_ReadFile : MonoBehaviour
{
    bool hasHeader = true;

    Dictionary<string, List<_MixboxItem>> Sources = new Dictionary<string, List<_MixboxItem>>();

    void Start()
    {
        PublicClass PC = new PublicClass();
        PC.DoSomething(10);
        

        TextAsset MyFile = Resources.Load("mixbox_csv") as TextAsset;
        String File = MyFile.text;

        String[] Lines = File.Split('\n');

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

        print("Sources:" + Sources.Count);

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
                    print(Source);
                    SourceWithSpecificTarget.Add(Source);
                }
            }
        }

        for (int i = 0; i < SourceWithSpecificTarget.Count; i++)
        {
            print("[" + i + "]" + SourceWithSpecificTarget[i]);
        }
    }
}

