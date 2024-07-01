using System.IO;
using System.Security.Policy;
using System.Windows.Forms.Design;

namespace BatchRename_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            textBox4.Text = "ing...";
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < paths.Length; i++)
            {
                string path = paths[i];
                FileInfo fi = new FileInfo(path);
                textBox1.Text = fi.LastWriteTime.ToString("yyyyMMdd_hhmmss");
                string yyyyMMdd_hhmmss = fi.LastWriteTime.ToString("yyyyMMdd_hhmmss");
                if (File.Exists(Path.GetDirectoryName(path) + "\\" + textBox2.Text + yyyyMMdd_hhmmss + textBox3.Text + Path.GetExtension(path)))
                {
                    for (int j = 1;0==0;j++)
                    {
                        if (File.Exists(Path.GetDirectoryName(path) + "\\" + textBox2.Text + yyyyMMdd_hhmmss + textBox3.Text + "(" + j.ToString() + ")" + Path.GetExtension(path)))
                        { }
                        else if (File.Exists(path))
                        {
                            File.Move(path, Path.GetDirectoryName(path) + "\\" + textBox2.Text + yyyyMMdd_hhmmss + textBox3.Text + "(" + j.ToString() + ")" + Path.GetExtension(path));
                            break;
                        }
                    }
                }
                else if (File.Exists(path))
                    File.Move(path, Path.GetDirectoryName(path) + "\\" + textBox2.Text + yyyyMMdd_hhmmss + textBox3.Text + Path.GetExtension(path));
            }
            textBox4.Text = "end...";
        }
    }
}