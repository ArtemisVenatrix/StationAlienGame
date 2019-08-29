using System.Collections.Generic;
using UnityEngine;

namespace Classes.BodyAssets
{
    public class Skull : Bone
    {
        void Start()
        {
            Vertices = new Dictionary<GameObject, Vertex>();
        }

        public void Init(GameObject v1)
        {
            Vertices[v1] = v1.GetComponent<Vertex>();
            gameObject.transform.position = v1.transform.position;
        }
    }
}