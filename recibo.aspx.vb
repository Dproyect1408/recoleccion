Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim visitado As Integer

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim aa, ba, ca, da, ea, ma As String
        aa = Request.QueryString("a")
        ba = Request.QueryString("b")
        ca = Request.QueryString("c")
        da = Request.QueryString("d")
        ea = Request.QueryString("e")
        ma = Request.QueryString("f")
        If Not Page.IsPostBack Then
            Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            Dim pdfw As iTextSharp.text.pdf.PdfWriter
            Dim cb As PdfContentByte
            Dim fuente As iTextSharp.text.pdf.BaseFont
            Dim NombreArchivo As String = ""
            Dim nombre As String = "~/recibos/recibo " + aa + " " + ma + ".pdf"
            Try
                NombreArchivo = HttpContext.Current.Server.MapPath(nombre)

                pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo,
                FileMode.Create, FileAccess.Write, FileShare.None))
                'Apertura del documento.
                oDoc.Open()
                'oDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
                cb = pdfw.DirectContent
                'Agregamos una pagina.
                oDoc.NewPage()
                'Iniciamos el flujo de bytes.

                cb.BeginText()
                'Instanciamos el objeto para la tipo de letra.
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
                'Seteamos el tipo de letra y el tamaño.
                'cb.SetFontAndSize(fuente, 16)
                'Seteamos el color del texto a escribir.
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
                'Aqui es donde se escribe el texto.
                'Aclaracion: Por alguna razon la coordenada vertical siempre es tomada desde el borde inferior (de ahi que se calcule como “PageSize.A4.Height – 50″)
                'imagen
                Dim oIlogo As iTextSharp.text.Image
                oIlogo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/img/RECIBO.jpg"))
                oIlogo.SetAbsolutePosition(40, 250)
                oIlogo.ScaleAbsolute(520, 500)
                oDoc.Add(oIlogo)


                cb.SetFontAndSize(fuente, 20)
                'NOMBRE DEL CLIENTE
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Fecha: " + Date.Now, 200, 580, PageSize.A4.Height - 122)

                cb.SetFontAndSize(fuente, 18)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rentas: " + FormatCurrency(ca), 60, 560, PageSize.A4.Height - 122)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Recoleccion: " + FormatCurrency(da), 60, 540, PageSize.A4.Height - 122)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mes pagado: " + ea, 60, 520, PageSize.A4.Height - 122)



                'NUMERO DE CREDITO CON FR
                cb.SetFontAndSize(fuente, 18)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Nombre: " + aa, 60, 500, PageSize.A4.Height - 122)
                'NUMERO DE CREDITO CON FR
                cb.SetFontAndSize(fuente, 18)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cantidad Pagada: " + FormatCurrency(ba), 60, 480, PageSize.A4.Height - 122)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cuauhtémoc Chih.", 60, 460, PageSize.A4.Height - 122)
                cb.EndText()

                'Forzamos vaciamiento del buffer.
                pdfw.Flush()
                'Cerramos el documento.
                oDoc.Close()

            Catch ex As Exception
                'Si hubo una excepcion y el archivo existe …
                If File.Exists(NombreArchivo) Then
                    'Cerramos el documento si esta abierto.
                    'Y asi desbloqueamos el archivo para su eliminacion.
                    If oDoc.IsOpen Then oDoc.Close()
                    '… lo eliminamos de disco.
                    File.Delete(NombreArchivo)
                End If
                Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
            Finally
                cb = Nothing
                pdfw = Nothing
                oDoc = Nothing

            End Try
            Response.Redirect("~/recibos/recibo " + aa + " " + ma + ".pdf")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub



    Protected Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub



    Protected Sub boton_Click(sender As Object, e As EventArgs) Handles boton.Click

    End Sub
End Class
