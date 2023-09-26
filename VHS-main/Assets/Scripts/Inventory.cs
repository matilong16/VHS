using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inventory;
    public bool activeInventory;

    public GameObject Selector;
    public int ID;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Item"))
        {
            for (int i = 0; i < Bag.Count; i++)
            {
                if (Bag[i].GetComponent<Image>().enabled == false)
                {
                    Bag[i].GetComponent<Image>().enabled = true;
                    Bag[i].GetComponent<Image>().sprite = coll.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
        }

    }

    public void Nav()
    {
        if (Input.GetKeyDown(KeyCode.D) && ID < Bag.Count - 1)
        {
            ID++;
        }
        if (Input.GetKeyDown(KeyCode.A) && ID > 0)
        {
            ID--;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (ID > 2)
            {
                ID -= 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (ID < 6)
            {
                ID += 3;
            }
        }


        Selector.transform.position = Bag[ID].transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Nav();
        if (activeInventory)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            activeInventory = !activeInventory;
        }
    }
}
