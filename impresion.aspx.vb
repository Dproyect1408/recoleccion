Imports System.Data

Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_fecha.Text = Date.Now
        If Session("autorizado") = 0 Then
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fecha As Date
        fecha = txt_fecha.Text
        If DropDownList1.SelectedValue <> "Seleccionar..." Then
            SqlDataSource2.InsertCommand = "insert into tt_usuarios(nombre,usuario,pass,fecha,tipo) values('" & txt_nombre.Text & "', '" & txt_usuario.Text & "', '" & txt_pass.Text & "', '" & fecha.ToString("yyyy-MM-dd") & "','" & DropDownList1.SelectedValue & "')"
            SqlDataSource2.Insert()

        End If
        Response.Redirect("alta.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 0
        Response.Redirect("menu.aspx")
    End Sub
End Class
