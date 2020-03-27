using System.Collections.Generic;
namespace Smallworld
{
    public interface IGameInterface
    {
        bool CanSelectTribe { get; }
        void SelectTribe(Tribe tribe);

        bool CanAbandon { get; }

        void Abandon(Region region);
        bool CanConquer { get; }

        void Conquer(Region region);
        void Regroup(Region region, int tokens);

        int TurnNumber { get; }

        int TokensInHand { get; }

        Tribe Active { get; }

        Tribe Declining { get; }

        IEnumerable<Tribe> AvailibleTribes { get; }
        IEnumerable<Region> AbandonableRegions { get; }
        IEnumerable<Region> ConquerableRegions { get; }

        bool CanRegroup { get; }

        IEnumerable<Region> RegroupableRegions { get; }

        int Coins { get; }
    }
}
