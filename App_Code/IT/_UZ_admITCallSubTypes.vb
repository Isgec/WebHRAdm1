Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  Partial Public Class admITCallSubTypes
		Public Function GetColor() As System.Drawing.Color
			Dim mRet As System.Drawing.Color = Drawing.Color.Blue
			Return mRet
		End Function
		Public Function GetVisible() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
		Public Function GetEnable() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
    Public Shared Function UZ_admITCallSubTypesInsert(ByVal Record As SIS.ADM.admITCallSubTypes) As SIS.ADM.admITCallSubTypes
      Dim _Result As SIS.ADM.admITCallSubTypes = admITCallSubTypesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_admITCallSubTypesUpdate(ByVal Record As SIS.ADM.admITCallSubTypes) As SIS.ADM.admITCallSubTypes
      Dim _Result As SIS.ADM.admITCallSubTypes = admITCallSubTypesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_admITCallSubTypesDelete(ByVal Record As SIS.ADM.admITCallSubTypes) As Integer
      Dim _Result as Integer = admITCallSubTypesDelete(Record)
      Return _Result
    End Function
  End Class
End Namespace
