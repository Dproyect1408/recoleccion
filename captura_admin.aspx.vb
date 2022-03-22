Imports System.Data

Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim visitado As Integer

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim mes As String
            mes = Date.Now.Month
            Label9.Text = mes

            Dim data13 As SqlDataReader
            Dim mes_lista As Integer
            SqlDataSource2.SelectCommand = "SELECT max(mes) FROM  tt_lista  "
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data13 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            While data13.Read
                mes_lista = data13.GetValue(0)
            End While
            If mes_lista = mes Then
                'Dim data12 As SqlDataReader
                'SqlDataSource2.SelectCommand = "SELECT id FROM  dbo.tt_cliente where visitas=visitado  "
                'SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                'data12 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                'While data12.Read
                '    SqlDataSource2.UpdateCommand = "update tt_lista set activo=0  where id_cliente='" & data12.GetValue(0) & "'"
                '    SqlDataSource2.Update()
                'End While

                Dim data As SqlDataReader
                SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.Id AS Expr2, dbo.tt_cliente.cliente + ' - ' + dbo.tt_cliente.direccion + ' - ' + dbo.tt_cliente.num_casa AS Expr1, dbo.tt_cliente.telefono, dbo.tt_lista.orden, dbo.tt_lista.activo FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id WHERE (dbo.tt_lista.activo = 1) AND (dbo.tt_lista.mes = @mes) and (dbo.tt_lista.chofer=1 or dbo.tt_lista.chofer=0) and dbo.tt_cliente.visitas >dbo.tt_cliente.visitado  ORDER BY dbo.tt_lista.orden"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                Dim i As New ListItem
                While data.Read
                    i = New ListItem(data.GetValue(2), data.GetValue(1))

                    ddl_cliente.Items.Add(i)

                End While
                If ddl_cliente.Items.Count <> 0 Then
                    Dim visitas4 As Integer
                    Dim data4 As SqlDataReader
                    SqlDataSource2.SelectCommand = "SELECT visitas,visitado FROM dbo.tt_cliente WHERE id=" & ddl_cliente.SelectedItem.Value
                    SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                    data4 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                    While data4.Read
                        Label11.Text = data4.GetValue(0)
                        Label13.Text = data4.GetValue(1)
                    End While
                    data4.Close()
                End If
                txt_fecha.Text = Date.Now
                Dim fecha As Date
                fecha = txt_fecha.Text
                Dim day As Date
                day = "01/01/" & Date.Now.Year
                Calendar1.SelectedDate = Date.Now

                Dim semana As Integer

                semana = DateDiff("ww", day.ToString("yyyy-MM-dd"), fecha.ToString("yyyy-MM-dd"))
                Label7.Text = Val(semana)
            Else
                SqlDataSource2.DeleteCommand = "delete  tt_lista "
                SqlDataSource2.Delete()
                SqlDataSource2.UpdateCommand = "update tt_cliente set visitado=0 "
                SqlDataSource2.Update()

            End If
        End If

        If Session("autorizado") = 0 Then
            Else
                Response.Redirect("login.aspx")
            End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fecha As Date
        fecha = txt_fecha.Text
        Dim cantidad As Double
        cantidad = ddl_num.SelectedValue * 150
        SqlDataSource2.InsertCommand = "insert into tt_recoleccion(id_cliente,fecha,cantidad,debe) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd") & "', '" & ddl_num.SelectedValue & "', '" & cantidad & "')"
        SqlDataSource2.Insert()
        'SqlDataSource2.UpdateCommand = "update tt_lista set activo='" & 0 & "' where id_cliente='" & ddl_cliente.SelectedValue & "'"
        'SqlDataSource2.Update()



        SqlDataSource2.UpdateCommand = "update tt_cliente set visitado=visitado + 1  where id='" & ddl_cliente.SelectedValue & "'"
        SqlDataSource2.Update()

        Response.Redirect("captura_admin.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 0
        Response.Redirect("menu.aspx")
    End Sub

    Protected Sub ddl_cliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_cliente.SelectedIndexChanged
        Dim visitas As Integer
        Dim data As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT visitas,visitado FROM dbo.tt_cliente WHERE id=" & ddl_cliente.SelectedItem.Value


        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        While data.Read
            Label11.Text = data.GetValue(0)
            Label13.Text = data.GetValue(1)
        End While
    End Sub
End Class
