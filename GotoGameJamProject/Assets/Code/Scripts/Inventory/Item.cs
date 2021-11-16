using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private Sprite sprite;

    public Sprite Sprite { get => sprite; }
    public string Id { get => id; }

}
