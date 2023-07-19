using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.IO;
using UnityEngine.SceneManagement;

public class CheckLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField name;
    [SerializeField] private TMP_InputField id;

    public void Awake()
    {
        

    }

    public void OnClickStart()
    {
        SetDetails(); 
        SceneManager.LoadScene(1);
    }

   

    // Use of Abstraction
    void SetDetails()
    {
        MainManager.instance.name = name.text;   // Name is set for the session
        MainManager.instance.id = id.text;       // ID is set for the session

        Debug.Log("Current User:- " + name.text + "ID:- " + id.text);
    }

}


