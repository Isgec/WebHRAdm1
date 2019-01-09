Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://WebHrAdm1.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class wsWebHrAdm1
	Inherits System.Web.Services.WebService
	<WebMethod()> _
	Public Function EventTransaction() As SIS.ADM.admITEventTransactions
		Return New SIS.ADM.admITEventTransactions
	End Function
	<WebMethod()> _
	Public Function CreateEventTransaction(ByVal Record As SIS.ADM.admITEventTransactions) As Integer
		Return SIS.ADM.admITEventTransactions.UZ_Insert(Record)
	End Function
End Class
