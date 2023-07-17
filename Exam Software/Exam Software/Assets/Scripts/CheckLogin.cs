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
        SaveToJson();
        SceneManager.LoadScene(1);
    }

   

    // Use of Abstraction
    void SetDetails()
    {
        MainManager.instance.name = name.text;   // Name is set for the session
        MainManager.instance.id = id.text;       // ID is set for the session

        Debug.Log("Current User:- " + name.text + "ID:- " + id.text);
    }

    void SaveToJson()
    {
        SaveData demouser = new SaveData();   // demouser is new instance to the class savedata

        demouser.name = name.text;
        demouser.id = id.text;

        string json = JsonUtility.ToJson(demouser);   // Here created a json string
        File.WriteAllText(Application.dataPath + "/logindata.json", json);  // here we wrote a string to json file

         Debug.Log("Data Saved Successfully At " + Application.dataPath);

    }

}

[System.Serializable]
public class SaveData
{
    public string name;
    public string id;
}


