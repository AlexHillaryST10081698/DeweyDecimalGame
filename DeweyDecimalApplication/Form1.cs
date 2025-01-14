using DeweyDecimalApplication.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalApplication
{
    public partial class Home_Form : Form
    {
        private Form activeForm;
        
        public Home_Form()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(915, 580);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            HomePagePanel.Controls.Add(childForm);
            HomePagePanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            //setting the panel move ro be inline with button clicked
            panelMove.Top = HomeBtn.Top;
            panelMove.Left= HomeBtn.Left;
            OpenChildForm(new Forms.HomeForm(), sender);

        }

        private void ReplacingBooksBtn_Click(object sender, EventArgs e)
        {
            //setting the panel move ro be inline with button clicked
            panelMove.Top= ReplacingBooksBtn.Top;
            panelMove.Left = ReplacingBooksBtn.Left;
            OpenChildForm(new Forms.ReplacingBooks(), sender); //Open the child form Replacing books
            
        }

        private void IdentifyingAreasBtn_Click(object sender, EventArgs e)
        {
            //setting the panel move ro be inline with button clicked
            panelMove.Left = IdentifyingAreasBtn.Left;
            panelMove.Top = IdentifyingAreasBtn.Top;
            OpenChildForm(new Forms.IdentifyingAreas(), sender);
        }

        private void FindingCallNumBtn_Click(object sender, EventArgs e)
        {
            //setting the panel move ro be inline with button clicked
            panelMove.Left = FindingCallNumBtn.Left;
            panelMove.Top = FindingCallNumBtn.Top;
            OpenChildForm(new Forms.FindingCallNumbers(), sender);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //setting the panel move ro be inline with button clicked
            panelMove.Left = ExitBtn.Left;
            panelMove.Top = ExitBtn.Top;
            Environment.Exit(0); //Ends the application
        }
    }
}
