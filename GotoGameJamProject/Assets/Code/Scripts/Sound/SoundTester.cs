using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioJam
{

    public class SoundTester : MonoBehaviour
    {
        public void Awake()
        {
            SoundManager.instance.Play("TestFiesta");
        }
    }

}
