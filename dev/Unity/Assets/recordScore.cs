using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class recordScore : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TMP_InputField nameSaved;
    private float elapsedTime;
    private string timeString;

    void Start()
    {
        elapsedTime = PlayerPrefs.GetFloat(PlayerPrefs.GetString("gameMode") + "EndTime");

        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);

        if (minutes >= 60)
        {
            minutes = 60;
            seconds = 59;
        }

        string minutesString = minutes.ToString("00");
        string secondsString = seconds.ToString("00");

        timeString = minutesString + ":" + secondsString;
        time.text = "Time: " + timeString;
    }

    public void saveScore()
    {
        string PlayerPrefsKey = PlayerPrefs.GetString("gameMode") + "NameList";
        string PlayerPrefsKeyTime = PlayerPrefs.GetString("gameMode") + "TimeList";

        //PlayerPrefs.DeleteKey(PlayerPrefsKey);
        //PlayerPrefs.DeleteKey(PlayerPrefsKeyTime);

        if (PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            List<string> nameList = PlayerPrefs.GetString(PlayerPrefsKey).Split(',').ToList();
            List<string> timeList = PlayerPrefs.GetString(PlayerPrefsKeyTime).Split(',').ToList();

            nameList.Add(nameSaved.text);
            timeList.Add(timeString);

            string joinedStringName = string.Join(",", nameList.ToArray());
            string joinedStringTime = string.Join(",", timeList.ToArray());

            Debug.Log(joinedStringName);
            Debug.Log(joinedStringTime);

            PlayerPrefs.SetString(PlayerPrefsKey, joinedStringName);
            PlayerPrefs.SetString(PlayerPrefsKeyTime, joinedStringTime);
            PlayerPrefs.Save();

            Debug.Log(PlayerPrefs.GetString(PlayerPrefsKey));
            Debug.Log(PlayerPrefs.GetString(PlayerPrefsKeyTime));
        } else
        {
            List<string> nameList = new List<string>();
            List<string> timeList = new List<string>();

            nameList.Add(nameSaved.text);
            timeList.Add(timeString);

            string joinedStringName = string.Join(",", nameList.ToArray());
            string joinedStringTime = string.Join(",", timeList.ToArray());

            Debug.Log(joinedStringName);
            Debug.Log(joinedStringTime);

            PlayerPrefs.SetString(PlayerPrefsKey, joinedStringName);
            PlayerPrefs.SetString(PlayerPrefsKeyTime, joinedStringTime);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("Scores");
    }
}
