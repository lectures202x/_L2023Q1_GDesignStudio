using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFile_Text : MonoBehaviour
{
    bool hasHeader = true;    
    
    Dictionary<string, List<Item>> Sources = new Dictionary<string, List<Item>>();    

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
            Item MyItem = new Item(Source, Target, Type, Weight);
            
            if (!Sources.ContainsKey(Source))
            {
                List<Item> MyItems = new List<Item>();
                MyItems.Add(MyItem);
                Sources.Add(Source, MyItems);
            }
            else
            {
                Sources[Source].Add(MyItem);                
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
        foreach (KeyValuePair<string, List<Item>> Pair in Sources)
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

