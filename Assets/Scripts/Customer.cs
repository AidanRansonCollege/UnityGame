
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour, IInteract
{
    public string characterName;
    public string[] order;
    public int gold;
    public GameObject[] seats;
    public GameObject desiredSeat;
    public GameObject exit;

    public bool isSitting;
    public float maxSitTime;
    public float timesat = 0;
    public bool canBeDestroyed;


    public void Interact()
    {

        if (isSitting)
        {
            GiveOrder();
        }
        else{
            Chat();
        }

        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gold = Random.Range(gold - 5, gold + 5);

        seats = GameObject.FindGameObjectsWithTag("Seat");
        System.Array.Sort(seats, (a, b) => a.name.CompareTo(b.name));
        exit = GameObject.FindGameObjectWithTag("Exit");

        SelectSeat();
    }

    void Update()
    {
        if(desiredSeat.GetComponent<Seat>().sitter != gameObject)
        {
            //Someone took the seat, ReSelect
            SelectSeat();
        }

        if (timesat >= maxSitTime) {
            LeaveSeat();
        }

        if(canBeDestroyed && gameObject.GetComponent<NavMeshAgent>().remainingDistance == 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isSitting && gameObject.GetComponent<NavMeshAgent>().remainingDistance == 0)
        {
            timesat += 1;
        }
    }

    void SelectSeat()
    {

        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i].GetComponent<Seat>().isTaken == false)
            {
                desiredSeat = seats[i];
                desiredSeat.GetComponent<Seat>().isTaken = true;
                desiredSeat.GetComponent<Seat>().sitter = gameObject;
                break;
            }
        }

        gameObject.GetComponent<NavMeshAgent>().SetDestination(desiredSeat.transform.position);
    }

    void LeaveSeat()
    {
        desiredSeat.GetComponent<Seat>().isTaken = false;
        desiredSeat.GetComponent<Seat>().sitter = null;

        gameObject.GetComponent<NavMeshAgent>().SetDestination(exit.transform.position);
    }

    void GiveOrder()
    {
        for (int i = 0; i < order.Length; i++)
        {
            Debug.Log(order[i]);
        
        }
    }

    void Chat()
    {
        Debug.Log("Hello my name is " + name + ". I have " + gold + " gold.");
    }

    
}
