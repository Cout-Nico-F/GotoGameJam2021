using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ChatSystem : MonoBehaviour
{
    [Header("Enter parameters")]
    [SerializeField] private TextFramePlayer textFramePayer;
    public void ReadInptPlayer(string s)
    {
        textFramePayer.gameObject.SetActive(true);
        textFramePayer.StartCoroutine(textFramePayer.PlayerTalk(s));
    }
}
