using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public Transform ChallengeRoom;

    public void Teleportation()
    {
        player.transform.position = ChallengeRoom.position;
    }
   
}
