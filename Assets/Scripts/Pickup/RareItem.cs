using UnityEditor;
using UnityEngine;

public class RareItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(itemName);
            GameManager.Instance.RareItemCollected();
            Destroy(gameObject);
        }

    }
}
