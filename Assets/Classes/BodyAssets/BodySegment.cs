using System;
using System.Collections.Generic;
using UnityEngine;

namespace Classes.BodyAssets
{
    public abstract class BodySegment : IInlinePart, IBodyPart, IOrganContainer, IExternalPart
    {
        public List<Port> InlinePorts { get; set; }
        public List<Port> RadialPorts { get; set; } 
        public float MaxHp { get; set; }
        public float CurrentHp { get; set; }
        public float Volume { get; set; }
        public List<Organ> Organs { get; set; }
        public float Armor { get; set; }
        public Vector2 Location { get; set; }
        public Vector2Int BoundingDimensions { get; set; }
        public Vector2 FloatDimensions { get; set; }
    
        public void RemoveConnection(Port targetPort)
        {
            if (InlinePorts.Contains(targetPort))
            {
                targetPort.SeverConnection();
            }
            else if (RadialPorts.Contains(targetPort))
            {
                targetPort.SeverConnection();
                RadialPorts.Remove(targetPort);
            }
        }

        public void AttatchInlinePart(Port targetPort, Port requestingPort)
        {
            requestingPort.ConnectPorts(targetPort);
        }

        public void AttatchRadialPart(IRadialPart requestingPart)
        {
            Port myPort = new Port(this, requestingPart.MyPort.Pos);
            RadialPorts.Add(myPort);
            myPort.ConnectPorts(requestingPart.MyPort);
        }

        public Port SolveForClosestInlinePort(Vector2 otherPortLocation)
        {
            throw new NotImplementedException();
        }
        
        public int[] GetStatEffects() //only call from root part!
        {
            int[] tempStats = new int[9];
            foreach (Port port in InlinePorts)
            {
                IBodyPart otherPart = port.GetOtherPart() as IBodyPart;
                int[] requestedStats = otherPart.GetStatEffects();
                for (int i = 0; i < requestedStats.Length; i++)
                {
                    tempStats[i] += requestedStats[i];
                }
            }

            foreach (Port port in RadialPorts)
            {
                IBodyPart otherPart = port.GetOtherPart() as IBodyPart;
                int[] requestedStats = otherPart.GetStatEffects();
                for (int i = 0; i < requestedStats.Length; i++)
                {
                    tempStats[i] += requestedStats[i];
                }
            }

            return tempStats;
        }
    }
}