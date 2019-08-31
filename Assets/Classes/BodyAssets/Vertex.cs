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

        public bool Register(Bone requester)
        {
            if (requester is Vertebrae)
            {
                IEnumerable<Vertebrae> vertebraes =
                    from bone in ParentBones where bone is Vertebrae select bone as Vertebrae;
                if (vertebraes.Count() < 2)
                {
                    ParentBones.Add(requester);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            ParentBones.Add(requester);
            return true;
        }
    }
}