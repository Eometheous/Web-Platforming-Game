using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    public float effectTime;
    public playerController affectedPlayer;
    public playerController player1;
    public playerController player2;
    public string type;
    public bool attackPowerUps;
    public bool initEffect;
    public bool play1Affected;

    void Start()
    {
        initEffect = false;
    }

    void Update()
    {
        if (affectedPlayer != null)
        {
            if (String.Equals(type, "reverseGravity"))
            {
                reverseGravity();
            } else if (String.Equals(type, "reverseKeys"))
            {
                reverseKeys();
            }
        }
    }

    private void reverseGravity()
    {
        if (initEffect)
        {
            affectedPlayer.GetComponent<Rigidbody2D>().gravityScale *= -1;
            affectedPlayer.reverseJump = true;
            initEffect = false;
        }
    }

    private void reverseKeys()
    {
        if (initEffect)
        {
            affectedPlayer.reverseKeys = true;
            initEffect = false;
        }
    }

    private bool isAttackPowerUp()
    {
        if (String.Equals(type, "reverseGravity") || String.Equals(type, "reverseKeys"))
            return true;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (affectedPlayer == null)
            {
                Debug.Log(collision.GetComponent<playerController>() == player1.GetComponent<playerController>());
                play1Affected = (collision.GetComponent<playerController>() == player1.GetComponent<playerController>() && !isAttackPowerUp()) ||
                                (collision.GetComponent<playerController>() == player2.GetComponent<playerController>() && isAttackPowerUp());
                if (play1Affected)
                    affectedPlayer = player1.GetComponent<playerController>();
                else
                    affectedPlayer = player2.GetComponent<playerController>();

                //GetComponent<GameObject>().SetActive(false);
                GetComponent<Renderer>().enabled = false;
                initEffect = true;
            }
        }
    }
}
