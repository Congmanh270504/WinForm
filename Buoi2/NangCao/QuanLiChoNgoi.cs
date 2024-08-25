namespace NangCao
{
    public partial class formQuanLyChoNgoi : Form
    {
        private int sum = 0;
        private List<Button> clickedButtons = new List<Button>(); // Danh sách các Button đã được bấm
        public formQuanLyChoNgoi()
        {
            InitializeComponent();

            // Gán sự kiện Click chung cho tất cả các Button
            btn1.Click += new EventHandler(Button_Click);
            btn2.Click += new EventHandler(Button_Click);
            btn3.Click += new EventHandler(Button_Click);
            btn4.Click += new EventHandler(Button_Click);
            btn5.Click += new EventHandler(Button_Click);
            btn6.Click += new EventHandler(Button_Click);
            btn7.Click += new EventHandler(Button_Click);
            btn8.Click += new EventHandler(Button_Click);
            btn9.Click += new EventHandler(Button_Click);
            btn10.Click += new EventHandler(Button_Click);
            btn11.Click += new EventHandler(Button_Click);
            btn12.Click += new EventHandler(Button_Click);
            btn13.Click += new EventHandler(Button_Click);
            btn14.Click += new EventHandler(Button_Click);
            btn15.Click += new EventHandler(Button_Click);
        }

        private void formQuanLyChoNgoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát hay không", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            // Lấy Button đã được bấm
            Button clickedButton = sender as Button;
            if (clickedButton.BackColor == Color.Yellow)
            {
                MessageBox.Show("Chỗ đã có người đặt vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (clickedButton != null)
            {
                // Lấy giá trị của thuộc tính Name hoặc Text của Button
                string btnName = clickedButton.Name;
                int btnText = int.Parse(clickedButton.Text);
                clickedButton.BackColor = Color.LightBlue;
                clickedButtons.Add(clickedButton);
                if (btnText >= 1 && btnText <= 5)
                {
                    sum += 1000;
                }
                else if (btnText >= 6 && btnText <= 10)
                {
                    sum += 1500;
                }
                else
                {
                    sum += 2000;
                }
            }
            tbThanhTien.Text = sum.ToString() + "đ";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn hủy hay không", "Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                foreach (Button btn in clickedButtons)
                {
                    if (btn.BackColor != Color.Yellow)
                    {
                        btn.BackColor = Color.White;
                    }
                }
                // Xóa danh sách các Button đã được bấm
                clickedButtons.Clear();
                // Đặt lại tổng tiền về 0
                sum = 0;
                tbThanhTien.Text = "";
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (tbThanhTien.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbThanhTien, "Chưa chọn chỗ ngồi");
            }
            else
            {
                errorProvider.SetError(tbThanhTien, "");
                MessageBox.Show("Đã thêm chỗ ngồi thành công\nTổng tiền là: " + sum.ToString() + "đ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Button item in clickedButtons)
                {
                    if (item.BackColor == Color.LightBlue)
                    {
                        item.BackColor = Color.Yellow;
                    }
                }
                sum = 0;
                tbThanhTien.Text = "";
            }
        }
    }
}
