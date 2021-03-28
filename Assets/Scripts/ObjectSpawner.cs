using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject canItem;
    public GameObject boxItem;
    public GameObject packItem;
    public GameObject milkItem;
    public GameObject bottleItem;
    public GameObject shelfItem;

    public GameObject fruitItem1;
    public GameObject fruitItem2;
    public GameObject fruitItem3;
    public GameObject fruitItem4;
    public GameObject vegeItem1;
    public GameObject vegeItem2;
    public GameObject vegeItem3;
    public GameObject vegeItem4;
    public GameObject woodenBoxItem;

    public GameObject jar1;
    public GameObject jar2;
    public GameObject herbs1;
    public GameObject herbs2;
    public GameObject tea1;
    public GameObject tea2;
    public GameObject tea3;
    public GameObject tea4;
    public GameObject tableItem;

    //public Material defaultMaterial;
    //public Material pudliszkiMaterial;

    private float shelfHeight = 0.23F;
    private float firstShelfHeight = 0.2F;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6, true);
        Physics.IgnoreLayerCollision(7, 8, true);
        Physics.IgnoreLayerCollision(6, 8, true);

        SpawnShelves();

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
        Instantiate(shelfItem, new Vector3(1, 0, 0), Quaternion.identity);
        Instantiate(shelfItem, new Vector3(1.75F, 0, 0), Quaternion.identity);
        Instantiate(shelfItem, new Vector3(2.5F, 0, 0), Quaternion.identity);

        Instantiate(shelfItem, new Vector3(3.25F, 0, 0), Quaternion.identity);
        Instantiate(shelfItem, new Vector3(4, 0, 0), Quaternion.identity);
        Instantiate(shelfItem, new Vector3(4.75F, 0, 0), Quaternion.identity);
        Instantiate(shelfItem, new Vector3(5.5F, 0, 0), Quaternion.identity);

        var height = 0.8F;
        Instantiate(woodenBoxItem, new Vector3(0.25F, height, 2), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(1F, height, 2), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(1.75F, height, 2), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(2.5F, height, 2), Quaternion.identity);

        Instantiate(tableItem, new Vector3(0.25F, -0.1F, 2F), Quaternion.identity);
        Instantiate(tableItem, new Vector3(1.125F, -0.1F, 2F), Quaternion.identity);
        Instantiate(tableItem, new Vector3(2.5F, -0.1F, 2F), Quaternion.identity);

        Instantiate(woodenBoxItem, new Vector3(0.25F, height, 2.5F), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(1F, height, 2.5F), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(1.75F, height, 2.5F), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(2.5F, height, 2.5F), Quaternion.identity);

        Instantiate(tableItem, new Vector3(0.25F, -0.1F, 2.5F), Quaternion.identity);
        Instantiate(tableItem, new Vector3(1.125F, -0.1F, 2.5F), Quaternion.identity);
        Instantiate(tableItem, new Vector3(2.5F, -0.1F, 2.5F), Quaternion.identity);

        Instantiate(woodenBoxItem, new Vector3(3.25F, height, 2), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(4F, height, 2), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(4.75F, height, 2), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(5.5F, height, 2), Quaternion.identity);

        Instantiate(tableItem, new Vector3(3.25F, -0.1F, 2F), Quaternion.identity);
        Instantiate(tableItem, new Vector3(4.125F, -0.1F, 2F), Quaternion.identity);
        Instantiate(tableItem, new Vector3(5.5F, -0.1F, 2F), Quaternion.identity);

        Instantiate(woodenBoxItem, new Vector3(3.25F, height, 2.5F), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(4F, height, 2.5F), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(4.75F, height, 2.5F), Quaternion.identity);
        Instantiate(woodenBoxItem, new Vector3(5.5F, height, 2.5F), Quaternion.identity);

        Instantiate(tableItem, new Vector3(3.25F, -0.1F, 2.5F), Quaternion.identity);
        Instantiate(tableItem, new Vector3(4.125F, -0.1F, 2.5F), Quaternion.identity);
        Instantiate(tableItem, new Vector3(5.5F, -0.1F, 2.5F), Quaternion.identity);
    }

    private void SpawnGoodsOnShelves()
    {
        var items = GetFromFile(@"C:\Hack\data\database.txt");

        //var renderer = GetComponent<Renderer>();
        //renderer.enabled = true;

        foreach (var item in items)
        {
            for (var i = 0; i < item.quantity; i++)
            {
                if (item.type == "can" && i <= 5)
                {
                    Instantiate(canItem, new Vector3(i * 0.1F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(canItem, new Vector3(i * 0.1F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                }
                if (item.type == "box" && i <= 3)
                {
                    Instantiate(boxItem, new Vector3(i * 0.15F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(boxItem, new Vector3(i * 0.15F + ((item.aisle - 1 +4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                }

                if (item.type == "pack" && i <= 4)
                {
                    Instantiate(packItem, new Vector3(i * 0.13F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(packItem, new Vector3(i * 0.13F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                }

                if (item.type == "milk" && i <= 7)
                {
                    Instantiate(milkItem, new Vector3(i * 0.1F + ((item.aisle - 3.5F) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight - (shelfHeight * 2.5F), 0), Quaternion.identity);
                    Instantiate(milkItem, new Vector3(i * 0.1F + ((item.aisle - 3.5F) * 0.75F), (item.shelf - 1 + 4) * shelfHeight + firstShelfHeight - (shelfHeight * 2.5F), 0), Quaternion.identity);
                }

                if (item.type == "bottle" && i <= 4)
                {
                    Instantiate(bottleItem, new Vector3(i * 0.13F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(bottleItem, new Vector3(i * 0.13F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                }

                if (item.type == "fruit1" && i <= 30)
                {
                    Instantiate(fruitItem1, new Vector3(0.25F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F)), Quaternion.identity);
                    Instantiate(fruitItem1, new Vector3(3.25F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F)), Quaternion.identity);
                }

                if (item.type == "fruit2" && i <= 30)
                {
                    Instantiate(fruitItem2, new Vector3(1F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F)), Quaternion.identity);
                    Instantiate(fruitItem2, new Vector3(4F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F)), Quaternion.identity);
                }

                if (item.type == "fruit3" && i <= 30)
                {
                    Instantiate(fruitItem3, new Vector3(1.75F - (i * 0.0001F), 0.8F + (i * 0.1F), 2 + (i * 0.0001F)), Quaternion.identity);
                    Instantiate(fruitItem3, new Vector3(4.75F - (i * 0.0001F), 0.8F + (i * 0.1F), 2 + (i * 0.0001F)), Quaternion.identity);
                }

                if (item.type == "fruit4" && i <= 30)
                {
                    Instantiate(fruitItem4, new Vector3(2.5F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F)), Quaternion.identity);
                    Instantiate(fruitItem4, new Vector3(5.5F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F)), Quaternion.identity);
                }

                if (item.type == "vege1" && i <= 80)
                {
                    Instantiate(vegeItem1, new Vector3(0.25F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F) + 0.5F), Quaternion.identity);
                    Instantiate(vegeItem1, new Vector3(3.25F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F) + 0.5F), Quaternion.identity);
                }

                if (item.type == "vege2" && i <= 30)
                {
                    Instantiate(vegeItem2, new Vector3(1F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F) + 0.5F), Quaternion.identity);
                    Instantiate(vegeItem2, new Vector3(4F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F) + 0.5F), Quaternion.identity);
                }

                if (item.type == "vege3" && i <= 60)
                {
                    Instantiate(vegeItem3, new Vector3(1.75F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F) + 0.5F), Quaternion.identity);
                    Instantiate(vegeItem3, new Vector3(4.75F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F) + 0.5F), Quaternion.identity);
                }

                if (item.type == "vege4" && i <= 30)
                {
                    Instantiate(vegeItem4, new Vector3(2.5F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F) + 0.5F), Quaternion.identity);
                    Instantiate(vegeItem4, new Vector3(5.5F - (i * 0.00001F), 0.8F + (i * 0.1F), 2 + (i * 0.00001F) + 0.5F), Quaternion.identity);
                }

                if (item.type == "tea1" && i <= 5)
                {
                    Instantiate(tea1, new Vector3(i * 0.1F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(tea1, new Vector3(i * 0.1F + ((item.aisle - 1) * 0.75F), (item.shelf - 1 + 4) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);

                }
                if (item.type == "tea2" && i <= 3)
                {
                    Instantiate(tea2, new Vector3(i * 0.15F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(tea2, new Vector3(i * 0.15F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                }

                if (item.type == "tea3" && i <= 4)
                {
                    Instantiate(tea3, new Vector3(i * 0.13F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(tea3, new Vector3(i * 0.13F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                }

                if (item.type == "tea4" && i <= 7)
                {
                    Instantiate(tea4, new Vector3(i * 0.13F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(tea4, new Vector3(i * 0.13F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);

                }

                if (item.type == "herbs1" && i <= 5)
                {
                    Instantiate(herbs1, new Vector3(i * 0.1F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(herbs1, new Vector3(i * 0.1F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);

                }
                if (item.type == "herbs2" && i <= 3)
                {
                    Instantiate(herbs2, new Vector3(i * 0.15F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(herbs2, new Vector3(i * 0.15F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);

                }

                if (item.type == "jar1" && i <= 4)
                {
                    Instantiate(jar1, new Vector3(i * 0.13F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(jar1, new Vector3(i * 0.13F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);

                }

                if (item.type == "jar2" && i <= 7)
                {
                    Instantiate(jar2, new Vector3(i * 0.13F + ((item.aisle - 1) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);
                    Instantiate(jar2, new Vector3(i * 0.13F + ((item.aisle - 1 + 4) * 0.75F), (item.shelf - 1) * shelfHeight + firstShelfHeight, 0), Quaternion.identity);

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
