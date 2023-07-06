using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour

{
    GameObject obj;

     void Awake()
    {
        obj=GameObject.FindGameObjectWithTag("Player2");
    }


    public int a;
    public Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

   
   void Start()
    {
        //player= GameObject.FindWithTag("Player1").transform;
       
       
    }
   
    void LateUpdate()
    {
        a = obj.GetComponent<switch_character>().count;
        if (a%2==0)
        {
            player = GameObject.FindWithTag("Player1").transform;
        }
        tempPos = transform.position;
        
            tempPos.x = player.position.x;
       
        

            if (tempPos.x < minX)
            {
                tempPos.x = minX;
            }
            if (tempPos.x > maxX)
            {
                tempPos.x = maxX;
            }
            transform.position = tempPos;
        
       
    }
}
