using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_character : MonoBehaviour
{
    public Transform main_player;
    public List<Transform> players;
    public int switching;
    public int count = -1;
    // Start is called before the first frame update
    void Start()
    {
        if(main_player==null && players.Count>=1)
        {
            main_player = players[0];
        }
        Switch();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            count += 1;
            if (count % 2 == 0)
            {
                if (switching == 0)
                {
                    switching = players.Count - 1;
                }
                else
                {
                    switching = switching - 1;
                }
                Switch();
             
            }
            else
            {
                if (switching == players.Count - 1)
                {
                    switching = 0;
                }
                else
                {
                    switching = switching + 1;
                }
                Switch();
            }
        }
    }
    public void Switch()
    {
        main_player = players[switching];
        main_player.GetComponent<player_movement>().enabled = true;
        for(int i=0;i<players.Count;i++)
        {
            if(players[i]!=main_player)
            {
                players[i].GetComponent<player_movement>().enabled = false;
            }
        }
    }
}
