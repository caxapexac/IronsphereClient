using JsonSchemas.Entities;
using UnityEngine;


namespace MonoBehaviours.Elements
{
    public class UnitBehaviour : MonoBehaviour
    {
        public unit unit;

        public void DrawUnit(unit unit)
        {
            this.unit = unit;
        }
    }
}