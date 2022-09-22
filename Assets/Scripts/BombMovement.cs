using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    
    public ParticleSystem playerBomb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BombDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BombDestroy()
    {
        yield return new WaitForSeconds(4);
        Instantiate(playerBomb,transform.position,playerBomb.transform.rotation);
        Destroy(GameObject.FindGameObjectWithTag("Bomb"));
        Destroy(GameObject.FindGameObjectWithTag("Bomb Radius").GetComponent<Radius>().enemy);
        Debug.Log("bye");
    }
}
