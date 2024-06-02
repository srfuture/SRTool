using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.IO; // 用于文件操作
using System.Drawing.Printing;



namespace SRCalculator
{

    public partial class Form1 : Form
    {
        public static string cf = "";
        public static string cfv = "";
        public static bool mod = false;
        public static bool save = false;
        public static string openfilePath;

        public Form1()
        {
            InitializeComponent();
            打开ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            保存ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            打印ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            退出ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Q;
            另存为ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift| Keys.S;
            toolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.N;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            cf = cf + "3";
            cfv = cfv + "3";
            textBox1.Text = cfv;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            cf = cf + "+";
            cfv = cfv + "+";
            textBox1.Text = cfv;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            var table = new System.Data.DataTable();
            var result = table.Compute(cf, null); // 注意：这里不能直接使用"^"进行幂运算
            cf = result.ToString(); // 这里可能发生InvalidCastException
            cfv = result.ToString(); // 这里可能发生InvalidCastException
            textBox1.Text = cfv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cf = cf + "1";
            cfv = cfv + "1";
            textBox1.Text = cfv;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cf = cf + "2";
            cfv = cfv + "2";
            textBox1.Text = cfv;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cf = cf + "4";
            cfv = cfv + "4";
            textBox1.Text = cfv;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cf = cf + "5";
            cfv = cfv + "5";
            textBox1.Text = cfv;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cf = cf + "6";
            cfv = cfv + "6";
            textBox1.Text = cfv;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cf = cf + "7";
            cfv = cfv + "7";
            textBox1.Text = cfv;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cf = cf + "8";
            cfv = cfv + "8";
            textBox1.Text = cfv;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cf = cf + "9";
            cfv = cfv + "9";
            textBox1.Text = cfv;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            cf = cf + "0";
            cfv = cfv + "0";
            textBox1.Text = cfv;
        }

        private void AC_Click(object sender, EventArgs e)
        {
            cf = "";
            cfv = "";
            textBox1.Text = cfv;
        }

        private void jian_Click(object sender, EventArgs e)
        {
            cf = cf + "-";
            cfv = cfv + "-";
            textBox1.Text = cfv;
        }

        private void left_Click(object sender, EventArgs e)
        {
            cf = cf + "(";
            cfv = cfv + "(";
            textBox1.Text = cfv;
        }

        private void right_Click(object sender, EventArgs e)
        {
            cf = cf + ")";
            cfv = cfv + ")";
            textBox1.Text = cfv;
        }

        private void cheng_Click(object sender, EventArgs e)
        {
            cf = cf + "*";
            cfv = cfv + "×";
            textBox1.Text = cfv;
        }

        private void chu_Click(object sender, EventArgs e)
        {
            cf = cf + "/";
            cfv = cfv + "÷";
            textBox1.Text = cfv;
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (cf.Length > 0)
            {
                cf = cf.Remove(cf.Length - 1);
                cfv = cfv.Remove(cfv.Length - 1);
                textBox1.Text = cfv;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 获取选择的文件路径
                openfilePath = openFileDialog1.FileName;
                // 这里可以添加你对文件的操作代码
                //Console.WriteLine(openfilePath);
                string fileContent = File.ReadAllText(@openfilePath);

                // 确保换行符是 Windows 格式的 \r\n
                fileContent = fileContent.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
                // 用替换后的文本设置 TextBox 的文本
                textBox2.Text = fileContent;
                mod = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {}

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            mod = false;
        }

        private void 保存ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (mod)
            {
                File.WriteAllText(@openfilePath, textBox2.Text);
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // 这里应该使用 saveFileDialog1.FileName 而不是 openFileDialog1.FileName
                    string savefilePath = saveFileDialog1.FileName;
                    File.WriteAllText(@savefilePath, textBox2.Text);
                }
            }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savefilePath = saveFileDialog1.FileName;
                File.WriteAllText(@savefilePath, textBox2.Text);
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            // 显示打印对话框，允许用户选择打印机并设置打印参数
            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                // 开始打印
                printDocument1.Print();
            }


        }
        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // 设置打印内容和格式
            string textToPrint = textBox2.Text;
            Font printFont = new Font("Arial", 10); // 可以根据需要调整字体
            e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, 10, 10); // 打印位置
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            save = false;
        }
    }
}
