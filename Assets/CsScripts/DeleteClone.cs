using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteClone : MonoBehaviour
{
    public void DeleteCoins(){
        foreach ( Transform child in this.transform )
        {
            Destroy(child.gameObject);
        }
    }
}
