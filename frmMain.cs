using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();
            string JavaCode = JavaAnalyzer.DeleteTheComments(txtJavaCode.Text);
            JavaCode = JavaAnalyzer.DeleteTheStrings(JavaCode);
            List<string> Variables = JavaAnalyzer.GetVariables(JavaCode);
            List<JavaAnalyzer.VariableInfo> VariablesInfo = JavaAnalyzer.GetVariablesInfo(Variables, JavaCode);
            int DataCount = 0, StewardCount = 0, ModifiedCount = 0, ParasiticCount = 0;
            for (int i = 0; i < VariablesInfo.Count; i++)
            {
                if (VariablesInfo[i].IsData)
                    DataCount++;
                if (VariablesInfo[i].IsSteward)
                    StewardCount++;
                if (VariablesInfo[i].IsModified)
                    ModifiedCount++;
                if (VariablesInfo[i].IsParasitic)
                    ParasiticCount++;
                ListViewItem Item = new ListViewItem(VariablesInfo[i].Identifier);
                Item.SubItems.Add(VariablesInfo[i].IsData.ToString());
                Item.SubItems.Add(VariablesInfo[i].IsSteward.ToString());
                Item.SubItems.Add(VariablesInfo[i].IsModified.ToString());                
                Item.SubItems.Add(VariablesInfo[i].IsParasitic.ToString());
                listResult.Items.Add(Item);
            }
            const double DataVarieblesCoefficient = 1;
            const double StewardVariablesCoefficient = 3;
            const double ModifiedVariablesCoefficient = 2;
            const double ParasiticVariablesCoefficient = 0.5;
            txtResult.Text = "Значение метрики = P + 2M + 3C + 0.5T = " + (DataCount * DataVarieblesCoefficient + StewardCount * StewardVariablesCoefficient + ModifiedCount * ModifiedVariablesCoefficient + ParasiticCount * ParasiticVariablesCoefficient);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtJavaCode.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
