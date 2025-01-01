using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneGen : MonoBehaviour
{
    [SerializeField]
    GameObject mainCoin;
    [SerializeField]
    GameObject cloneCoin;
    [SerializeField]
    Transform parent;
    int deltaNum;
    int nowNum;

    void Start()
    {
        nowNum = 0;
        deltaNum = 0;
    }

    void Update()
    {
        nowNum = GetComponent<CoinManager>().coinCount;

        if(deltaNum != nowNum && mainCoin.GetComponent<CoinThrow>().coinState > 0){
            Instantiate(cloneCoin, parent);
        }

        deltaNum = nowNum;
    }
}
