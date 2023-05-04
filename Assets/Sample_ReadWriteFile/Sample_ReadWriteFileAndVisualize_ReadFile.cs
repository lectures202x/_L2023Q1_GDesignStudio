using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_ReadWriteFileAndVisualize_ReadFile : MonoBehaviour
{
    private void Start()
    {
        Mixbox MB = new Mixbox();
        CSVProcessor CSV = new CSVProcessor();
        CSV.SetPath("mixbox_csv");
    }
}

