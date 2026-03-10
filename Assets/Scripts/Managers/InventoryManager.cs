using UnityEngine;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance {  get; private set; }
    private List<string> inventory = new List<string>();

    private void Awake()
    {
        Instance = this;
    }
    public void AddItem(string itemName)
    {
        inventory.Add(itemName);
        Debug.Log("Collected: " + itemName);
    }

    public bool HasItem(string itemName)
    {
        return inventory.Contains(itemName);
    }
}
