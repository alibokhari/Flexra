using AppLicences.Domain.AppLicences.Repository;
using System.Linq;
using Xunit;

namespace AppLicences.Test.Repository {
    public class FileRepositoryUnitTest
    {
        [Fact]
        public async void Users_Licences_List_of_Application_DoesNot_Contain_Other_Than_374() {
            string appId = "374";
            string fileName = @"..\..\..\TestData\sample-small.csv";
            var repository = new FileRepository();

            var licencesData = await repository.GetFileData(fileName);

            var non374Apps = licencesData.Where(s => !s.Contains(appId)).ToList();

            Assert.Equal(0, non374Apps.Count);
        }

        [Fact]
        public async void Users_Licences_List_of_Application_Only_Contains_No_374() {
            string appId = "374";
            string fileName = @"..\..\..\TestData\sample-small.csv";
            var repository = new FileRepository();

            var licencesData = await repository.GetFileData(fileName);

            var non374Apps = licencesData.Where(s => s.Contains(appId)).ToList();

            Assert.Equal(licencesData.Count, non374Apps.Count);
        }
    }
}
