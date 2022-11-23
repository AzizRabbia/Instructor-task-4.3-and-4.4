using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public bool hasPowerup;
  
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) //moving player forward
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime);
            playerAnim.SetBool("Is_walk", true);
        }
        // moving player in all directions using keys
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up, -10);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up, 10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Powerup")) 
        {
            hasPowerup = true;
            //Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());


        }
    }
    IEnumerator PowerupCountdownRoutine()   //creating countdown routine for powerup
    {
        yield return  new WaitForSeconds(5);
        hasPowerup = false;
    }

}


