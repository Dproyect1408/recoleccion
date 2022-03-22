
Partial Class _Default
    Inherits System.Web.UI.Page


    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("alta.aspx")
    End Sub

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("autorizado") <> 0 Then
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
        Response.Redirect("alta_cliente.aspx")
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        Session("autorizado") = 0
        Response.Redirect("captura_admin.aspx")
    End Sub

    Protected Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
        Session("autorizado") = 3
        Response.Redirect("login.aspx")
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("lista2.aspx")
    End Sub

    Protected Sub ImageButton6_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton6.Click
        Session("autorizado") = 0
        Response.Redirect("cuentas.aspx")
    End Sub

    Protected Sub ImageButton7_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton7.Click
        Response.Redirect("alta_cliente_directo.aspx")
    End Sub

    Protected Sub ImageButton8_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton8.Click
        Response.Redirect("baja_clientes.aspx")
    End Sub
End Class
