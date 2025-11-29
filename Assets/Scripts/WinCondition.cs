using UnityEngine;

public class WinCondition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PizzaBox"))
        {
            Debug.Log("Pizza Delievered!!!!! load to end screen or something"); //load to end screen or something.
        }
    }
}
