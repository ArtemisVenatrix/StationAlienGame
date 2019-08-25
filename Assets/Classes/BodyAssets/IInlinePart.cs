using System.Collections.Generic;

namespace Classes.BodyAssets
{
    public interface IInlinePart
    {
        Dictionary<string, Port> InlinePorts { get; set; }
        List<Port> RadialPorts { get; set; }
    }
}