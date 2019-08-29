using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Classes.BodyAssets
{
    public class Vertex : MonoBehaviour
    {
        public List<Bone> ParentBones;

        public List<Bone> GetOtherBones(Bone requester)
        {
            IEnumerable<Bone> requestedBones = from bone in ParentBones where !bone.Equals(requester) select bone;
            return requestedBones as List<Bone>;
        }
    }
}