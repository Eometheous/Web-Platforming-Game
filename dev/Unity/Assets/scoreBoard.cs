using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData
{
    public string Name { get; set; }
    public string Time { get; set; }
}

public class scoreBoard : MonoBehaviour
{
    public gameMode curGameMode;
    public enum gameMode
    {
        platform,
        pong,
        coop
    }

    [SerializeField]
    public List<string> namesList;

    [SerializeField]
    public List<string> timesList;

    public GameObject exName;
    public GameObject exTime;

    void Start()
    {
        //namesList = new List<string> { "p1", "p2", "p3", "p4" };
        //timesList = new List<string> { "1.01", "4.83", "2.50", "3.12" };

        while (namesList.Count < 20)
        {
            namesList.Add("p" + (namesList.Count + 1));
        }

        while (timesList.Count < 20)
        {
            timesList.Add(Random.Range(1.0f, 10.0f).ToString("F2"));
        }

        if (namesList.Count > 0)
        {
            List<PlayerData> playerDataList = new List<PlayerData>();

            for (int i = 0; i < namesList.Count; i++)
            {
                playerDataList.Add(new PlayerData { Name = namesList[i], Time = timesList[i] });
            }

            //playerDataList.Sort((x, y) => x.Time.CompareTo(y.Time));
            playerDataList.Sort((x, y) => string.Compare(x.Time, y.Time));
            for (int i = 0; i < playerDataList.Count; i++)
            {
                namesList[i] = playerDataList[i].Name;
                timesList[i] = playerDataList[i].Time;
            }

            
            for (int i = 0; i < namesList.Count; i++)
            {
                if (namesList.Count <= 20)
                {
                    GameObject newNameObject = Instantiate(exName, transform);
                    newNameObject.GetComponent<TextMeshProUGUI>().text = namesList[i];
                    float newY = newNameObject.transform.position.y - (i * 0.6f);
                    Vector3 newPosition = new Vector3(newNameObject.transform.position.x, newY, newNameObject.transform.position.z);
                    newNameObject.transform.position = newPosition;


                    GameObject newTimeObject = Instantiate(exTime, transform);
                    newTimeObject.GetComponent<TextMeshProUGUI>().text = timesList[i];
                    Vector3 newPositionT = new Vector3(newTimeObject.transform.position.x, newY, newTimeObject.transform.position.z);
                    newTimeObject.transform.position = newPositionT;
                }
            }
        }


        exName.SetActive(false);
        exTime.SetActive(false);
    }
}
