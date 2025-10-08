Imports Microsoft.Data.SqlClient

Public Class DBConnection
    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection("Data Source=DESKTOP-VJJVSTB\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True")
    End Function
End Class