Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_fecha.Text = Date.Now
        If Not Page.IsPostBack Then
            Dim id As Integer
            id = Request.QueryString("id")
            Label17.Text = id
            Dim data As SqlDataReader
            SqlDataSource2.SelectCommand = "select * from tt_cliente where id=" & id
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            While data.Read
                txt_nombre.Text = data.GetValue(1)
                txt_telefono.Text = data.GetValue(2)
                txt_direccion.Text = data.GetValue(3)
                txt_casa.Text = data.GetValue(4)
                txt_comentarios.Text = data.GetValue(9)
                DropDownList1.SelectedItem.Text = data.GetValue(7)
                DropDownList2.SelectedItem.Text = data.GetValue(12)
            End While
            data.Close()

        End If


        'DataList1.DataSource = SqlDataSource3
        'DataList1.DataBind()
        If Session("autorizado") = 0 Then

        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SqlDataSource2.UpdateCommand = "update tt_cliente set cliente='" & txt_nombre.Text & "',telefono='" & txt_telefono.Text & "',direccion='" & txt_direccion.Text & "' ,Comentarios='" & txt_comentarios.Text & "',num_casa='" & txt_casa.Text & "',visitas='" & DropDownList1.SelectedItem.Text & "',rentas='" & DropDownList2.SelectedItem.Text & "' where id='" & Label17.Text & "' "
        SqlDataSource2.Update()
        Response.Redirect("baja_clientes.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 0
        Response.Redirect("baja_clientes.aspx")
    End Sub







End Class
