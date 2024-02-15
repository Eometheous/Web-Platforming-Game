using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gameManage : MonoBehaviour
{
    public playerController player1;
    public playerController player2;
    public float verticalForceMultiplier;
    public float horizontalForceMultiplier;
    public float maxVerticalVelocity;
    public float maxHorizontalVelocity;
    public float slowFactor;

    void Start()
    {
        resetPlayersKeys();
        verticalForceMultiplier = 10f;
        horizontalForceMultiplier = 5f;
        maxVerticalVelocity = 10f;
        maxHorizontalVelocity = 10f;
        slowFactor = 0.5f;
    }

    void Update()
    {
        resetDefault();
    }

    public void resetDefault()
    {
        player1.verticalForceMultiplier = verticalForceMultiplier;
        player1.forceMultiplier = horizontalForceMultiplier;
        player1.maxVerticalVelocity = maxVerticalVelocity;
        player1.maxHorizontalVelocity = maxHorizontalVelocity;
        player1.slowFactor = slowFactor;
        player2.verticalForceMultiplier = verticalForceMultiplier;
        player2.forceMultiplier = horizontalForceMultiplier;
        player2.maxVerticalVelocity = maxVerticalVelocity;
        player2.maxHorizontalVelocity = maxHorizontalVelocity;
        player2.slowFactor = slowFactor;
    }

    public void resetPlayersKeys()
    {
        player1.changeKeys(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
        player2.changeKeys(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);
    }
}
