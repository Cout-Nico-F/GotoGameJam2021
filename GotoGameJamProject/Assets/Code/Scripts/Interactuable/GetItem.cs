using InventoryJam;
using UnityEngine;

public class GetItem : MonoBehaviour, Interactable
{
    [SerializeField] private Item item;

    private Inventory inventory;


    public void Interact(GameObject interactor)
    {
        if (interactor.CompareTag("Player"))
        {
            inventory = interactor.GetComponentInChildren<Inventory>();
            if (inventory == null)
            {
                Debug.LogError("El Player no tiene Inventario");
                return;
            }

            if (inventory.HasSpace())
            {
                inventory.AddItem(item);
                Destroy(gameObject);
            }
        }
    }

    
}
