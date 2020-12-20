using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerSelectorMultiplayer : NetworkBehaviour
{
    public Image[] selectionBoxes;
    public GameObject[] prefabs;


    private NetworkManagerLobby room;
    private NetworkManagerLobby Room
    {
        get
        {
            if (room != null) { return room; }
            return room = NetworkManager.singleton as NetworkManagerLobby;
        }
    }

    void Start()
    {
        foreach (var img in this.selectionBoxes)
        {
            img.gameObject.SetActive(false);
        }

        this.Select(0);
    }

    public void Select(int index)
    {
        //Debug.Log(index);

        foreach (var img in this.selectionBoxes)
        {
            img.gameObject.SetActive(false);
        }

        this.selectionBoxes[index].gameObject.SetActive(true);
        //Room.playerSpawnSystem.GetComponent<PlayerSpawnSystem>().playerPrefab = this.prefabs[index];

        Room.playerSpawnSystem.GetComponent<PlayerSpawnSystem>().playerPrefab[index] = (this.prefabs[index]);
    }
}
