using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    public float effectTime = 60.0f;
    private bool startTimer;
    //public playerController affectedPlayer;
    //public bool attackPowerUps;
    public bool initEffect;
    //public bool play1Affected;

    public enum powerUpType
    {
        reverseGravity,
        reverseKeys
    }
    public powerUpType Type;

    private playerController playerAffected;
    public playerController player1;
    public playerController player2;

    void Start()
    {
        initEffect = false;
        startTimer = false;
    }

    void Update()
    {
        if (initEffect)
        {
            switch (Type)
            {
                case powerUpType.reverseGravity:
                    reverseGravity();
                    break;
                case powerUpType.reverseKeys:
                    reverseKeys();
                    break;
            }
            initEffect = false;
        }
        if (startTimer)
        {
            effectTime -= Time.deltaTime;
            if (effectTime <= 0)
            {
                switch (Type)
                {
                    case powerUpType.reverseGravity:
                        reverseGravity();
                        break;
                    case powerUpType.reverseKeys:
                        reverseKeys();
                        break;
                }
                Destroy(gameObject);
            }
        }
    }

    private void reverseGravity()
    {

        playerAffected.GetComponent<Rigidbody2D>().gravityScale *= -1;
        playerAffected.reverseJump = !playerAffected.reverseJump;
    }

    private void reverseKeys()
    {
        playerAffected.reverseKeys = !playerAffected.reverseKeys;
    }

    private bool isAttackPowerUp()
    {
        bool isAttack = false;
        switch (Type)
        {
            case powerUpType.reverseGravity:
            case powerUpType.reverseKeys:
                isAttack = true;
                break;
        }
        return isAttack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerAffected == null)
            {
                //Debug.Log(collision.GetComponent<playerController>() == player1.GetComponent<playerController>());
                bool play1Affected = (collision.GetComponent<playerController>() == player1.GetComponent<playerController>() && !isAttackPowerUp()) ||
                                     (collision.GetComponent<playerController>() == player2.GetComponent<playerController>() && isAttackPowerUp());
                if (play1Affected)
                    playerAffected = player1.GetComponent<playerController>();
                else
                    playerAffected = player2.GetComponent<playerController>();

                GetComponent<Renderer>().enabled = false;
                initEffect = true;
                startTimer = true;
            }
        }
    }
}
