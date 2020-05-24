using System;
using System.Collections.Generic;
using HybridWebSocket;
using Network;
using TMPro;
using UnityEngine;


namespace MonoBehaviours
{
    public class God : MonoBehaviour
    {
        [Header("System")]

        [Header("Scene GameObjects")]
        public Camera Cam;

        [Header("Materials")]
        public Material TempRedMat;

        public Material TempGreenMat;

        [HideInInspector]
        public List<Unit> Units = new List<Unit>();

        [HideInInspector]
        public List<Unit> SelectedUnits = new List<Unit>();

        public static God I = null;

        private void Awake()
        {
            if (I)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            I = this;
        }

        private void Start()
        {

        }

        private void Update()
        {

        }
        
    }
}