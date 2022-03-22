Imports System.Data

Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim visitado As Integer

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_fecha.Text = Date.Today
        If Not Page.IsPostBack Then

            If Session("autorizado") = 0 Then
                ddl_cliente.Items.Clear()
                Dim data As SqlDataReader
                SqlDataSource2.SelectCommand = "select * from tt_cliente order by orden"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                Dim i As New ListItem
                While data.Read
                    i = New ListItem(data.GetValue(1) + " - " + data.GetValue(3) + " - " + data.GetValue(4), data.GetValue(0))

                    ddl_cliente.Items.Add(i)

                End While
                Dim data1 As SqlDataReader
                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_recoleccion WHERE id_cliente=" & ddl_cliente.SelectedItem.Value
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                DataList1.DataSource = data1
                DataList1.DataBind()

                '-----------------------------------------------------------------------------------------------------------------------------------

                'Dim visitas As Integer
                Dim data5 As SqlDataReader
                Dim deuda, abono As Double
                deuda = 0
                abono = 0
                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_recoleccion WHERE id_cliente=" & ddl_cliente.SelectedItem.Value
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data5 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                DataList1.DataSource = data5
                DataList1.DataBind()
                data5.Close()

                Dim data2 As SqlDataReader
                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_recoleccion WHERE id_cliente=" & ddl_cliente.SelectedItem.Value
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data2 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                If data2.Read Then
                    If IsDBNull(data2.GetValue(5)) Then
                        abono = 0
                    Else
                        abono = data2.GetValue(5)
                    End If

                End If
                data2.Close()


                Dim data3 As SqlDataReader
                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_cliente WHERE id=" & ddl_cliente.SelectedItem.Value
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data3 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                If data3.Read Then
                    Label25.Text = data3.GetValue(12)
                End If
                data3.Close()

                For x = 0 To DataList1.Items.Count - 1
                    Dim deve As Label = DataList1.Items(x).FindControl("debeLabel")
                    deuda = deuda + deve.Text
                Next
                Label21.Text = deuda
                Label24.Text = abono
                Label30.Text = deuda - abono

                '==============================================

                Dim data4 As SqlDataReader
                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=0"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data4 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                DataList2.DataSource = data4
                DataList2.DataBind()
                data4.Close()
                Dim cantidad As Integer
                cantidad = 0
                For x = 0 To DataList2.Items.Count - 1
                    Dim cant As Label = DataList2.Items(x).FindControl("cantidadLabel")
                    cantidad = cantidad + cant.Text
                Next
                Label28.Text = cantidad * 100

                Dim data6 As SqlDataReader
                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=1"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data6 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                DataList3.DataSource = data6
                DataList3.DataBind()
                data6.Close()

                '=====================




            Else
                Response.Redirect("login.aspx")
            End If
            Label30.Text = (Val(Label28.Text) + Val(Label21.Text)) - Val(Label24.Text)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        'sacamos la cantidad de registros
        Dim cantidad As Integer
        For x = 0 To DataList2.Items.Count - 1
            Dim cant As Label = DataList2.Items(x).FindControl("cantidadLabel")
            cantidad = cantidad + cant.Text
        Next
        'revisamos si es mayor  la cantidad abonada
        Dim recibo As String
        recibo = TextBox1.Text
        If TextBox1.Text > (cantidad * 100) Then
            For x = 0 To DataList2.Items.Count - 1
                Dim cant As Label = DataList2.Items(x).FindControl("cantidadLabel")
                Dim ident As Label = DataList2.Items(x).FindControl("id")
                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where id='" & ident.Text & "'"
                SqlDataSource2.Update()
            Next
            Dim fecha As Date
            fecha = txt_fecha.Text
            'Dim cantidad As Double
            'cantidad = ddl_num.SelectedValue * 150
            Dim bar As Integer
            bar = TextBox1.Text - (cantidad * 100)
            SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd") & "', '" & bar & "')"
            SqlDataSource2.Insert()
            SqlDataSource2.UpdateCommand = "update tt_recoleccion set activo='" & Convert.ToDouble(Label24.Text) + Convert.ToDouble(bar) & "' where id_cliente='" & ddl_cliente.SelectedValue & "'"
            SqlDataSource2.Update()
            TextBox1.Text = 0

            Dim data2 As SqlDataReader
            SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_recoleccion WHERE id_cliente=" & ddl_cliente.SelectedItem.Value
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data2 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            If data2.Read Then
                If IsDBNull(data2.GetValue(5)) Then
                    Label24.Text = 0
                Else
                    Label24.Text = data2.GetValue(5)
                End If

            End If
            data2.Close()
            'SqlDataSource2.UpdateCommand = "update tt_cliente set visitado=visitado + 1  where id='" & ddl_cliente.SelectedValue & "'"
            'SqlDataSource2.Update()
            Session("autorizado") = 0
            Response.Redirect("cuentas.aspx")

        Else
            For x = 0 To (TextBox1.Text / 100) - 1
                Dim cant As Label = DataList2.Items(x).FindControl("cantidadLabel")
                Dim ident As Label = DataList2.Items(x).FindControl("id")
                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where id='" & ident.Text & "'"
                SqlDataSource2.Update()
            Next
            Label28.Text = Label28.Text - TextBox1.Text
            TextBox1.Text = 0
            Dim data5 As SqlDataReader
            SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=1"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data5 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            DataList3.DataSource = data5
            DataList3.DataBind()
            data5.Close()
            Dim data4 As SqlDataReader
            SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=0"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data4 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            DataList2.DataSource = data4
            DataList2.DataBind()
            data4.Close()
        End If


        Label30.Text = (Val(Label28.Text) + Val(Label21.Text)) - Val(Label24.Text)
        UpdatePanel1.Update()
        Dim a As String
        a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + recibo
        Dim script As String = " window.open('" + a + "','');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Session("autorizado") = 1 Then
            Session("autorizado") = 1
            Response.Redirect("menu_captura.aspx")
        End If
        If Session("autorizado") = 2 Then
            Session("autorizado") = 2
            Response.Redirect("menu_captura.aspx")
        End If

    End Sub

    Protected Sub ddl_cliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_cliente.SelectedIndexChanged
        Dim visitas As Integer
        Dim data As SqlDataReader
        Dim deuda, abono As Double
        deuda = 0
        abono = 0
        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_recoleccion WHERE id_cliente=" & ddl_cliente.SelectedItem.Value
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList1.DataSource = data
        DataList1.DataBind()
        data.Close()

        Dim data2 As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_recoleccion WHERE id_cliente=" & ddl_cliente.SelectedItem.Value
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data2 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        If data2.Read Then
            If IsDBNull(data2.GetValue(5)) Then
                abono = 0
            Else
                abono = data2.GetValue(5)
            End If

        End If
        data2.Close()


        Dim data3 As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_cliente WHERE id=" & ddl_cliente.SelectedItem.Value
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data3 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        If data3.Read Then
            Label25.Text = data3.GetValue(12)
        End If
        data3.Close()

        For x = 0 To DataList1.Items.Count - 1
            Dim deve As Label = DataList1.Items(x).FindControl("debeLabel")
            deuda = deuda + deve.Text
        Next
        Label21.Text = deuda
        Label24.Text = abono
        Label30.Text = deuda - abono
        Dim data4 As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=0"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data4 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList2.DataSource = data4
        DataList2.DataBind()
        data4.Close()
        Dim cantidad As Integer
        cantidad = 0
        For x = 0 To DataList2.Items.Count - 1
            Dim cant As Label = DataList2.Items(x).FindControl("cantidadLabel")
            cantidad = cantidad + cant.Text
        Next
        Label28.Text = cantidad * 100

        Dim data5 As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=1"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data5 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList3.DataSource = data5
        DataList3.DataBind()
        data5.Close()
        Label30.Text = (Val(Label28.Text) + Val(Label21.Text)) - Val(Label24.Text)
        UpdatePanel1.Update()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub DataList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList2.SelectedIndexChanged

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataList2_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList2.ItemCommand
        If e.CommandName = "pagar" Then
            Dim cantidad As Integer

            For x = 0 To DataList2.Items.Count - 1
                Dim cant As Label = DataList2.Items(x).FindControl("cantidadLabel")
                cantidad = cantidad + cant.Text
            Next
            Label28.Text = (cantidad - 1) * 100
            Dim id As Integer
            id = DataList2.DataKeys(e.Item.ItemIndex)
            Dim data As SqlDataReader
            SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where id='" & id & "'"
            SqlDataSource2.Update()


            Dim data5 As SqlDataReader
            SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=1"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data5 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            DataList3.DataSource = data5
            DataList3.DataBind()
            data5.Close()
            Dim data4 As SqlDataReader
            SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=0"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data4 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            DataList2.DataSource = data4
            DataList2.DataBind()
            data4.Close()
        End If
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Response.Redirect("imprimir.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + TextBox1.Text)

    End Sub
End Class
