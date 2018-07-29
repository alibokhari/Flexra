using FootballCodingChallange.Domain.AppLicences.Model.Enum;

namespace AppLicences.Domain.AppLicences.Model {
    public class Entry {
        public int ComputerId { get; set; }
        public int UserId { get; set; }
        public ComputerType ComputerType { get; set; }
    }
}
