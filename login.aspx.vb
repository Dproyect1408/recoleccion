Imports System.Data

Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim a As Date
        a = Date.Now

        txt_fecha.Text = a.AddHours(+1)

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim data, data1 As SqlDataReader
        Dim fecha As Date
        fecha = txt_fecha.Text
        'SqlDataSource1.SelectCommand = "SELECT * FROM t_usuarios WHERE usuario='" & txt_usuario.Text & "' and password='" & FormsAuthentication.HashPasswordForStoringInConfigFile(txt_pass.Text, "SHA1") & "'"
        SqlDataSource1.SelectCommand = "SELECT * FROM tt_usuarios WHERE usuario='" & txt_usuario.Text & "' and pass='" & txt_pass.Text & "'"
        SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataReader
        data = SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        If data.Read Then
            'aignamos las variables de session
            Session("usuario") = txt_usuario.Text

            Session("tipo") = data.GetValue(5)
            If data.GetValue(5) = 0 Then
                Session("autorizado") = 0
                Response.Redirect("menu.aspx")

            Else
                If data.GetValue(5) = 1 Then
                    Session("autorizado") = 1
                    Response.Redirect("menu_captura.aspx")

                Else
                    If data.GetValue(5) = 2 Then
                        Session("autorizado") = 2
                        Response.Redirect("menu_captura.aspx")
                    Else
                        Session("autorizado") = 3
                        Response.Redirect("menu_cobro.aspx")
                    End If


                End If


            End If

        Else
            txt_usuario.Text = ""
            txt_pass.Text = ""
        End If
    End Sub
End Class
