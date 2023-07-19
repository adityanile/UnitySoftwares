using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MainManager : MonoBehaviour
{
    
    string[] json;
    public GetData[] student;
    string path = "D:/UNITY/Unity Softwares/logindata.json";

    public string totaldata = "";

    public TextMeshProUGUI count;
    public GameObject panel;
    public TMP_InputField displaydata;
    public GameObject ui;

    void Start()
    {
        FromJsonToClass();
        count.text = "Enteries Found:- " + HowManyEnteries();

        displaydata.text = totaldata;
        ui.SetActive(false);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickReset()
    {
        File.WriteAllText(path, "");

        totaldata = "";
        displaydata.text = totaldata;
    }



    public void OnClickNext()
    {
        panel.SetActive(false);
        ui.gameObject.SetActive(true);
    }


    public void FromJsonToClass()
    {
        

        if (File.Exists(path))  // Find if the file is present
        {
             json = File.ReadAllLines(path);      // array of string containing line by line string

            if (HowManyEnteries() != 0)
            {
                ReadEnteries(HowManyEnteries());
            }

        }
        else
        {
            Debug.Log("Error in Finding Source File");
        }
    }

    public int HowManyEnteries()
    {
        if (json.Length != 0)
        {
            int count = json.Length / 7;      // All enteries repeat after 7th line
            return count;
        }
        else
        {
            return 0;
        }
    }

    public void ReadEnteries(int n)
    {
        int c = 1;
        student = new GetData[n];   // Create array for Number of enteries present in the source file

        for (int i = 0; i < n; i++)
        {
            string student1 = "";        // here student1 is a complete that contain a complete perticular entery at a time

            for (int j = i * 7; j < c * 7; j++)
            {
                if(i != 0 && j % 7 == 0)
                {
                    json[j] = "{ ";
                }
                student1 = student1 + json[j];
            }

            student1 += '}';

            // Converting json data to object is important for us to manipulate data
            // Here Data is converted to object in form of student array to access

            student[i] = JsonUtility.FromJson<GetData>(student1);
            DisplayData(student[i]);
            Debug.Log("Data Written Succesfully for " + student[i].name);

            c++;
        }

        // Here the array is completely formed add code here to do operation on complete array
        
    }

    public void DisplayData(GetData student)
    {

        totaldata += "Name:- " + student.name + "\n" +
                     "ID:- " + student.id + "\n\n" +
                     "Answer 1 :- " + student.solution1 + "\n\n" +
                     "Answer 2 :- " + student.solution2 + "\n\n" +
                     "Answer 3 :- " + student.solution3 + "\n\n" +
                     "Time Taken :- " + student.timetaken + "\n\n\n";
    }

}

public class GetData{

    public string name;
    public string id;
    public string solution1;
    public string solution2;
    public string solution3;
    public float timetaken;
}
