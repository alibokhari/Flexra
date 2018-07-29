using AppLicences.Domain.AppLicences.Controller;
using AppLicences.Domain.AppLicences.Exceptions;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLicences {
    public partial class frmMain : Form {
        private StringBuilder sb;
        private BindingSource source;

        public frmMain() {
            InitializeComponent();
            sb = new StringBuilder();
            source = new BindingSource();
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "*.csv|*.csv";
            fileDialog.ShowDialog();
            this.txtFileName.Text = fileDialog.FileName;
            sb.AppendLine("File selected.............");

            this.txtLog.Text = sb.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e) {
            grdCompaniesLicences.DataSource = null;
            sb.Clear();
            this.txtLog.Text = string.Empty;
        }

        private async void btnProcess_Click(object sender, EventArgs e) {
            try {
                Cursor = Cursors.WaitCursor;
                var fileController = new FileController();
                sb.AppendLine("File processing.............");
                this.txtLog.Text = sb.ToString();
                source.DataSource = await fileController.ProcessFile(txtFileName.Text);
                grdCompaniesLicences.DataSource = source;
                grdCompaniesLicences.Columns[0].HeaderText = "User";
                grdCompaniesLicences.Columns[1].HeaderText = "Licences";
                sb.AppendLine($"Data processed.............");
                Cursor = Cursors.Default;
            }
            catch (FileDataException fdEx) {
                sb.AppendLine(fdEx.Message);
            }
            this.txtLog.Text = sb.ToString();
        }

        private void ValidateFileFormat() {

        }
    }
}
