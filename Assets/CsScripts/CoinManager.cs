using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public Vector3 coinOffset;
    int coinCount;

    void CoinReset(){
        coinOffset = new Vector3(-0.38f, 1f, 0.2f);
    }

    void Start()
    {
        CoinReset();
    }

    void Update()
    {
        
    }
}
