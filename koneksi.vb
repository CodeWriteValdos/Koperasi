Imports MySql.Data.MySqlClient
Module koneksi
    Public koneksi As MySqlConnection

    Public Function con() As MySqlConnection
        Try
            koneksi = New MySqlConnection("server=localhost;userid=root;password=;database=koperasi_cbt;")
            If koneksi.State = ConnectionState.Closed Then
                koneksi.Open()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return koneksi
    End Function

End Module
