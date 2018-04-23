using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Utils;

namespace RichEditHighlightCurrentRow {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            richEditControl1.LoadDocument(System.IO.Directory.GetCurrentDirectory() + @"\..\..\MovieRentals.docx");
        }

        private void richEditControl1_Paint(object sender, PaintEventArgs e) {
            DocumentRange range = richEditControl1.Document.Selection;
            Rectangle rect = richEditControl1.GetBoundsFromPosition(range.Start);

            rect = new Rectangle(
                0,
                (int)Units.DocumentsToPixels(rect.Top, richEditControl1.DpiX),
                richEditControl1.ClientSize.Width,
                (int)Units.DocumentsToPixels(rect.Height, richEditControl1.DpiX));

            Brush brush = new SolidBrush(Color.FromArgb(100, Color.Red));
            e.Graphics.FillRectangle(brush, rect);
        }

        private void richEditControl1_SelectionChanged(object sender, EventArgs e) {
            richEditControl1.Refresh();
        }
    }
}