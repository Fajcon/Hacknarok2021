using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ProductsController : MonoBehaviour
{
    public GameObject rightHand;
    
    void OnCollisionEnter (Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag.Equals("hand"))
        {
            Debug.Log("dupa");
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
