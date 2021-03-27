using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject canItem;
    public GameObject boxItem;
    public GameObject shelfItem;

    //public Material defaultMaterial;
    //public Material pudliszkiMaterial;

    private float shelfHeight = 0.23F;
    private float firstShelfHeight = 0.2F;

    // Start is called before the first frame update
    void Start()
    {
        var items = GetFromFile(@"D:\Documents\Hacknarok2021\data\database.txt");

        SpawnGoodsOnShelves();

        var renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnShelves()
    {
        Instantiate(shelfItem, new Vector3(0.25F, 0, 0), Quaternion.identity);
    }

    private void SpawnGoodsOnShelves()
    {
        var items = GetFromFile(@"D:\Documents\Hacknarok2021\data\database.txt");

        //var renderer = GetComponent<Renderer>();
        //renderer.enabled = true;

        foreach (var item in items)
        {
            for (var i = 0; i < item.quantity; i++)
            {
                if (i > 7)
                {
                    continue;
                }

                if (item.type == "can")
                {
                    //renderer.sharedMaterial = pudliszkiMaterial;
                    Instantiate(canItem, new Vector3(i * 0.1F, (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    
                }
            }
        }
    }

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
