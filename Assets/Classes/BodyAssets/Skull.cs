using System.Collections.Generic;
using UnityEngine;

namespace Classes.BodyAssets
{
    public class Skull : Bone
    {
        void Awake()
        {
            Debug.Log("Initialising Vertex!");
            Vertices = new Dictionary<GameObject, Vertex>();
        }

        public void Init(GameObject v1)
        {
            Debug.Log(Vertices);
            Vertices[v1] = v1.GetComponent<Vertex>();
            Vertices[v1].Register(this);
            Vector3 spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;
            Vector3 modifiedPos = new Vector3(v1.transform.position.x + spriteSize.x/2, v1.transform.position.y, 0);
            gameObject.transform.position = modifiedPos;
        }
    }
}