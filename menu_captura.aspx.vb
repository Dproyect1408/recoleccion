
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("autorizado") = 1 Or Session("autorizado") = 2 Then
            Label1.Text = Session("autorizado")
            If Label1.Text = 1 Then
                Label2.Text = "Chofer 1"
            Else
                Label2.Text = "Chofer 2"
            End If
        Else

            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        If Label1.Text = 1 Then
            Session("autorizado") = 1
            Response.Redirect("captura.aspx")
        Else
            If Label1.Text = 2 Then
                Session("autorizado") = 2
                Response.Redirect("captura.aspx")
            Else

            End If
        End If

    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Session("autorizado") = 1
        Response.Redirect("login.aspx")

    End Sub

    Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
        'Session("autorizado") = 1
        'Response.Redirect("alta_cliente_chofer.aspx")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
