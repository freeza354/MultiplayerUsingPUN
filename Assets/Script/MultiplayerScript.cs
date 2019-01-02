using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerScript : MonoBehaviour {

    public static MultiplayerScript multiplayerSetting;

    public bool delayedStart;
    public int maxPlayers;

    public int menuScene;
    public int multiplayerScene;

    private void Awake()
    {
        if (MultiplayerScript.multiplayerSetting == null)
        {
            MultiplayerScript.multiplayerSetting = this;
        }
        else
        {
            if (MultiplayerScript.multiplayerSetting != this)
            {
                Destroy(this.gameObject);
            }
        }

        DontDestroyOnLoad(this.gameObject);

    }
}
