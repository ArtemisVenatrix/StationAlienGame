using System.Collections.Generic;
using UnityEngine;

namespace Classes.BodyAssets
{
    public interface IInlinePart : IMountablePart
    {
        List<Port> InlinePorts { get; set; }
        List<Port> RadialPorts { get; set; }

        void RemoveConnection(Port targetPort);
        void AttatchInlinePart(Port targetPort, Port requestingPort);
        void AttatchRadialPart(IRadialPart requestingPart);
        Port SolveForClosestInlinePort(Vector2 otherPortLocation);
    }
}