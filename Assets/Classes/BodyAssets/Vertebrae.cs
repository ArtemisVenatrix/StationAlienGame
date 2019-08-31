using System;
using System.Collections.Generic;
using UnityEngine;

namespace Classes.BodyAssets
{
    public class Vertebrae : Bone
    {
        public bool IsBack;
        
        void Start()
        {
            Vertices = new Dictionary<GameObject, Vertex>();
        }

        void Update()
        {
            
        }

        public void Init(GameObject v1, GameObject v2)
        {
            Vertices[v1] = v1.GetComponent<Vertex>();
            Vertices[v2] = v2.GetComponent<Vertex>();
            Vertices[v1].Register(this);
            Vertices[v2].Register(this);
            gameObject.transform.position = (v1.transform.position + v2.transform.position) / 2.0f;
            float y = v1.transform.position.y - v2.transform.position.y;
            float x = v1.transform.position.x - v2.transform.position.x;
            float theta = (float)Math.Atan(y / x);
            gameObject.transform.Rotate(Vector3.forward * theta);
            float currentSize = gameObject.GetComponent<Sprite>().bounds.size.y;
            float newSize = Vector3.Distance(v1.transform.position, v2.transform.position);
            Vector3 rescale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y * newSize / currentSize, 0);
            gameObject.transform.localScale = rescale;
        }
    }
}