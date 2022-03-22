
Partial Class _Default
    Inherits System.Web.UI.Page




    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("autorizado") <> 3 Then
                Response.Redirect("login.aspx")
            End If
        End If

    End Sub



    Protected Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
        Session("autorizado") = 4
        Response.Redirect("login.aspx")
    End Sub



    Protected Sub ImageButton6_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton6.Click
        Session("autorizado") = 3
        Response.Redirect("cuentas_cobro.aspx")
    End Sub


End Class
