using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerCustomization : MonoBehaviour
{
    [Header("Data & Players")]
    [SerializeField] private data data;
    [SerializeField] private playerController player1;
    [SerializeField] private playerController player2;


    // Start is called before the first frame update
    void Start()
    {
        int player1FaceNum = PlayerPrefs.GetInt(data.p1FaceNum, 0);
        player1.GetComponent<SpriteRenderer>().sprite = data.faceList[player1FaceNum].GetComponent<SpriteRenderer>().sprite;
        int player1ColorNum = PlayerPrefs.GetInt(data.p1ColorNum, 0);
        player1.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;

        int player2FaceNum = PlayerPrefs.GetInt(data.p2FaceNum, 0);
        player2.GetComponent<SpriteRenderer>().sprite = data.faceList[player2FaceNum].GetComponent<SpriteRenderer>().sprite;
        int player2ColorNum = PlayerPrefs.GetInt(data.p2ColorNum, 0);
        player2.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
    }
}
