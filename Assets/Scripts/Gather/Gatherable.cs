
using UnityEngine;

namespace DefaultNamespace
{
    [UnityEngine.CreateAssetMenu(fileName = "New Gatherable", menuName = "Gather/Gatherable", order = 0)]
    public class Gatherable : ScriptableObject
    {
        public string Name;
        public string Description;
    }
}