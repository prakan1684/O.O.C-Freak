using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOfPlayer : MonoBehaviour
{
    GameObject player;
    bool followPlayer_POV = true;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer_POV)
        {
            Cam_on_player();
        }

    }

    public void setFollowPlayer(bool value)
    {
        followPlayer_POV = value;
    }

    void Cam_on_player()
    {
        Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPosition;
    }
}


