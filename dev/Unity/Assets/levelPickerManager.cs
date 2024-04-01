using TMPro;
using UnityEngine;

public class levelPickerManager : MonoBehaviour
{
    public data data;

    public string currentPick = "";
    public int count = 10;
    public float startTime;

    public pointerController2 p1;
    public pointerController2 p2;
    public TextMeshProUGUI countDownText;
    public GameObject pickArrow;


    void Start()
    {
        changeArrowLocation();
        startTime = Time.time;
    }

    void Update()
    {
        if (p1.hoverOn && p2.hoverOn)
        {
            if (p1.hoverOn.gameObject.tag == "powerUp" && currentPick == "")
            {
                currentPick = p1.hoverOn.gameObject.name;
            }
            else if (p2.hoverOn.gameObject.tag == "powerUp" && currentPick == "")
            {
                currentPick = p2.hoverOn.gameObject.name;
            }

            if (p1.hoverOn.gameObject.tag != "powerUp" && p2.hoverOn.gameObject.tag == "powerUp")
            {
                currentPick = p2.hoverOn.gameObject.name;
            }
            else if (p1.hoverOn.gameObject.tag == "powerUp" && p2.hoverOn.gameObject.tag != "powerUp")
            {
                currentPick = p1.hoverOn.gameObject.name;
            }
        }
        changeArrowLocation();

        countDownText.text = ((int)(startTime + 10 - Time.time)).ToString();

        if (countDownText.text == "0")
        {
            if (currentPick == "Lvl1")
            {
                data.navBasicLevel();
            }
            else if (currentPick == "Lvl2")
            {
                data.navPong();
            }
            else if (currentPick == "Lvl3")
            {
                data.navStartGame();
            }
            else
            {
                data.navStartGame();
            }
        }
    }

    void changeArrowLocation()
    {
        if (currentPick == "Lvl1")
        {
            pickArrow.GetComponent<SpriteRenderer>().enabled = true;
            pickArrow.transform.localPosition = new Vector3(-5.0f, pickArrow.transform.localPosition.y, pickArrow.transform.localPosition.z);
        } else if (currentPick == "Lvl2")
        {
            pickArrow.GetComponent<SpriteRenderer>().enabled = true;
            pickArrow.transform.localPosition = new Vector3(0.0f, pickArrow.transform.localPosition.y, pickArrow.transform.localPosition.z);
        } else if (currentPick == "Lvl3")
        {
            pickArrow.GetComponent<SpriteRenderer>().enabled = true;
            pickArrow.transform.localPosition = new Vector3(5.0f, pickArrow.transform.localPosition.y, pickArrow.transform.localPosition.z);
        } else {
            pickArrow.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
