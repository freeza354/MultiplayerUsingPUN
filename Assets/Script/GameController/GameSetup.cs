using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour {

    public static GameSetup GS;

    public Text healthDisplay;
    public Transform[] spawnPoints;

	// Use this for initialization
	void OnEnable () {

        if (GameSetup.GS == null)
        {
            GameSetup.GS = this;
        }

	}
	
    public void DisconnectPlayer()
    {
        StartCoroutine(DisconnectAndLoad());
    }

    IEnumerator DisconnectAndLoad()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
        {
            yield return null;
        }
        SceneManager.LoadScene(MultiplayerScript.multiplayerSetting.menuScene);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
