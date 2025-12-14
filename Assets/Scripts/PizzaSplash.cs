using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PizzaSplash : MonoBehaviour
{
    public GameObject pizzaSplash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip pizzaHit;

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
            //AudioSource.PlayClipAtPoint(pizzaHit, transform.position, 1f);
            var pizza = Instantiate(pizzaSplash, transform.position, Quaternion.identity);
            Destroy(pizza, 2f);
        }

    }
}
