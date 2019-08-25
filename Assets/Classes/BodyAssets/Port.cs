using System;

namespace Classes.BodyAssets
{
    public class Port
    {
        private IMountablePart part1;
        private IMountablePart part2;

        public IMountablePart GetOtherPart(IMountablePart requestingPart)
        {
            if (requestingPart.Equals(part1))
            {
                return part2;
            }

            if (requestingPart.Equals(part2))
            {
                return part1;
            }
            
            throw new Exception("Unexpected requesting part! Part: " + requestingPart);
        }
    }
}