﻿using Photon.Pun;
using UnityEngine;

public class Movement : MonoBehaviourPun
{
    [SerializeField] private float movementSpeed = 100.0f;
    [SerializeField] private TextMesh playerName = null;
    private void Start()
    {
        playerName.text = photonView.Owner.NickName;
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            TakeInput();
        }
    }

    private void TakeInput()
    {
        var movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical"),
            z = 0.0f,
        }.normalized;
        transform.Translate(movement * movementSpeed * Time.deltaTime);
        //controller.SimpleMove(movement * movementSpeed * Time.deltaTime);
        updateText();
    }

    public void updateText()
    {
        playerName.text = photonView.Owner.NickName;
    }
}
