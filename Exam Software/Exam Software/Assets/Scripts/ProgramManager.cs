using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ProgramManager : MonoBehaviour
{

    public GameObject Question1;
    public GameObject Question2;
    public GameObject Question3;

    public TextMeshProUGUI name;
    public TextMeshProUGUI id;
    public TextMeshProUGUI time;

    int currentQuestion = 1;


    public float timer { get; private set; }   // An Read Only Timer that can be modified here only
    
    public TextMeshProUGUI finaltime;

    private void Awake()
    {
        Question2.SetActive(false);
        Question3.SetActive(false);

        timer = 0;

        name.text = "Current User:- " + MainManager.instance.name;
        id.text = "User ID:- " + MainManager.instance.id;
  
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();   // Update Timer During Runtime
    }

    public void Que1Next()
    {
        TMP_InputField solution1 = GameObject.Find("Soln1").GetComponent<TMP_InputField>();
        MainManager.instance.solution1 = solution1.text;
        Debug.Log("Solution Saved :- " + MainManager.instance.solution1);
        Question1.SetActive(false);
        currentQuestion++;

        Question2.SetActive(true);
    }

    public void Que2Next()
    {
        TMP_InputField solution2 = GameObject.Find("Soln2").GetComponent<TMP_InputField>();
        MainManager.instance.solution2 = solution2.text;
        Debug.Log("Solution Saved :- " + MainManager.instance.solution2);
        Question2.SetActive(false);
        currentQuestion++;

        Question3.SetActive(true);
    }
    public void Que2Back()
    {
        Question2.SetActive(false);
        Question1.SetActive(true);
    }
    public void OnClickSubmit()
    {
        TMP_InputField solution3 = GameObject.Find("Soln3").GetComponent<TMP_InputField>();
        MainManager.instance.solution3 = solution3.text;
        Debug.Log("Solution Saved :- " + MainManager.instance.solution3);
        Question3.SetActive(false);


        if (MainManager.instance.solution1 != null && 
           MainManager.instance.solution2 != null && 
           MainManager.instance.solution3 != null){

            MainManager.instance.timetaken = timer;

            SaveDataToJson();

            Debug.Log("Submitted Succcessfully");
            SceneManager.LoadScene(2);     // Load scene 3 final scene


        }
        else
        {
            Debug.Log("Attempt all Questions");
        }
    }
    public void Que3Back()
    {
        Question3.SetActive(false);
        Question2.SetActive(true);
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        time.text = "Time:- " + Convert.ToString((Convert.ToInt64(timer)));   //UI Output
    }

    public void SaveDataToJson()
    {
        SetData student = new SetData();

        student.name = MainManager.instance.name;
        student.id = MainManager.instance.id;

        student.solution1 = MainManager.instance.solution1;
        student.solution2 = MainManager.instance.solution2;
        student.solution3 = MainManager.instance.solution3;
        student.timetaken = MainManager.instance.timetaken;

        string json = JsonUtility.ToJson(student, true);
        Debug.Log(json);

        File.AppendAllText("D:/UNITY/Unity Softwares/logindata.json", json);

        Debug.Log("Data Saved Successfully");

    }

}

[System.Serializable]
public class SetData
{
    public string name;
    public string id;
    public string solution1;
    public string solution2;
    public string solution3;
    public float timetaken;
}
