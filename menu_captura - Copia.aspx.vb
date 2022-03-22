
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("autorizado") = 1 Then

        Else

            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        UpdatePanel1.Update()
        TextBox1.Text = Val(TextBox1.Text) + 1
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Session("autorizado") = 3
        Response.Redirect("login.aspx")

    End Sub
End Class
