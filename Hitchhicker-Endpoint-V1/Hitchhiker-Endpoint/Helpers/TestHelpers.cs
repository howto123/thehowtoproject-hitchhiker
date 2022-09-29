using Hitchhicker_Endpoint.Entities;

namespace Hitchhiker_Endpoint.Helpers
{
    public static class TestHelpers
    {
        public static bool HitchhikersAreAlmostEqual(IHitchhiker a, IHitchhiker b)
        {
            if (a.GetLocation().Equals(b.GetLocation()) &&
                a.GetDestination().Equals(b.GetDestination()) &&
                a.SouldBeDesposed().Equals(b.SouldBeDesposed()))
            {
                return true;
            }
            return false;
        }
    }
}