using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.gameObject;
            
        }
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        enemy = null;
        player = null;
    }
}
