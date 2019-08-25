using System;
using UnityEngine;

namespace Classes.BodyAssets
{
    public class Port
    {
        private Port sisterPort;
        public Bone ParentBone;
        public Vector2 Pos;
        public bool IsConnected;

        public Port(Bone parentBone, Vector2 pos)
        {
            ParentBone = parentBone;
            Pos = pos;
            IsConnected = false;
        }

        public IMountablePart GetOtherPart()
        {
            return sisterPort.ParentPart;
        }

        public void ConnectPorts(Port pendingPort)
        {
            sisterPort = pendingPort;
            sisterPort.ConnectPorts(this);
            IsConnected = true;
        }

        public void SeverConnection()
        {
            sisterPort.SeverConnection();
            sisterPort = null;
            IsConnected = false;
        }
    }
}