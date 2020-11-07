using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    public GameObject playerObj, enemyObj;
    public GameObject win, lose;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WinCondition();
    }
    public void WinCondition()
    {
        if (playerObj == null && enemyObj != null)
        {
            lose.SetActive(true);
        }
        else if(enemyObj == null)
        {
            win.SetActive(true);
        }
    }
}
