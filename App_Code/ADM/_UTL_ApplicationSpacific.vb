Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports Microsoft.VisualBasic
Imports System
Namespace SIS.SYS.Utilities
  Public Class ApplicationSpacific
    Public Shared Sub Initialize()
      With HttpContext.Current
        .Session("ApplicationID") = 11
        .Session("ApplicationDefaultPage") = "~/Default.aspx"
        Dim oEmp As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(HttpContext.Current.Session("LoginID"))
        If Not oEmp Is Nothing Then
          .Session("C_OfficeID") = oEmp.C_OfficeID
        Else
          Dim oUsr As SIS.SYS.VRUsers = SIS.SYS.VRUsers.GetByID(HttpContext.Current.Session("LoginID"))
          .Session("C_OfficeID") = oUsr.C_OfficeID
        End If
      End With
      'Check And Create Sheet
      CheckSheet(DateValue(Now))
    End Sub
    Private Shared Sub CheckSheet(ByVal DataDate As DateTime)
      Dim oSrvs As List(Of SIS.ADM.admServices) = SIS.ADM.admServices.SelectList("")
      For Each oSrv As SIS.ADM.admServices In oSrvs
        Try
          Dim oSht As SIS.ADM.admLWServiceSheetHeader = SIS.ADM.admLWServiceSheetHeader.GetByServiceDate(DataDate, oSrv.ServiceID)
          If oSht Is Nothing Then
            GenerateSheet(DataDate, oSrv.ServiceID)
          End If
        Catch ex As Exception
          Throw New Exception("Error During Sheet Creation. Service ID:" & oSrv.ServiceID & ", Date: " & DataDate.ToString("dd/MM/yyyy"))
        End Try
      Next
    End Sub

    Public Shared Sub ApplicationReports(ByVal Context As HttpContext)
      If Not Context.Request.QueryString("ReportName") Is Nothing Then
        Select Case (Context.Request.QueryString("ReportName").ToLower)
          Case "initiatorsheet"
            Dim oRep As RPT_admInitiatorSheet = New RPT_admInitiatorSheet(Context)
            oRep.GenerateReport()
          Case "monitorsheet"
            Dim oRep As RPT_admMonitorSheet = New RPT_admMonitorSheet(Context)
            oRep.GenerateReport()
          Case "complaintregister"
            'Dim oRep As RPT_admITRegisterComplaint = New RPT_admITRegisterComplaint(Context)
            'oRep.GenerateReport()
          Case "admincomplaintregister"
            Dim oRep As RPT_admRegisterComplaint = New RPT_admRegisterComplaint(Context)
            oRep.GenerateReport()
        End Select
      End If
    End Sub
    Public Shared Function ContentType(ByVal FileName As String) As String
      Dim mRet As String = "application/octet-stream"
      Dim Extn As String = IO.Path.GetExtension(FileName).ToLower.Replace(".", "")
      Select Case Extn
        Case "pdf", "rtf"
          mRet = "application/" & Extn
        Case "doc", "docx"
          mRet = "application/vnd.ms-works"
        Case "xls", "xlsx"
          mRet = "application/vnd.ms-excel"
        Case "gif", "jpg", "jpeg", "png", "tif", "bmp"
          mRet = "image/" & Extn
        Case "pot", "ppt", "pps", "pptx", "ppsx"
          mRet = "application/vnd.ms-powerpoint"
        Case "htm", "html"
          mRet = "text/HTML"
        Case "txt"
          mRet = "text/plain"
        Case "zip"
          mRet = "application/zip"
        Case "rar", "tar", "tgz"
          mRet = "application/x-compressed"
        Case Else
          mRet = "application/octet-stream"
      End Select
      Return mRet
    End Function
  End Class
  Public Class rptxHandler
    Implements IHttpHandler
    Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
      Get
        Return True
      End Get
    End Property
    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
      SIS.SYS.Utilities.ApplicationSpacific.ApplicationReports(context)
    End Sub
  End Class

End Namespace