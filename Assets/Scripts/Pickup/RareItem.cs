using UnityEditor;
using UnityEngine;

public class RareItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private GameObject collectEffect;
    [SerializeField] private AudioClip collectSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ⭐ Spawn particle
            Instantiate(collectEffect, transform.position, Quaternion.identity);

            // ⭐ Play sound
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            InventoryManager.Instance.AddItem(itemName);
            GameManager.Instance.RareItemCollected();
            //Destroy(gameObject);
            Destroy(gameObject, 0.1f);
        }

    }
}
