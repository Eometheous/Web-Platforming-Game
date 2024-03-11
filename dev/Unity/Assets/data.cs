using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    public GameObject face1;
    public GameObject face2;
    public GameObject face3;

    public GameObject color1;
    public GameObject color2;
    public GameObject color3;
    public GameObject color4;
    public GameObject color5;
    public GameObject color6;
    public GameObject color7;

    public List<GameObject> faceList;
    public List<GameObject> colorList;

    public enum powerUpType
    {
        reverseGravity,
        reverseKeys,
        push
    }

    public enum curActivePowerUp
    {
        none,
        push
    }
    public enum playerNum
    {
        player1,
        player2
    }

    public void initList()
    {
        faceList = new List<GameObject> { face1, face2, face3 };
        colorList = new List<GameObject> { color1, color2, color3, color4, color5, color6, color7 };
    }
}
