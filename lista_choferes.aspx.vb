Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim miDataTable As New DataTable
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("autorizado") = 0 Then
        Else
            Response.Redirect("login.aspx")
        End If
        If Not Page.IsPostBack Then
            Session("contador") = 0
        End If
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 0
        Response.Redirect("menu.aspx")
    End Sub
    Private Sub DataList1_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "captura" Then
            Dim id As Integer
            id = DataList1.DataKeys(e.Item.ItemIndex)
            Dim cliente As Label = DataList1.Items(e.Item.ItemIndex).FindControl("clienteLabel")
            Dim cliente1 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("telefonoLabel")
            Dim cliente2 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("direccionLabel")
            Dim cliente3 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Num_casaLabel")
            If cliente.BackColor = Drawing.Color.GreenYellow Then
                cliente.BackColor = Drawing.Color.LightBlue
            Else
                cliente.BackColor = Drawing.Color.GreenYellow

            End If
            If cliente1.BackColor = Drawing.Color.GreenYellow Then
                cliente1.BackColor = Drawing.Color.LightBlue
            Else
                cliente1.BackColor = Drawing.Color.GreenYellow

            End If
            If cliente2.BackColor = Drawing.Color.GreenYellow Then
                cliente2.BackColor = Drawing.Color.LightBlue
            Else
                cliente2.BackColor = Drawing.Color.GreenYellow

            End If
            If cliente3.BackColor = Drawing.Color.GreenYellow Then
                cliente3.BackColor = Drawing.Color.LightBlue
            Else
                cliente3.BackColor = Drawing.Color.GreenYellow

            End If

            Dim data As SqlDataReader
                Dim fecha As Date
                fecha = Date.Now
                SqlDataSource2.SelectCommand = "SELECT id,cliente,telefono,direccion,num_casa,telefono FROM tt_cliente where id='" & id & "'"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                While data.Read
                    SqlDataSource3.InsertCommand = "insert into tt_lista([id_cliente],[orden],[activo],[fecha],recoleccion) values ('" & id & "','" & Session("contador") & "', '" & 1 & "', '" & fecha.ToString("yyyy-MM-dd") & "', '" & 0 & "')"
                    SqlDataSource3.Insert()
                    Session("contador") = Session("contador") + 1
                End While

                SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id ORDER BY dbo.tt_lista.orden asc"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                DataList2.DataSource = data
                DataList2.DataBind()

            End If
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim data As SqlDataReader
        DataList2.Visible = True
        'SqlDataSource2.DeleteCommand = "delete tt_lista"
        'SqlDataSource2.Delete()
        SqlDataSource2.SelectCommand = "SELECT id,cliente,telefono,direccion,num_casa FROM tt_cliente"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList1.DataSource = data
        DataList1.DataBind()
        data.Close()
    End Sub

    Protected Sub DataList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList2.SelectedIndexChanged

    End Sub

    Private Sub DataList2_DeleteCommand(source As Object, e As DataListCommandEventArgs) Handles DataList2.DeleteCommand

    End Sub

    Private Sub DataList2_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList2.ItemCommand
        If e.CommandName = "borrar" Then
            Dim id As Integer
            Dim data As SqlDataReader
            id = DataList2.DataKeys(e.Item.ItemIndex)
            SqlDataSource2.DeleteCommand = "delete tt_lista  where id='" & id & "'"
            SqlDataSource2.Delete()
            SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id ORDER BY dbo.tt_lista.orden asc"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            Data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            DataList2.DataSource = Data
            DataList2.DataBind()
            Data.Close()

        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '
        Dim fecha As Date
        fecha = Date.Today
        For x = 0 To DataList2.Items.Count - 1
            Dim cliente As Label = DataList2.Items(x).FindControl("clienteLabel")
            Dim telefono As Label = DataList2.Items(x).FindControl("telefonoLabel")
            Dim direccion As Label = DataList2.Items(x).FindControl("direccionLabel")
            Dim casa As Label = DataList2.Items(x).FindControl("num_casaLabel")
            Dim orden As Label = DataList2.Items(x).FindControl("ordenLabel")
            SqlDataSource3.InsertCommand = "insert into tt_lista_rom(cliente,telefono,direccion,numero,orden,fecha,tipo) values ('" & cliente.Text & "','" & telefono.Text & "', '" & direccion.Text & "', '" & casa.Text & "', '" & orden.Text & "', '" & fecha.ToString("yyyy-MM-dd") & "','" & 0 & "')"
            SqlDataSource3.Insert()

        Next
        Response.Write("<script> window.open('" + "imprimir.aspx" + "','_blank'); </script>")

    End Sub

    Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList1.SelectedIndexChanged

    End Sub
End Class
