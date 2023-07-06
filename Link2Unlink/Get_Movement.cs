using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Movement : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public bool done = false;
   public void start_moving()
    {
        if (!done)
        {
            player1.GetComponent<player_movement>().enabled = false;
            player2.GetComponent<player_movement>().enabled = false;
        }
        done = true;
    }
   

   

}
