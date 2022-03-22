Imports System.Data

Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim data1 As SqlDataReader
            SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_cliente ORDER BY orden"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            DataList1.DataSource = data1
            DataList1.DataBind()
        End If
        ' txt_fecha.Text = Date.Now
        'DataList1.DataSource = SqlDataSource3
        'DataList1.DataBind()
        'If Session("autorizado") = 0 Then

        'Else
        '    Response.Redirect("login.aspx")
        'End If
    End Sub



    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 0
        Response.Redirect("menu.aspx")
    End Sub


    Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList1.SelectedIndexChanged

    End Sub

    Private Sub DataList1_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "captura" Then

            Dim id As Integer
            id = DataList1.DataKeys(e.Item.ItemIndex)
            SqlDataSource2.DeleteCommand = "Delete  from tt_cliente where id='" & id & "'"
            SqlDataSource2.Delete()
            Response.Redirect("baja_clientes.aspx")
        End If

        If e.CommandName = "Modificar" Then

            Dim id As Integer
            id = DataList1.DataKeys(e.Item.ItemIndex)
            Dim a As String
            a = "modif.aspx?id=" & id
            Dim script As String = " window.open('" + a + "','');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
            'Response.Redirect()
        End If



    End Sub



    Protected Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub SqlDataSource3_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource3.Selecting

    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub
End Class
