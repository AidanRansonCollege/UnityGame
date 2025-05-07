using UnityEngine;

public class Seat : MonoBehaviour
{
    public bool isTaken;
    public GameObject sitter;
    public bool inPlace = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isTaken = false;     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.GetComponent<Customer>() != null) {

            collider.gameObject.GetComponent<Customer>().isSitting = true;
            if (inPlace) { 
                collider.gameObject.transform.position = gameObject.transform.position;
                inPlace = false;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Customer>() != null)
        {

            collider.gameObject.GetComponent<Customer>().isSitting = false;

        }
    }
}
