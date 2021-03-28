using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    private ProductsController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        controller = collision.gameObject.GetComponent<ProductsController>();
        var value = controller.name +" "+controller.price;
        if (HandPresence.products.Count == 0 || !HandPresence.products.Last().Equals(value))
        {
            HandPresence.products.Add(value);
        }
        collision.gameObject.SetActive(false);
    }
}
