using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Files;

namespace GrankWinForm
{
    public partial class ReviewExcelControl : UserControl
    {
        public DataTable Data;

        public ReviewExcelControl()
        {
            InitializeComponent();
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            uploadFileDialog.ShowDialog();
        }

        private void UploadFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtFileName.Text = uploadFileDialog.FileName;
                if (string.IsNullOrEmpty(this.txtFileName.Text))
                {
                    return;
                }
                if (!this.txtFileName.Text.EndsWith(".xls") && !this.txtFileName.Text.EndsWith(".xlsx"))
                {
                    throw new Exception("只支持Excel");
                }

                Data = ExcelUtility.ExcelToDataTable(this.txtFileName.Text, true);
                if (Data == null)
                {
                    return;
                }

                dgView.DataSource = Data;
                dgView.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
