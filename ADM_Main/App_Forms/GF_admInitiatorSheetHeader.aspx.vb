Partial Class GF_admInitiatorSheetHeader
  Inherits System.Web.UI.Page
  Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admInitiatorSheetHeader.aspx"
  Private _AddUrl As String = "~/ADM_Main/App_Create/AF_admInitiatorSheetHeader.aspx"
  Private _InfoUrl As String = "~/ADM_Main/App_Display/DF_admInitiatorSheetHeader.aspx"
  Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _EditUrl  & "?SheetID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SheetID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), GridView1.PageIndex)
    Else
      Session("PageNo_" & FileName) = GridView1.PageIndex
    End If
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ToolBar0_1.AddUrl = _AddUrl
    ToolBar0_1.EditUrl = _EditUrl
    ToolBar0_1.SearchUrl = _EditUrl
  End Sub
	Protected Sub ToolBar0_1_CancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ToolBar0_1.CancelClicked
		Response.Redirect(Session("ApplicationDefaultPage"))
	End Sub
  Protected Sub ToolBar0_1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles ToolBar0_1.PageChanged
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    GridView1.PageIndex = NewPageNo
    GridView1.PageSize = PageSize
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
    Else
      Session("PageNo_" & FileName) = NewPageNo
    End If
    If Session("PageSizeProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"), PageSize)
    Else
      Session("PageSize_" & FileName) = PageSize
    End If
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    Try
      If Session("PageNoProvider") = True Then
        GridView1.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
      Else
        GridView1.PageIndex = Session("PageNo_" & FileName)
      End If
      If Session("PageSizeProvider") = True Then
        GridView1.PageSize = SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"))
      Else
        GridView1.PageSize = Session("PageSize_" & FileName)
      End If
    Catch ex As Exception
      GridView1.PageIndex = 0
      GridView1.PageSize = 10
    End Try
  End Sub
  Protected Sub F_ServiceID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ServiceID.SelectedIndexChanged
    Session("F_ServiceID") = F_ServiceID.SelectedValue
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
  Protected Sub F_ScheduleID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ScheduleID.SelectedIndexChanged
    Session("F_ScheduleID") = F_ScheduleID.SelectedValue
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ServiceID.SelectedValue = String.Empty
    If Not Session("F_ServiceID") Is Nothing Then
      If Session("F_ServiceID") <> String.Empty Then
        F_ServiceID.SelectedValue = Session("F_ServiceID")
      End If
    End If
    F_ScheduleID.SelectedValue = String.Empty
    If Not Session("F_ScheduleID") Is Nothing Then
      If Session("F_ScheduleID") <> String.Empty Then
        F_ScheduleID.SelectedValue = Session("F_ScheduleID")
      End If
    End If
  End Sub
  Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
    With ToolBar0_1
      .CurrentPage = GridView1.PageIndex
      .TotalPages = GridView1.PageCount
      .RecordsPerPage = GridView1.PageSize
    End With
  End Sub
	Protected Sub ToolBar0_1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles ToolBar0_1.SearchClicked
		GridView1.PageIndex = 0
		ObjectDataSource1.SelectParameters("SearchState").DefaultValue = SearchState
		ObjectDataSource1.SelectParameters("SearchText").DefaultValue = SearchText
	End Sub
	Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
		If e.CommandName.ToLower = "ValidateBackup".ToLower Then
			Dim SheetID As Integer = e.CommandArgument
			Dim oSht As SIS.ADM.admInitiatorSheetHeader = SIS.ADM.admInitiatorSheetHeader.GetByID(SheetID)
			Dim DOW As String = Convert.ToDateTime(oSht.SheetDate).ToString("dddd").Substring(0, 3)
			Dim oShtDets As List(Of SIS.ADM.admInitiatorSheetDetails) = SIS.ADM.admInitiatorSheetDetails.GetBySheetID(SheetID, "")
			If oShtDets.Count < 1 Then Exit Sub
			Dim oBC As List(Of SIS.ADM.admITBackupChecker) = SIS.ADM.admITBackupChecker.SelectList(0, 999, "", False, "")
			For Each bc As SIS.ADM.admITBackupChecker In oBC
				Dim tStr As String = bc.Description
				If Not bc.Active Then Continue For
				Dim oFldr As IO.DirectoryInfo = Nothing
				Dim sFiles() As IO.FileInfo = Nothing
				Dim Err As Boolean = False
				Try
					oFldr = New IO.DirectoryInfo(bc.SourcePath.ToLower.Replace("@dow", DOW))
				Catch ex As Exception
					tStr &= "|Err S-Path"
					Err = True
				End Try
				If Not Err Then
					Try
						sFiles = oFldr.GetFiles()
					Catch ex As Exception
						tStr &= "|Err S-File"
						Err = True
					End Try
				End If
				If Not Err Then
					Try
						Dim fCnt As Integer = 0
						Dim fSiz As Decimal = 0
						For Each fli As IO.FileInfo In sFiles
							If fli.LastWriteTime.ToString("dd/MM/yyyy") = oSht.SheetDate Then
								fCnt += 1
								fSiz += (fli.Length / (1024 * 1024))
							End If
						Next
						tStr &= "|S-Files:" & fCnt & ", Size:" & fSiz
					Catch ex As Exception
						tStr &= "|Err S-Internal"
						Err = True
					End Try
				End If

				Err = False
				Try
					oFldr = New IO.DirectoryInfo(bc.TargetPath.ToLower.Replace("@dow", DOW))
				Catch ex As Exception
					tStr &= "|Err T-Path"
					Err = True
				End Try
				If Not Err Then
					Try
						sFiles = oFldr.GetFiles()
					Catch ex As Exception
						tStr &= "|Err T-File"
						Err = True
					End Try
				End If
				If Not Err Then
					Try
						Dim fCnt As Integer = 0
						Dim fSiz As Decimal = 0
						For Each fli As IO.FileInfo In sFiles
							If fli.LastWriteTime.ToString("dd/MM/yyyy") = oSht.SheetDate Then
								fCnt += 1
								fSiz += (fli.Length / (1024 * 1024))
							End If
						Next
						tStr &= "|T-Files:" & fCnt & ", Size:" & fSiz
					Catch ex As Exception
						tStr &= "|Err T-Internal"
						Err = True
					End Try
				End If


				'Update Sheet
				For Each det As SIS.ADM.admInitiatorSheetDetails In oShtDets
					If det.CheckPointID = bc.CheckPointID Then
						det.ProblemIdentified = Err
						det.InitiatorRemarks = tStr
						SIS.ADM.admInitiatorSheetDetails.UZ_Update(det)
						Exit For
					End If
				Next
			Next

		End If

	End Sub
End Class
