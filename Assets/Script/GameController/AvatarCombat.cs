using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarCombat : MonoBehaviour {

    private PhotonView PV;
    private PlayerSetup avatarSetup;
    public Transform rayOrigin;

    public Text healthDisplay;

	// Use this for initialization
	void Start () {

        PV = GetComponent<PhotonView>();
        avatarSetup = GetComponent<PlayerSetup>();
        healthDisplay = GameSetup.GS.healthDisplay;

	}
	
	// Update is called once per frame
	void Update () {

        if (!PV.IsMine)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            PV.RPC("RPC_Shooting", RpcTarget.All);
        }
        healthDisplay.text = avatarSetup.playerHealth.ToString();

        if (avatarSetup.playerHealth <= 0)
        {
            GameSetup.GS.DisconnectPlayer();
        }

	}

    [PunRPC]
    void RPC_Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward), out hit, 1000))
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.tag == "Player")
            {
                hit.transform.gameObject.GetComponent<PlayerSetup>().playerHealth -= avatarSetup.playerDamage;
            }
        }
        else
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }

}
