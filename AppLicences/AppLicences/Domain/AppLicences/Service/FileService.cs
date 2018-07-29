using AppLicences.Domain.AppLicences.Model;
using AppLicences.Domain.AppLicences.Repository;
using FootballCodingChallange.Domain.AppLicences.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLicences.Domain.AppLicences.Service {
    public class FileService {
        private FileRepository fileRepository;

        public FileService() {
            fileRepository = new FileRepository();
        }

        public async Task<Dictionary<int, int>> GetApplicationCopies(string fileName) {
            var data = await fileRepository.GetFileData(fileName);
            var entries = await GetEntries(data);
            data.Clear();

            var users = entries.Select(e => e.UserId).Distinct();
            Dictionary<int, int> usersCopies = new Dictionary<int, int>();
            foreach (var userId in users) {
                var copies = entries.Where(e => e.UserId == userId).ToList();
                var desktops = copies.Where(e => e.ComputerType == ComputerType.Desktop).ToList().Count;
                var laptops = copies.Where(e => e.ComputerType == ComputerType.Laptop).ToList().Count;
                var diff = laptops - desktops;
                var licences = desktops + (diff > 0 ? diff : 0);
                usersCopies.Add(userId, licences);
            }
            return usersCopies;
        }

        private async Task<List<Entry>> GetEntries(List<string> data) {
            var entries = new List<Entry>();
            data.RemoveAt(0);

            foreach (var line in data) {
                var EntryData = line.Split(',');
                if (EntryData.Length == 5) {
                    entries.Add(new Entry {
                        ComputerId = Convert.ToInt32(EntryData[0]),
                        UserId = Convert.ToInt32(EntryData[1]),
                        ComputerType = (ComputerType)Enum.Parse(typeof(ComputerType), EntryData[3], true),
                    });
                }
            }

            return entries;
        }
    }
}
