using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PizzaSplash : MonoBehaviour
{
    public GameObject pizzaSplash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Debug.Log("Hit");
            var pizza = Instantiate(pizzaSplash, transform.position, Quaternion.identity);
            Destroy(pizza, 2f);
        }

    }
}
