using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppLicences.Domain.AppLicences.Repository {
    public class FileRepository {
        public async Task<List<string>> GetFileData(string fileName) {
            var data = new List<string>();
            string dataLine;
            await Task.Run(() => {
                using (StreamReader reader = new StreamReader(fileName)) {
                    while ((dataLine = reader.ReadLine()) != null) {
                        if (dataLine.Split(',')[2].Equals("374")) {
                            data.Add(dataLine);
                        }
                    }
                }
            });
            return data;
        }
    }
}
