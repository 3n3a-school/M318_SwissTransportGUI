using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransportGUI.Controller;
using SwissTransportGUI.Model;

namespace SwissTransportGUI.View
{
    public partial class EmailDialog : Form
    {
        private bool Input1Filled { get; set; } = false;
        private bool Input2Filled { get; set; } = false;

        public string Input1Result { get; private set; } = "";
        public string Input2Result { get; private set; } = "";
        public EmailDialog(string question, string field1Label, string field2Label)
        {
            InitializeComponent();

            DialogQuestion.Text = question;
            InputLabel1.Text = field1Label;
            InputLabel2.Text = field2Label;
            InputField1.PlaceholderText = field1Label;
            InputField2.PlaceholderText = field2Label;
        }

        private void InputField1_TextChanged(object sender, EventArgs e)
        {
            if (InputField1.Text.Length > 0)
            {
                Input1Filled = true;
            }
            else
            {
                Input1Filled = false;
            }

            CheckIfAllFilledOut();
        }

        private void CheckIfAllFilledOut()
        {
            if (Input1Filled && Input2Filled)
            {
                ContinueButton.Enabled = true;
            }
            else
            {
                ContinueButton.Enabled = false;
            }
        }

        private void InputField2_TextChanged(object sender, EventArgs e)
        {
            if (InputField2.Text.Length > 0 && RegexHelper.IsValidEmail(InputField2.Text))
            {
                Input2Filled = true;
            }
            else
            {
                Input2Filled = false;
            }
            CheckIfAllFilledOut();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            Tag = new EmailDialogResult()
            {
                Name = InputField1.Text,
                Email = InputField2.Text,
            };
        }
    }
}
