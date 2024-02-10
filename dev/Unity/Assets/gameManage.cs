using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gameManage : MonoBehaviour
{
    public playerController player1;
    public playerController player2;
    public float verticalForceMultiplier = 10f;
    public float horizontalForceMultiplier = 5f;
    public float maxVerticalVelocity = 10f;
    public float maxHorizontalVelocity = 5f;

    void Start()
    {
        resetDefault(); 
    }

    void Update()
    {
        // TEMP
        player1.verticalForceMultiplier = verticalForceMultiplier;
        player1.horizontalForceMultiplier = horizontalForceMultiplier;
        player1.maxVerticalVelocity = maxVerticalVelocity;
        player1.maxHorizontalVelocity = maxHorizontalVelocity;
        player2.verticalForceMultiplier = verticalForceMultiplier;
        player2.horizontalForceMultiplier = horizontalForceMultiplier;
        player2.maxVerticalVelocity = maxVerticalVelocity;
        player2.maxHorizontalVelocity = maxHorizontalVelocity;
    }

    public void resetDefault()
    {
        player1.changeKeys(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
        player2.changeKeys(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);

        player1.verticalForceMultiplier = verticalForceMultiplier;
        player1.horizontalForceMultiplier = horizontalForceMultiplier;
        player1.maxVerticalVelocity = maxVerticalVelocity;
        player1.maxHorizontalVelocity = maxHorizontalVelocity;
        player2.verticalForceMultiplier = verticalForceMultiplier;
        player2.horizontalForceMultiplier = horizontalForceMultiplier;
        player2.maxVerticalVelocity = maxVerticalVelocity;
        player2.maxHorizontalVelocity = maxHorizontalVelocity;
    }
}
