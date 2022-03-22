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

        SqlDataSource2.InsertCommand = "insert into tt_cliente(cliente,telefono,direccion,num_casa,longitud,latitud,visitas,fecha) values('" & txt_nombre.Text & "', '" & txt_telefono.Text & "', '" & txt_direccion.Text & "','" & txt_casa.Text & "','" & txt_longitud.Text & "','" & txt_latitud.Text & "','" & DropDownList1.SelectedValue & "','" & fecha.ToString("yyyy-MM-dd") & "')"
        SqlDataSource2.Insert()
        Session("autorizado") = 0
        Response.Redirect("alta_cliente.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 0
        Response.Redirect("menu.aspx")
    End Sub
End Class
