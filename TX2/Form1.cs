using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TX2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();
        string tentep = @"D:\DocumentOnClass\2025_2026\Ky_1\TichHopHeThong\TX2\TX2\nhanhvien.xml";
        private void hienThi()
        {
            bangNhanVien.Rows.Clear();
            doc.Load(tentep);

            XmlNodeList nhanviens = doc.SelectNodes("ds/nhanvien");

            foreach (XmlNode nv in nhanviens)
            {
                string manv = nv.SelectSingleNode("@manv").InnerText;
                string ho = nv.SelectSingleNode("hoten/ho").InnerText;
                string ten = nv.SelectSingleNode("hoten/ten").InnerText;
                string diachi = nv.SelectSingleNode("diachi").InnerText;

                bangNhanVien.Rows.Add(manv, ho, ten, diachi);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hienThi();
        }

        private void bangNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;

            manvTXT.Text = bangNhanVien.Rows[d].Cells[0].Value.ToString();
            hoTXT.Text = bangNhanVien.Rows[d].Cells[1].Value.ToString();
            tenTXT.Text = bangNhanVien.Rows[d].Cells[2].Value.ToString();
            diachiTXT.Text = bangNhanVien.Rows[d].Cells[3].Value.ToString();
        }

        private void them_Click(object sender, EventArgs e)
        {
            XmlElement goc = doc.DocumentElement;
            XmlElement nv = doc.CreateElement("nhanvien");
            nv.SetAttribute("manv", manvTXT.Text);
            XmlElement hoten = doc.CreateElement("hoten");
            XmlElement ho = doc.CreateElement("ho");
            XmlElement ten = doc.CreateElement("ten");
            XmlElement diachi = doc.CreateElement("diachi");

            ho.InnerText = hoTXT.Text;
            ten.InnerText = tenTXT.Text;
            diachi.InnerText = diachiTXT.Text;

            hoten.AppendChild(ho);
            hoten.AppendChild(ten);

            nv.AppendChild(hoten);
            nv.AppendChild(diachi);

            goc.AppendChild(nv);
            doc.Save(tentep);

            hienThi();
        }

        private void sua_Click(object sender, EventArgs e)
        {
            XmlElement goc = doc.DocumentElement;

            XmlNode nvc = doc.SelectSingleNode("ds/nhanvien[@manv='" + manvTXT.Text + "']");

            if(nvc != null)
            {
                XmlElement nv = doc.CreateElement("nhanvien");
                nv.SetAttribute("manv", manvTXT.Text);
                XmlElement hoten = doc.CreateElement("hoten");
                XmlElement ho = doc.CreateElement("ho");
                XmlElement ten = doc.CreateElement("ten");
                XmlElement diachi = doc.CreateElement("diachi");

                ho.InnerText = hoTXT.Text;
                ten.InnerText = tenTXT.Text;
                diachi.InnerText = diachiTXT.Text;

                hoten.AppendChild(ho);
                hoten.AppendChild(ten);

                nv.AppendChild(hoten);
                nv.AppendChild(diachi);

                goc.ReplaceChild(nv, nvc);
                doc.Save(tentep);

                hienThi();
            }
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            XmlElement goc = doc.DocumentElement;

            XmlNode nv = doc.SelectSingleNode("ds/nhanvien[@manv='" + manvTXT.Text + "']");
            if(nv != null)
            {
                goc.RemoveChild(nv);
                doc.Save(tentep);
                hienThi();
            }
        }

        private void tim_Click(object sender, EventArgs e)
        {
            bangNhanVien.Rows.Clear();
            XmlNode nv = doc.SelectSingleNode("ds/nhanvien[@manv='" + manvTXT.Text + "']");
            if (nv != null)
            {
                string manv = nv.SelectSingleNode("@manv").InnerText;
                string ho = nv.SelectSingleNode("hoten/ho").InnerText;
                string ten = nv.SelectSingleNode("hoten/ten").InnerText;
                string diachi = nv.SelectSingleNode("diachi").InnerText;

                bangNhanVien.Rows.Add(manv, ho, ten, diachi);
            }
               
        }

        private void lamMoi_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
