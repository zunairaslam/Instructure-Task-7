using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    private GameObject player;
    public float speed = 3f;
    private Animator playerAmin;

    public GameObject bombPrefab;
    public float startTime = 2f;
    public float delayTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAmin = GetComponent<Animator>();
        InvokeRepeating("EnemyBombFire", startTime, delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void EnemyBombFire()
    {
        GameObject bomb = Instantiate(bombPrefab, transform.position + new Vector3(0, 4f, 0), bombPrefab.transform.rotation);
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
        bombRb.AddForce((transform.up + transform.forward) * 4, ForceMode.Impulse);
    }
}
