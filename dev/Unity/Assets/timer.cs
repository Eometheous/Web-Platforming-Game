using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public data data;
    public data.gameMode curGameMode;
    
    private TextMeshProUGUI timeDisplayer;
    private float startTime;
    private float endTime;
    private bool stop;
    
    public void startTimer()
    {
        timeDisplayer = GetComponent<TextMeshProUGUI>();
        startTime = Time.time;
        stop = false;
    }

    public void stopTimer()
    {
        endTime = Time.time;
        stop = true;
        Debug.Log("Time: " + timeDisplayer.text);
        PlayerPrefs.SetFloat(curGameMode + "EndTime", endTime - startTime);
        PlayerPrefs.SetString("gameMode", curGameMode.ToString());
        data.navGameEnd();
    }

    void Update()
    {
        if (!stop)
        {
            float elapsedTime = Time.time - startTime;

            int minutes = (int)(elapsedTime / 60f);
            int seconds = (int)(elapsedTime % 60f);

            if (minutes >= 60)
            {
                minutes = 60;
                seconds = 59;
            }

            string minutesString = minutes.ToString("00");
            string secondsString = seconds.ToString("00");

            string timeString = minutesString + ":" + secondsString;

            timeDisplayer.text = timeString;
        }
    }
}
