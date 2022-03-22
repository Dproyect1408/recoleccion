Imports System.Data

Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_fecha.Text = Date.Now

        If Session("autorizado") = 1 Then
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fecha As Date
        fecha = txt_fecha.Text
        Dim cantidad As Double
        cantidad = ddl_num.SelectedValue * 150
        SqlDataSource2.InsertCommand = "insert into tt_recoleccion(id_cliente,fecha,cantidad,debe) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd") & "', '" & ddl_num.SelectedValue & "', '" & cantidad & "')"
        SqlDataSource2.Insert()
        'SqlDataSource2.UpdateCommand = "update tt_lista set activo='" & 0 & "' where id_cliente='" & ddl_cliente.SelectedValue & "'"
        'SqlDataSource2.Update()
        Response.Redirect("captura.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 1
        Response.Redirect("menu_captura.aspx")
    End Sub
End Class
