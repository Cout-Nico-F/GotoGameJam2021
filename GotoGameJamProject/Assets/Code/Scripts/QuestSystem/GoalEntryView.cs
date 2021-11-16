using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalEntryView : MonoBehaviour
{
    [SerializeField] private Image completedIcon;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI amount;
    [SerializeField] private Sprite[] icons;

    public void Configure(bool completed, string description, int currentAmount, int requiredAmount)
    {
        var amount = $"({currentAmount}/{requiredAmount})";
        this.description.SetText(description);
        this.amount.SetText(amount);
        completedIcon.sprite = (completed) ? icons[1] : icons[0];
    }
    
}
