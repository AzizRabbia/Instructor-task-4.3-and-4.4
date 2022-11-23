using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    private Transform pickUpPoint;
    private Transform player;
    public float pickUpDistance;
    public float force;
    public bool readyToThrow;
    public bool itemIsPicked;
    private Rigidbody rB;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        pickUpPoint = GameObject.Find("PickupPoint").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.P) && itemIsPicked==true && readyToThrow) //when p is pressed,pick the powerup and throw
        {
            force += 300 * Time.deltaTime;
        }

        pickUpDistance = Vector3.Distance(player.position, transform.position);
        if (pickUpDistance <= 2)
        {
        if(Input.GetKeyDown(KeyCode.P) && itemIsPicked==false && pickUpPoint.childCount < 1) 
            {
                // when picked up get the component
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = pickUpPoint.position; //when we pickup,item will go to the pickuppoint
                this.transform.parent = GameObject.Find("PickupPoint").transform;//find the parent and go to the pickup point
                itemIsPicked = true;
                force =0;
            }
        
        }
        if(Input.GetKeyUp(KeyCode.P) && itemIsPicked == true) 
        {
            readyToThrow = true;

            if (force > 5) 
            {
                rB.AddForce(player.transform.forward * force);
                this.transform.parent = null; //when throw it,it will jump again towards parent
                GetComponent<Rigidbody>().useGravity = true; //when grab it,need gravity to fall on ground
                GetComponent<BoxCollider>().enabled = true;
                itemIsPicked = false;
                force = 0;
                readyToThrow = false;
            }
            force =0;
        }



    }
}
