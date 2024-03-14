using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public delegate void FiveSeconds();
    public static event FiveSeconds OnFiveSeconds;
    public float difference;

    private void Start()
    {
        difference = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.realtimeSinceStartup - difference) >= 5 && OnFiveSeconds != null)
        {
            OnFiveSeconds.Invoke();
        }
    }
}
