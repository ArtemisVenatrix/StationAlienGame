using System;

namespace Classes.BodyAssets
{
    public class UnexpectedRequestingPartException : Exception
    {
        public UnexpectedRequestingPartException(IBodyPart requestingPart_, Object recievingObject) : base("A part called a function on " + recievingObject + " when it wasn't supposed to! Requesting Part: " + requestingPart_)
        {
            
        }
    }
}