using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

    public class TextFramePlayer : MonoBehaviour
    {
        [Header("Enter parameters")]
        [SerializeField] private TextMeshProUGUI textMesh;
        [Header("Text settings")]
        [SerializeField] private Color textColor;

        private void Start()
        {
            textMesh.color = textColor;
        }
        public IEnumerator PlayerTalk(string textInput)
        {
            textMesh.text="";
            textMesh.text=textInput;

            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }
    }
