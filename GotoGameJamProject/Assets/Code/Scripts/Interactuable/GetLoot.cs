using UnityEngine;
using InventoryJam;

public class GetLoot : MonoBehaviour, Interactable
{
    [SerializeField] private Item loot;

    private Inventory inventory;
    private Animator animator;


    public void Interact(GameObject interactor)
    {
        if (interactor.CompareTag("Player"))
        {
            animator = interactor.GetComponent<Animator>();
            inventory = interactor.GetComponentInChildren<Inventory>();

            Debug.Log("Animator: " + animator.name);
            Debug.Log("Inventario: " + inventory.name);

            // cuando haya animación de pescar lanzar el trigger de la animacion
            //animator.SetTrigger("Interact");

            // cuando haya animacion quitar esto de aqui
            if (inventory.HasSpace())
                inventory.AddItem(loot);
        }
    }


    public void OnAnimationFinish()
    {
        // le damos el loot
        if (inventory.HasSpace())
            inventory.AddItem(loot);
    }
}
