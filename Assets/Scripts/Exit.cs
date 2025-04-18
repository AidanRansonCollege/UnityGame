using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<Customer>() != null)
        {
            collider.gameObject.GetComponent<Customer>().canBeDestroyed = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Customer>() != null)
        {
            collider.gameObject.GetComponent<Customer>().canBeDestroyed = false;
        }
    }
}
