using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSwitch : MonoBehaviour
{
    public UnityEngine.GameObject HeavenPlayer;
    public UnityEngine.GameObject HellPlayer;
    private HeavenPlayer player1;
    private HellPlayer player2;
    public CinemachineVirtualCamera followcam;
    private int count = 0;
    private void Awake()
    {
        player1 = HeavenPlayer.GetComponent<HeavenPlayer>();
        player2 = HellPlayer.GetComponent<HellPlayer>();
    }
    void Start()
    {
        player1.enabled = true;
        followcam.Follow = player1.transform;
        player2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            player2.enabled = true;
            followcam.Follow = player2.transform;
            player1.setVelocity(0, 0);
            player1.playerStateMachine.ChangeState(player1.idleState);
            player1.enabled = false;
            count++;
        }
        else if (count == 2)
        {
            player1.enabled = true;
            followcam.Follow = player1.transform;
            player2.setVelocity(0, 0);
           
            player2.enabled = false;
            count = 0;
        }
    }

    void switchPlayer(BasePlayer player , CinemachineVirtualCamera virtualCamera)
    {
        player.enabled = true;
        virtualCamera.Follow = player.transform;
    }
}