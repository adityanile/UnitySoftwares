using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; }  // Here we have encapsulated this so that other scriptes can read instnace but only this script can set it

    public string name;
    public string id;

    public string solution1;
    public string solution2; 
    public string solution3;

    public float timetaken;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);   // Preserve This GameObject

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
