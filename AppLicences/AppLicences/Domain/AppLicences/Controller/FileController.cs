using AppLicences.Domain.AppLicences.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppLicences.Domain.AppLicences.Controller {
    public class FileController {
        private FileService fileService;

        public FileController() {
            fileService = new FileService();
        }

        public async Task<Dictionary<int, int>> ProcessFile(string fileName) {
            return await fileService.GetApplicationCopies(fileName);
        }
    }
}
