using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed = 25.0f;
    public float xRange = 10.0f;
    

    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moves spacecraft left and right
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Moves spacecraft forward and back
        if (transform.position.z > 15)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 15);
        }

        if (transform.position.z < -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

        horizontalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * horizontalInput * Time.deltaTime * speed);

        // Fires projecticle continously when space bar pressed
        

        if (Input.GetKey(KeyCode.Space))
        {

            // Launch a projecticle from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }

    }
}
