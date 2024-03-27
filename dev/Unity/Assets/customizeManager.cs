using UnityEngine;

public class customizeManager : MonoBehaviour
{
    [SerializeField] private data data;
    [SerializeField] private pointerController pointer1;
    [SerializeField] private pointerController pointer2;
    [SerializeField] private GameObject readyBar1;
    [SerializeField] private GameObject readyBar2;
    [SerializeField] private GameObject player1Preview;
    [SerializeField] private GameObject player2Preview;

    void Start()
    {
        PlayerPrefs.SetInt(data.p1FaceNum, 0);
        PlayerPrefs.SetInt(data.p1ColorNum, 0);
        PlayerPrefs.SetInt(data.p2FaceNum, 0);
        PlayerPrefs.SetInt(data.p2ColorNum, 0);
        PlayerPrefs.Save();
    }

    public void changeFace(data.playerNum playerNum, int faceNum)
    {
        GameObject previewChanged = player1Preview;
        string faceString = data.p1FaceNum;
        if (playerNum == data.playerNum.player2)
        {
            previewChanged = player2Preview;
            faceString = data.p2FaceNum;
        }

        for (int i = 0; i < data.faceList.Count; i++)
        {
            if (faceNum == i)
            {
                previewChanged.GetComponent<SpriteRenderer>().sprite = data.faceList[i].GetComponent<SpriteRenderer>().sprite;
                PlayerPrefs.SetInt(faceString, i);
                PlayerPrefs.Save();
            }
        }
    }

    public void changeColor(data.playerNum playerNum, int colorNum)
    {
        GameObject previewChanged = player1Preview;
        string colorString = data.p1ColorNum;
        if (playerNum == data.playerNum.player2)
        {
            previewChanged = player2Preview;
            colorString = data.p2ColorNum;
        }
        
        for (int i = 0; i < data.colorList.Count; i++)
        {
            if (colorNum == i)
            {
                previewChanged.GetComponent<SpriteRenderer>().color = data.colorList[i].GetComponent<SpriteRenderer>().color;
                PlayerPrefs.SetInt(colorString, i);
                PlayerPrefs.Save();
            }
        }
    }

    private void Update()
    {
        if (readyBar1.GetComponent<SpriteRenderer>().color == Color.green && readyBar2.GetComponent<SpriteRenderer>().color == Color.green)
        {
            data.navLvlPicker();
        }
    }
}
