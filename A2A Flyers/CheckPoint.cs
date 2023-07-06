using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Fly>().SpeedUp();
            Destroy(gameObject);
        }
    }
}
