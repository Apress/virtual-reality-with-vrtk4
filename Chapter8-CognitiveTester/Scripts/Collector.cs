using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scene3
{
    public class Collector : MonoBehaviour
    {        
        public string objectName;
        public string collected_ObjectName;
        public GameObject collectedObject;

        private void OnTriggerEnter(Collider other)
        {            
            Debug.Log(other.gameObject.GetComponentInChildren<MeshFilter>().name);

            this.collected_ObjectName = other.gameObject.GetComponentInChildren<MeshFilter>().name;
            this.collectedObject = other.gameObject;
            if (this.objectName == this.collected_ObjectName)
            {
                BroadcastMessage("SetCorrect", true);
            }
            else
            {
                BroadcastMessage("SetCorrect", false);
            }
        }

        
    }
}