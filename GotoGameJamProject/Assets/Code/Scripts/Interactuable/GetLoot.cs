using UnityEngine;
using InventoryJam;

public class GetLoot : MonoBehaviour, Interactable
{
    [SerializeField] private Item loot;

    private Inventory inventory;
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }


    public void Interact(GameObject interactor)
    {
        if (interactor.CompareTag("Player"))
        {
            // obtenemos el inventario del Player
            inventory = FindObjectOfType<Inventory>(true);

            // lanzar el trigger de la animacion
            animator.SetTrigger("Interact");
        }
    }


    public void OnAnimationFinish()
    {
        // le damos el loot
        inventory.AddItem(loot);
    }
}
