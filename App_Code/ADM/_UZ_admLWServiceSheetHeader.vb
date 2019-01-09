Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	Partial Public Class admLWServiceSheetHeader
		Public Shared Function GetByServiceDate(ByVal SheetDate As DateTime, ByVal ServiceID As String) As SIS.ADM.admLWServiceSheetHeader
			Dim Results As SIS.ADM.admLWServiceSheetHeader = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadm_LG_LWServiceSheetHeaderSelectByServiceDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetDate", SqlDbType.DateTime, 20, SheetDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID", SqlDbType.NVarChar, 10, ServiceID)
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ADM.admLWServiceSheetHeader(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
	End Class
End Namespace
