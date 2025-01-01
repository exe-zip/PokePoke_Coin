using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCoinMove : MonoBehaviour
{
    [SerializeField]
    GameObject CM;
    void Start()
    {
        
    }

    void Update()
    {
        if(this.GetComponent<CoinThrow>().coinState > 0 && this.GetComponent<CoinThrow>().throwFlag){
            transform.position += (CM.GetComponent<CoinManager>().coinOffset - transform.position) * 0.05f;
        }
    }
}
