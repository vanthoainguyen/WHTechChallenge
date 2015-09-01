using System.Collections.Generic;
using System.IO;
using System.Linq;
using RiskApp.Core.Models;
using RiskApp.Core.Services;

namespace RiskApp.Core.Data
{
    public class CsvBetService : IBetService
    {
        private readonly string _basePath;

        public CsvBetService(string basePath)
        {
            _basePath = basePath;
        }

        public IEnumerable<SettledBet> GetSettledBet()
        {
            var lines = File.ReadAllLines(Path.Combine(_basePath, "Settled.csv")).Skip(1);
            return lines.Select(line => line.Split(',')).Select(terms => new SettledBet
            {
                CustomerId = int.Parse(terms[0]),
                Event = int.Parse(terms[1]),
                Participant = int.Parse(terms[2]),
                Stake = int.Parse(terms[3]),
                Win = int.Parse(terms[4])
            });
        }

        public IEnumerable<UnsettledBet> GetUnsettledBet()
        {
            var lines = File.ReadAllLines(Path.Combine(_basePath, "Unsettled.csv")).Skip(1);
            return lines.Select(line => line.Split(',')).Select(terms => new UnsettledBet
            {
                CustomerId = int.Parse(terms[0]),
                Event = int.Parse(terms[1]),
                Participant = int.Parse(terms[2]),
                Stake = int.Parse(terms[3]),
                ToWin = int.Parse(terms[4])
            });
        }
    }
}
