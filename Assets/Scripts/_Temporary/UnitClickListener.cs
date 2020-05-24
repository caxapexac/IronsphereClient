using System;
using MonoBehaviours;
using UnityEngine;


namespace _Temporary
{
    public class UnitClickListener : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private Material _defaultMat;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _defaultMat = _meshRenderer.material;
        }

        private void OnMouseEnter()
        {
            _meshRenderer.material = God.I.TempGreenMat;
        }
        
        private void OnMouseDown()
        {
            
        }
        
        private void OnMouseUp()
        {
            
        }
        
        private void OnMouseExit()
        {
            _meshRenderer.material = _defaultMat;
        }

        
    }
}