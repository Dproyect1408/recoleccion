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
        Label1.Text = Request.QueryString("a")
        Label2.Text = Request.QueryString("b")
        Label3.Text = Request.QueryString("c")
        Label4.Text = Request.QueryString("d")
        Label5.Text = Request.QueryString("e")
        Label13.Text = Request.QueryString("g")
        Dim mes As String
        mes = Date.Now.Month

        Dim data1 As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & Label13.Text & "' And mes = " & Label5.Text & "  And imprimir = 1"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList1.DataSource = data1
        DataList1.DataBind()
        data1.Close()
        Label12.Text = Date.Today

    End Sub




    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub



    Protected Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub



End Class
