using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        public int _length { get; set; }

        public bool _number { get; set; }
        public bool _symbol { get; set; }
        public bool _lowerCase { get; set; }
        public bool _upperCase { get; set; }

        public Form1()
        {
            InitializeComponent();
            _length = 5;
        }


        private void button_Click(object sender, EventArgs e) => password.Text = GeneratePassword();

        private void list_SelectedIndexChanged(object sender, EventArgs e) => _length = list.SelectedIndex + 5;

        private void checkBoxNumber_CheckedChanged(object sender, EventArgs e) => _number = checkBoxNumber.Checked;

        private void checkBoxSymbol_CheckedChanged(object sender, EventArgs e) => _symbol = checkBoxSymbol.Checked;

        private void checkBoxLowerCase_CheckedChanged(object sender, EventArgs e) => _lowerCase = checkBoxLowerCase.Checked;

        private void checkBoxUpperCase_CheckedChanged(object sender, EventArgs e) => _upperCase = checkBoxUpperCase.Checked;

        private void password_TextChanged(object sender, EventArgs e) { }

        private bool CheckStatus() => _number || _symbol || _lowerCase || _upperCase;

        private string GeneratePassword()
        {
            StringBuilder sb = new StringBuilder();

            if (!CheckStatus()) sb.Append("Select atleast one character set!");
            else
            {
                Random random = new Random();
                int tmp = _length;

            Label:
                int index = random.Next(0, 4);

                switch (index)
                {
                    case 0:
                        if (_number)
                        {
                            sb.Append((char)random.Next(48, 58));
                            tmp--;
                        }
                        break;
                    case 1:
                        if (_symbol)
                        {
                            switch (random.Next(0, 4))
                            {
                                case 0:
                                    sb.Append((char)random.Next(33, 48));
                                    break;
                                case 1:
                                    sb.Append((char)random.Next(58, 65));
                                    break;
                                case 2:
                                    sb.Append((char)random.Next(94, 97));
                                    break;
                                case 3:
                                    sb.Append((char)random.Next(123, 127));
                                    break;
                            }
                            tmp--;
                        }
                        break;
                    case 2:
                        if (_lowerCase)
                        {
                            sb.Append((char)random.Next(97, 123));
                            tmp--;
                        }
                        break;
                    case 3:
                        if (_upperCase)
                        {
                            sb.Append((char)random.Next(65, 91));
                            tmp--;
                        }
                        break;
                }
                if (tmp > 0) goto Label;
            }
            return sb.ToString();
        }
    }
}
