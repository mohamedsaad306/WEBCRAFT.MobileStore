using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMMetaDataGenerator
{
    public partial class Form1 : Form
    {
        bool IsConnected = false;
        public CRMAccess CrmService;

        private void LoadEntities(IOrganizationService service)
        {
            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true//,
                //Parameters = { new KeyValuePair<string, object>("isimportable", true) }
                ,
            };

            // Retrieve the MetaData.
            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)service.Execute(request);

            //var primaryNameField = GetPrimaryNameAttribute("workflow");

            List<KeyValuePair<string, string>> listEntities = new List<KeyValuePair<string, string>>();


            foreach (EntityMetadata entity in response.EntityMetadata)
                if (entity.IsImportable.HasValue && entity.IsImportable.Value)
                    listEntities.Add(new KeyValuePair<string, string>(entity.LogicalName, entity.LogicalName));

            comboEntities.DataSource = listEntities.ToArray();
            comboEntities.DisplayMember = "Value"; // Not Showing correct Data
            comboEntities.ValueMember = "Key";

            comboEntities.Refresh();
            Application.DoEvents();
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<SavedData> connections = Helper.LoadSavedConnectionsData();
            comboBoxConnections.DisplayMember = "Url";
            comboBoxConnections.DataSource = connections;
            comboBoxConnections.SelectedIndex = -1;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(textBoxUserName.Text) && !string.IsNullOrWhiteSpace(textBoxPassWord.Text) && !string.IsNullOrWhiteSpace(textBoxOrgUrl.Text))
            {
                CRMAccess.UserName = textBoxUserName.Text;
                CRMAccess.Password = textBoxPassWord.Text;
                CRMAccess.OrgUrl = textBoxOrgUrl.Text;

                try
                {
                    CrmService = CRMAccess.Service;
                    IsConnected = true;
                    MessageBox.Show("Connected");
                    labelConnectedStatus.Text = "CONNECTED";
                    comboBoxConnections.Enabled = false;
                    textBoxOrgUrl.Enabled = false;
                    textBoxPassWord.Enabled = false;
                    textBoxUserName.Enabled = false;
                    checkBoxSaveOrg.Enabled = false;
                    checkBoxSaveOrg.Enabled = false;
                    button1.Enabled = false;
                }
                catch (Exception ex)
                {
                    textBoxOrgUrl.Text = string.Empty;
                    textBoxPassWord.Text = string.Empty;
                    textBoxUserName.Text = string.Empty;
                    checkBoxSaveOrg.Text= string.Empty;
                    MessageBox.Show(ex.Message);
                    //throw;
                }
                

                // save data 
                if (checkBoxSaveOrg.Checked)
                {
                    Helper.SaveConnection(new string[] { textBoxOrgUrl.Text, textBoxUserName.Text, textBoxPassWord.Text });
                    
                }

            }
            else
            {
                MessageBox.Show("please provide connection info ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                //progressBar1.
                LoadEntities(CrmService.OrgService);
            }
            else
            {
                MessageBox.Show("Connect To an Organization First.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = comboBoxConnections.SelectedItem as SavedData;
            if (data!=null)
            {
                textBoxOrgUrl.Text = data.Url;
                textBoxPassWord.Text = data.Password;
                textBoxUserName.Text = data.UserName;
                checkBoxSaveOrg.Checked = false; 
            }
        }

        private void checkBoxSaveOrg_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog()
            {
                Title = "Select Configuration File ",
                DefaultExt = ".xlsx",
                //Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx) | *.xlsx | Excel Files(*.xlsm) | *.xlsm", 
                Multiselect = false
            };
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                FileInfo fInfo = new System.IO.FileInfo(openFileDialog1.FileName);
                string strFileName = fInfo.Name;
                string strFilePath = fInfo.DirectoryName;
                var filePath = $"{strFilePath}\\{strFileName}";
                txt_filePath.Text = filePath;
              //  MessageBox.Show("");
            }
            
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            try
            {
                Import import = new Import(null/*CrmService.OrgService*/);
                import.ImportFile(txt_filePath.Text, "" /*comboEntities.SelectedValue.ToString()*/);
                MessageBox.Show($"{txt_filePath.Text} {comboEntities.SelectedValue}");
            }
            catch (Exception rx )
            {

                MessageBox.Show(rx.Message);
            }
        }
    }
}
