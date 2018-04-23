Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Utils

Namespace RichEditHighlightCurrentRow
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			richEditControl1.LoadDocument(System.IO.Directory.GetCurrentDirectory() & "\..\..\MovieRentals.docx")
		End Sub

		Private Sub richEditControl1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles richEditControl1.Paint
			Dim range As DocumentRange = richEditControl1.Document.Selection
			Dim rect As Rectangle = richEditControl1.GetBoundsFromPosition(range.Start)

			rect = New Rectangle(0, CInt(Fix(Units.DocumentsToPixels(rect.Top, richEditControl1.DpiX))), richEditControl1.ClientSize.Width, CInt(Fix(Units.DocumentsToPixels(rect.Height, richEditControl1.DpiX))))

			Dim brush As Brush = New SolidBrush(Color.FromArgb(100, Color.Red))
			e.Graphics.FillRectangle(brush, rect)
		End Sub

		Private Sub richEditControl1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles richEditControl1.SelectionChanged
			richEditControl1.Refresh()
		End Sub
	End Class
End Namespace