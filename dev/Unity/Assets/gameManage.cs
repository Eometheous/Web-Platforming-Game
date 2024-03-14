using UnityEngine;

public class gameManage : MonoBehaviour
{
    [Header("Data & Players")]
    [SerializeField] private data data;
    [SerializeField] private playerController player1;
    [SerializeField] private playerController player2;
    [Space(15)]

    [Header("Icons & Hearts")]
    [SerializeField] private GameObject p1Icon;
    [SerializeField] private GameObject p1Heart1;
    [SerializeField] private GameObject p1Heart2;
    [SerializeField] private GameObject p1Heart3;
    [SerializeField] private GameObject p2Icon;
    [SerializeField] private GameObject p2Heart1;
    [SerializeField] private GameObject p2Heart2;
    [SerializeField] private GameObject p2Heart3;

    void Start()
    {
        int player1FaceNum = PlayerPrefs.GetInt(data.p1FaceNum, 0);
        player1.GetComponent<SpriteRenderer>().sprite = data.faceList[player1FaceNum].GetComponent<SpriteRenderer>().sprite;
        int player1ColorNum = PlayerPrefs.GetInt(data.p1ColorNum, 0);
        player1.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;
        p1Icon.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;
        p1Heart1.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;
        p1Heart2.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;
        p1Heart3.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;

        int player2FaceNum = PlayerPrefs.GetInt(data.p2FaceNum, 0);
        player2.GetComponent<SpriteRenderer>().sprite = data.faceList[player2FaceNum].GetComponent<SpriteRenderer>().sprite;
        int player2ColorNum = PlayerPrefs.GetInt(data.p2ColorNum, 0);
        player2.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
        p2Icon.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
        p2Heart1.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
        p2Heart2.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
        p2Heart3.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
    }

    public void resetDefault()
    {
        player1.forceMultiplier = data.forceMultiplier;
        player2.forceMultiplier = data.forceMultiplier;
        player1.updateKeys();
        player2.updateKeys();
    }
}
