using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject canItem;
    public GameObject boxItem;

    // Start is called before the first frame update
    void Start()
    {
        var items = GetFromFile(@"C:\Hack\data\database.txt");

        foreach (var item in items) {
            for (var i = 0; i < item.quantity; i++)
            {
                if (item.type == "can")
                    Instantiate(canItem, new Vector3(i * 0.1F, 0, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void SpawnObject()
    //{
    //    GameObject gameObject = Instantiate() as GameObject;
    //}

    private List<GroceryItem> GetFromFile(string path)
    {
        var items = new List<GroceryItem>();
        string[] lines = System.IO.File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var data = new GroceryItem(line);
            items.Add(data);
        }
        return items;
    }
}


[Serializable]
class GroceryItem
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public int quantity { get; set; }
    public int aisle { get; set; }
    public int rack { get; set; }
    public int shelf { get; set; }
    public double price { get; set; }
    public String image { get; set; }

    public GroceryItem (string csvData)
    {
        var values = csvData.Split(';');
        id = Convert.ToInt32(values[0]);
        name = values[1];
        type = values[2];
        quantity = Convert.ToInt32(values[3]);
        aisle = Convert.ToInt32(values[4]);
        rack = Convert.ToInt32(values[5]);
        shelf = Convert.ToInt32(values[6]);
        price = Convert.ToDouble(values[7]);
        if (values.Length >= 9)
        {
            image = values[8];
        }
    }
}
