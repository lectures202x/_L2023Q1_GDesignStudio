using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicClass
{
    public PublicClass()
    {
        Debug.Log("this is public class");
    }

    public void DoSomething(int a)
    {
        Debug.Log("[" + a + "] Do Something");
    }
}
