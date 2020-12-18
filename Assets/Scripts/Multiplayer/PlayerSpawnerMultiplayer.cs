using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSpawnerMultiplayer : NetworkBehaviour
{
    void Start()
    {
        Instantiate(PlayerStorageMultiplayer.playerPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
