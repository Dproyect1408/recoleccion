Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim miDataTable As New DataTable
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim data As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id and dbo.tt_lista.chofer=0 ORDER BY dbo.tt_lista.orden asc"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList2.DataSource = data
        DataList2.DataBind()

    End Sub



    Protected Sub DataList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList2.SelectedIndexChanged

    End Sub

    Private Sub DataList2_DeleteCommand(source As Object, e As DataListCommandEventArgs) Handles DataList2.DeleteCommand

    End Sub




End Class
