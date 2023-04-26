using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFile_Text : MonoBehaviour
{
    bool hasHeader = true;    
    
    Dictionary<string, List<SomeItem>> Sources = new Dictionary<string, List<SomeItem>>();    

    void Start()
    {
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
            SomeItem someItem = new SomeItem(Source, Target, Type, Weight);
            
            if (!Sources.ContainsKey(Source))
            {
                List<SomeItem> MyItems = new List<SomeItem>();
                MyItems.Add(someItem);
                Sources.Add(Source, MyItems);
            }
            else
            {
                Sources[Source].Add(someItem);                
            }
        }

        print("Sources:" + Sources.Count);
        /*
        foreach (KeyValuePair<string, List<Item>> item in Sources)
        {
            //Debug.Log("Key = "+ kvp.Key + ", Value = " + kvp.Value);
            print("Key = " + item.Key);
            for(int i = 0; i < item.Value.Count; i++)
            {
                print("["+ item.Key+"] Value.Target = " + item.Value[i].GetTarget());
            }
            print("-----------------");
        }
        */

        // 특정한 
        List<string> SourceWithSpecificTarget = new List<string>();
        string TargetValue = "포스트잇";
        foreach (KeyValuePair<string, List<SomeItem>> Pair in Sources)
        {
            for(int i = 0; i  < Pair.Value.Count; i++)
            {
                string Target = Pair.Value[i].GetTarget();
                if(Target == TargetValue)
                {
                    string Source = Pair.Value[i].GetSource();
                    print(Source);
                    SourceWithSpecificTarget.Add(Source);
                }
            }
        }

        for(int i = 0; i < SourceWithSpecificTarget.Count; i++)
        {
            print("[" + i + "]" + SourceWithSpecificTarget[i]);
        }

        /*
        List<Item> SomeSources = Sources["시각"];
        for (int i = 0; i < SomeSources.Count; i++)
        {
            print(SomeSources[i].GetSource() + ":" + SomeSources[i].GetTarget());
        }
        */
    }
}

public class SomeItem
{
    string Source;
    string Target;
    string Type;
    float Weight;

    public SomeItem(string source, string target, string type, float weight)
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


