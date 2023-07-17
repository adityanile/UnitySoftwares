using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FinalManager : MonoBehaviour
{
    public TextMeshProUGUI time;

    private void Awake()
    {
        time.text = "Time Taken:- " + Convert.ToString((Convert.ToInt64(MainManager.instance.timetaken)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
