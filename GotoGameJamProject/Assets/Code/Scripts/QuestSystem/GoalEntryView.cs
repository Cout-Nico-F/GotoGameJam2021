using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalEntryView : MonoBehaviour
{
    [SerializeField] private Image completedIcon;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI amount;

    public void Configure(string description, int currentAmount, int requiredAmount)
    {
        var amount = $"({currentAmount}/{requiredAmount})";
        this.description.SetText(description);
        this.amount.SetText(amount);
    }
}
