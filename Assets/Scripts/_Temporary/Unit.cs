using System;
using UnityEngine;


namespace MonoBehaviours
{
    public class Unit : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private Material _defaultMaterial;
        
        private void Start()
        {
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
            _defaultMaterial = _meshRenderer.material;
            God.I.Units.Add(this);
        }

        public void Select()
        {
            Debug.Log($"{name} selected!", this);
            _meshRenderer.material = God.I.TempGreenMat;
        }

        public void Deselect()
        {
            Debug.Log($"{name} deselected!", this);
            _meshRenderer.material = _defaultMaterial;
        }

        private void OnDestroy()
        {
            God.I.Units.Remove(this); //TODO pool
        }
    }
}