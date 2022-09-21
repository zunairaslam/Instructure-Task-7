using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 200f;
    public float horizontalInput;
    public float verticalInput;
    public GameObject bombPrefab;
    public bool hasPowerup;

    public Camera mainCamera;
    private Animator playerAmin;
    // Start is called before the first frame update
    void Start()
    {
        playerAmin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputKeys();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
           
        }
    }

    private void FixedUpdate()
    {
        movement();
    }

    private void inputKeys()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
       
    }
    private void movement()
    {
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * horizontalInput * Time.deltaTime);
        playerAmin.SetFloat("speed",verticalInput);
        
    }
    private void Fire()
    {
        GameObject bomb = Instantiate(bombPrefab, transform.position + new Vector3(0, 4f, 0), bombPrefab.transform.rotation);
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
        bombRb.AddForce((transform.up + transform.forward) * 4, ForceMode.Impulse);
        StartCoroutine(BombDestroy());
    }
    IEnumerator BombDestroy()
    {
        yield return new WaitForSeconds(4);
        Destroy(GameObject.FindGameObjectWithTag("Bomb"));
        Destroy(GameObject.FindGameObjectWithTag("Bomb Radius").GetComponent<Radius>().enemy);
        Debug.Log("bye");
    }
}
