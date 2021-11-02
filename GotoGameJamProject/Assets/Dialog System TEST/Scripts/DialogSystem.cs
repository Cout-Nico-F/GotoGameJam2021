using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace AudioJam
{
    public class DialogSystem : MonoBehaviour
    {
        [Header("Personalize Text")]
        [SerializeField] private string Input;
        [SerializeField] private Color TextColor;
        [SerializeField] private Font TextFont;
        [SerializeField] private float Delay;
        [SerializeField] private int TextSize;
        [SerializeField] private string NameFXsound;
        private Text TextHolder;

        public void Start()
        {
            TextHolder = GetComponent<Text>();
            StartCoroutine(WriteText(Input, TextHolder, TextColor, TextFont, Delay, TextSize,NameFXsound));
        }
        public IEnumerator WriteText(string input, Text TextHolder, Color TextColor, Font TextFont, float Delay, int TextSize,string NameFXsound)
        {
            TextHolder.font = TextFont;
            TextHolder.color = TextColor;
            TextHolder.fontSize = TextSize;
            for (int i = 0; i < input.Length; i++)
            {
                TextHolder.text += input[i];
                SoundManager.instance.Play(NameFXsound);
                yield return new WaitForSeconds(Delay);
            }
        }
    }
}