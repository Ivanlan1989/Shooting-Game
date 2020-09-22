using UnityEngine;

/*
 * Videos: Brackey's Unity Beginner tutorials 1-10
 * Author: Brackeys (Youtube)
 * Date: January 23 2017
 * Type: Tutorial on using Unity
 * Availability: https://www.youtube.com/playlist?list=PLPV2KyIb3jR5QFsefuO2RlAgWEz6EvVi6
 * 
 * Code adapted from these tutorials to learn Unity
 * */


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float fowardForce = 2000f;
    public float sidewaysForce = 500f;

    void FixedUpdate()
    {
        // add foward force
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();  
        }

    }
}
