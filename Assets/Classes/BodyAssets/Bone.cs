using System;
using System.Collections.Generic;
using UnityEngine;

namespace Classes.BodyAssets
{
    public abstract class Bone : MonoBehaviour
    {
        public Dictionary<GameObject, Vertex> Vertices;
        public Vector2 Pos;
        public double Rotation;
        public IBodyPart ChildPart;
    }
}