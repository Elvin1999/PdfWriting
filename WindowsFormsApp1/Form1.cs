using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();


        }
        public FileInfo Info { get; set; }
        OilSystem system = new OilSystem();
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.BackColor = Color.White;
            var a = e.Data.GetData(DataFormats.FileDrop) as string[];
            var Info = new FileInfo(a[0]);
            listBox1.DisplayMember = "Name";
            listBox1.Items.Add(Info.FullName);

        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            listBox1.BackColor = Color.Red;
            e.Effect = DragDropEffects.All;
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            //var item = listBox1.SelectedItem as string;
            //var result = File.ReadAllText(item);
            //var oilSystemItem = JsonConvert.DeserializeObject<OilSystem>(result);
            //richTextBox1.Text = oilSystemItem.GetAllPrice().ToString();
            foreach (var myitem in listBox1.Items)
            {
                var filetext = myitem.ToString();
                //var read = File.ReadAllText(filetext);
               // OilSystem system1 = JsonConvert.DeserializeObject<OilSystem>(read);
                var pdffile = filetext.Remove(filetext.Length - 5, 5) + ".pdf";
                MessageBox.Show(pdffile);
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(pdffile, FileMode.Create));
                document.Open();
                Paragraph elements = new Paragraph($@"{filetext}");
                document.Add(elements);
                document.Close();
            }



        }
    }
}
