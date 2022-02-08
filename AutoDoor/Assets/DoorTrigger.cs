using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float doorSpeed = 0.7f;
    public float doorMax = 5.0f;
    public float doorMin = 0.0f;
    public GameObject doorObject;
    public bool active;
    
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
        if (other.gameObject.CompareTag("Player"))
        {
            active = true;
            moveUp();
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            active = false;
            moveDown();
        }
            
    }

    public void moveUp()
    {
        if(active == true)
        {
            doorObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, doorMax, 0), ForceMode.Force);
            
            if (doorObject.transform.position.y > doorMax)
            {
                doorObject.transform.position = new Vector3(0, doorMax, 0);
            }
        }
    }

    public void moveDown()
    {
        if(active == false)
        { 
            doorObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, doorMin, 0), ForceMode.Force);
            
            if (doorObject.transform.position.y < doorMin)
            {
                doorObject.transform.position = new Vector3(0, doorMin, 0);
            }
        }
       
    }
}
