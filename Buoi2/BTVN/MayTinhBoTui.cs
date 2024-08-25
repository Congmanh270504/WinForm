using System.Data;

namespace BTVN
{
    public partial class formMTBT : Form
    {
        private string expression = "";
        public formMTBT()
        {
            InitializeComponent();
            btn1.Click += new EventHandler(Button_Click);
            btn2.Click += new EventHandler(Button_Click);
            btn3.Click += new EventHandler(Button_Click);
            btn4.Click += new EventHandler(Button_Click);
            btn5.Click += new EventHandler(Button_Click);
            btn6.Click += new EventHandler(Button_Click);
            btn7.Click += new EventHandler(Button_Click);
            btn8.Click += new EventHandler(Button_Click);
            btn9.Click += new EventHandler(Button_Click);
            btn0.Click += new EventHandler(Button_Click);
            btnPush.Click += new EventHandler(Button_Click);
            btnMinus.Click += new EventHandler(Button_Click);
            btnTime.Click += new EventHandler(Button_Click);
            btnDevision.Click += new EventHandler(Button_Click);
        }
        static double EvaluateExpression(string expression)
        {
            DataTable table = new DataTable();
            return Convert.ToDouble(table.Compute(expression, string.Empty));
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                expression += clickedButton.Text;
                tbResult.Text = expression;
            }
        }
        private bool IsValidExpression(string expression)
        {
            char[] operators = { '+', '-', '*', '/' };
            for (int i = 0; i < expression.Length - 1; i++)
            {
                if (Array.Exists(operators, op => op == expression[i]) && Array.Exists(operators, op => op == expression[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(expression))
            {
                tbResult.Text = "";
            }
            else if (!IsValidExpression(expression))
            {
                errorProvider.SetError(tbResult, "Biểu thức không hợp lệ");
            }
            else
            {
                errorProvider.Clear();
                tbResult.Text = EvaluateExpression(expression).ToString();

            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            expression = "";
            tbResult.Clear();
        }

        private void formMTBT_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát hay không", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            expression = expression.Remove(expression.Length - 1, 1);
            tbResult.Text = expression;
        }
    }
}
