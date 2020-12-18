using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerSelectorMultiplayer : NetworkBehaviour
{
    public Image[] selectionBoxes;
    public GameObject[] prefabs;
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
        foreach (var img in this.selectionBoxes)
        {
            img.gameObject.SetActive(false);
        }

        this.selectionBoxes[index].gameObject.SetActive(true);
        PlayerStorageMultiplayer.playerPrefab = this.prefabs[index];
    }
}
