using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCon : MonoBehaviour
{
    [SerializeField]
    GameObject WTop;
    [SerializeField]
    GameObject WBot;
    [SerializeField]
    GameObject WRight;
    [SerializeField]
    GameObject WLeft;
    Transform WTT;
    Transform WBT;
    Transform WRT;
    Transform WLT;
    float w ;
    float h ;
    void Start()
    {
        w = Screen.width;
        h = Screen.height;

        WTT = WTop.transform;
        WBT = WBot.transform;
        WRT = WRight.transform;
        WLT = WLeft.transform;
    }

    void Update()
    {
        WRT.position = new Vector3(w/h, 0, 0);
        WLT.position = new Vector3(-1 * (w/h), 0, 0);
    }
}
