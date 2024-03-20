using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class RamdomArea : MonoBehaviour
    {
        [SerializeField] private float radius = 1f;

        public float Radius => radius;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
