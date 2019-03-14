﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerADDON : MonoBehaviour
{
    // ADD TO PLAYER PREFAB
    // have Player set canvas to enabled?
    // add in press r to restart

    private Text loseText;

    private void Start()
    {
        Text[] texts = FindObjectsOfType<Text>();
        foreach (Text text in texts)
        {
            if (text.name == "LoseText")
            {
                loseText = text;
                loseText.enabled = false;
            }
        }
        if (loseText == null)
        {
            Debug.Log("ERROR: GameCanvas is not present in the scene.");
        }

        if (!GetComponent<Player>())
        {
            Debug.Log("ERROR: PlayerADDON Component placed on GameObject without Player Script.");
        }
    }

    private void Update()
    {
        if (loseText.enabled)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            loseText.enabled = true;
        }
    }


}
