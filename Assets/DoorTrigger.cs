using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float doorSpeed = 0.7f;
    public float doorMax = 5.0f;
    public float doorMin = 0.0f;
    public float startTime;
    public GameObject doorObject;
    public bool active;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        moveUp();
        moveDown();

        if (doorObject.transform.position.y > doorMax)
        {
            doorObject.transform.position = new Vector3(0, doorMax, 0);
        }

        if (doorObject.transform.position.y < doorMin)
        {
            doorObject.transform.position = new Vector3(0, doorMin, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;      
    }

    public void moveUp()
    {
        //doorObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, doorMax, 0), ForceMode.Impulse);
        //doorObject.transform.Translate(Vector3.Lerp(new Vector3(0, doorMin, 0), new Vector3(0, doorMin, 0), 0));
        if (active == true)
        {
            doorObject.transform.Translate(new Vector3(0, doorMax, 0) * Time.deltaTime * doorSpeed);
        }
    }

    public void moveDown()
    {
        //doorObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -doorMax, 0), ForceMode.Impulse);
        //doorObject.transform.Translate(Vector3.Lerp(new Vector3(0, doorMax, 0), new Vector3(0, doorMin, 0), 0));
        if (active == false)
        {
            doorObject.transform.Translate(new Vector3(0, -doorMax, 0) * Time.deltaTime * doorSpeed);
        }
    }
}
