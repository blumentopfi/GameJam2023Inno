using System.Linq;
using Towers.Targeting;
using UnityEngine;

namespace Towers
{
    public class TowerTarget : MonoBehaviour
    {
        public TargetingComponent TargetingComponent;
        public GameObject Target { get; private set; }

        public void SearchNewTarget(int range)
        {
            var enemiesInRange = Physics.OverlapSphere(transform.position, range)
                .Select(collider => collider.gameObject)
                .Where(gameObject => gameObject.CompareTag("Enemies"))
                .ToList();
            Target = TargetingComponent.GetTarget(enemiesInRange, transform.position);
        }
    }
}
