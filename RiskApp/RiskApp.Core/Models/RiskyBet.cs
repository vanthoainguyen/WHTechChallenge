using System.Collections.Generic;
using System.Linq;

namespace RiskApp.Core.Models
{
    public class RiskyBet : UnsettledBet
    {
        public RiskyBet(UnsettledBet bet)
        {
            CustomerId = bet.CustomerId;
            Event = bet.Event;
            Participant = bet.Participant;
            Stake = bet.Stake;
            ToWin = bet.ToWin;
            RiskTypes = new List<RiskType>();
        }

        public List<RiskType> RiskTypes { get; set; }

        public string GetRiskReport()
        {
            return string.Join(", ", RiskTypes.Where(x => x != RiskType.None).Distinct());
        }

        public bool IsRisky()
        {
            return RiskTypes != null && RiskTypes.Any(x => x != RiskType.None);
        }
    }
}