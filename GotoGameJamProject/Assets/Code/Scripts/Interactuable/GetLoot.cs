using UnityEngine;
using InventoryJam;

public class GetLoot : MonoBehaviour, Interactable
{
    [SerializeField] private Item loot;
    [SerializeField] private bool hasAnimation;
    [SerializeField] private string animationTrigger;

    private Inventory inventory;
    private Animator animator;


    public void Interact(GameObject interactor)
    {
        if (interactor.CompareTag("Player"))
        {
            if (hasAnimation)
            {
                animator = interactor.GetComponent<Animator>();
                if (animator == null)
                {
                    Debug.LogError("El Player no tiene Animator");
                    return;
                }
            }

            inventory = interactor.GetComponentInChildren<Inventory>();
            if (inventory == null)
            {
                Debug.LogError("El Player no tiene Inventario");
                return;
            }

            // cuando haya animación activamos el trigger de la animacion sino
            // le damos el loot directamente
            if (hasAnimation)
            {
                animator.SetTrigger(animationTrigger);
            }
            else
            {
                if (inventory.HasSpace())
                    inventory.AddItem(loot);
            }
        }
    }


    public void OnAnimationFinish()
    {
        // al finalizar la animacion le damos el loot
        if (inventory.HasSpace())
            inventory.AddItem(loot);
    }
}
