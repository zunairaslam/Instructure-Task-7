using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombExplode : MonoBehaviour
{
    public ParticleSystem enemyBomb;
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
        Instantiate(enemyBomb, transform.position, enemyBomb.transform.rotation);
        Destroy(GameObject.FindGameObjectWithTag("Bomb"));
        Destroy(GameObject.FindGameObjectWithTag("Bomb Radius").GetComponent<Radius>().player);
        Debug.Log("bye");
    }
}
