function show_tblPCDet(o) {
	var tbl = $get('tblPCDet');
	if (o.value == 'DESKTOP' || o.value == 'LAPTOP' || o.value == 'SERVER')
		tbl.style.display = 'block';
	else
		tbl.style.display = 'none';
}

//		Dim oTblPCDet As HtmlTable = FormView1.FindControl("tblPCDet")
//		Dim oF_AssetTypeID As LC_asmAstTypes = FormView1.FindControl("F_AssetTypeID")
//		If oF_AssetTypeID.SelectedValue = "DESKTOP" Or oF_AssetTypeID.SelectedValue = "LAPTOP" Or oF_AssetTypeID.SelectedValue = "SERVER" Then
//			oTblPCDet.Visible = True
//		Else
//			oTblPCDet.Visible = False
//		End If

//Receive From Standby
//--------------------
//	Protected Sub Issue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
//		Dim oBut As ImageButton = CType(sender, ImageButton)
//		Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
//		Dim MrnID As Integer = aVal(0)
//		Dim AssetID As Integer = aVal(1)
//		'==============
//		SIS.ASM.asmAstStandbyReceive.StandbyToPermanent(MrnID, AssetID)
//		GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
//	End Sub

//        <asp:TemplateField>
//          <ItemTemplate>
//						<asp:ImageButton ID="cmdIssue" runat="server" Visible='<%# EVal("Editable") %>' AlternateText="Issue" ToolTip="Click to Issue the asset permanently." SkinID="docok" OnClick="Issue_Click" CommandArgument='<%#EVal("MrnID") & "," & EVal("AssetID")%>' OnClientClick="return confirm('Issue status will be changed to permanent from standby ?');" />
//          </ItemTemplate>
//          <HeaderStyle Width="30px" />
//        </asp:TemplateField>
