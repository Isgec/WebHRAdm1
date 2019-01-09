<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admITRegisterComplaint.aspx.vb" Inherits="GF_admITRegisterComplaint" title="Complaints" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;List: Register / Attend Complaints"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLadmITRegisterComplaint"
      ToolType = "lgNMGrid"
      EditUrl = "~/ADM_Main/App_Edit/EF_admITRegisterComplaint.aspx"
      AddUrl = "~/ADM_Main/App_Create/AF_admITRegisterComplaint.aspx"
      ValidationGroup = "admITRegisterComplaint"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
		<script type="text/javascript">
			var cnt = 0;
			function print_Report(o) {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=complaintregister';
				url = url + '&enduserid=' + $get('<%=F_EndUserID.ClientID %>').value;
				url = url + '&assignedto=' + $get('<%=F_AssignedTo.ClientID %>').value;
				url = url + '&calltypeid=' + $get('<%=F_CallTypeID.LCClientID %>').value;
				url = url + '&callstatusid=' + $get('<%=F_CallStatusID.LCClientID %>').value;
				window.open(url, nam, 'left=20,top=20,width=750,height=700,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; padding-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EndUserID" runat="server" Text="End User :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_EndUserID"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("EndUserID") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_EndUserID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_EndUserID_Display"
						Text='<%# Eval("EndUserIDHRM_Employees.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEndUserID"
            BehaviorID="B_ACEEndUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EndUserIDCompletionList"
            TargetControlID="F_EndUserID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEndUserID_Selected"
            OnClientPopulating="ACEEndUserID_Populating"
            OnClientPopulated="ACEEndUserID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td><asp:ImageButton ID="cmdPrint" runat="server" OnClientClick="return print_Report(this);" AlternateText="Print" SkinID="print0" /> </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_AssignedTo" runat="server" Text="Assigned To :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_AssignedTo"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("AssignedTo") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_AssignedTo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_AssignedTo_Display"
						Text='<%# Eval("AssignedToaspnet_users.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEAssignedTo"
            BehaviorID="B_ACEAssignedTo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="AssignedToCompletionList"
            TargetControlID="F_AssignedTo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEAssignedTo_Selected"
            OnClientPopulating="ACEAssignedTo_Populating"
            OnClientPopulated="ACEAssignedTo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td></td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallTypeID" runat="server" Text="Call Type :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallTypes
            ID="F_CallTypeID"
            SelectedValue='<%# Bind("CallTypeID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CallTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td></td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallStatusID" runat="server" Text="Call Status :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallStatus
            ID="F_CallStatusID"
            SelectedValue='NOT Closed'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CallStatusID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td></td>
			</tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVadmITRegisterComplaint" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="CallID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<table>
							<tr>
								<td>
									<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgedit" CommandArgument='<%#EVal("CallID")%>' />
								</td>
								<td>
									<asp:ImageButton ID="Atnd" runat="server" Enabled='<%#EVal("Visible") %>' AlternateText="Atnd" ToolTip="Click to Attend Call." ImageUrl="~/App_Themes/Default/Images/BillOK.png" CommandName="lgatnd" CommandArgument='<%#EVal("CallID")%>' />
								</td>
								<td>
									<asp:ImageButton ID="Dets" runat="server" AlternateText="Dets" ToolTip="Click to View Attender Details." SkinID="info" CommandName="lgdetl" CommandArgument='<%#EVal("CallID")%>' />
								</td>
								<td>
								</td>
							</tr>
						</table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Call ID" SortExpression="CallID">
          <ItemTemplate>
            <asp:Label ID="LabelCallID" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("CallID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Emp ID" SortExpression="EndUserID">
          <ItemTemplate>
             <asp:Label ID="L_EndUserID" ToolTip='<%#EVal("FK_ADM_ITComplaints_HRM_Employees.DisplayField") %>' ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("EndUserID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="End User" SortExpression="HRM_Employees5_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="LL_EndUserID" ToolTip='<%#EVal("EndUserID") %>' ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("FK_ADM_ITComplaints_HRM_Employees.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Call Type" SortExpression="ADM_ITCallTypes2_Description">
          <ItemTemplate>
             <asp:Label ID="L_CallTypeID" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("FK_ADM_ITComplaints_ADM_ITCallTypes.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Call Sub Type" SortExpression="ADM_ITCallSubTypes6_Description">
          <ItemTemplate>
             <asp:Label ID="L_CallSubTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CallSubTypeID") %>' Text='<%# Eval("ADM_ITCallSubTypes6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="300px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Assigned To" SortExpression="aspnet_users4_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_AssignedTo" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("FK_ADM_ITComplaints_ADM_Users1.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Logged On" SortExpression="LoggedOn">
          <ItemTemplate>
            <asp:Label ID="LabelLoggedOn" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("LoggedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Logged By" SortExpression="aspnet_users3_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_LoggedBy" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("FK_ADM_ITComplaints_ADM_Users.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="First Attended" SortExpression="FirstAttendedOn">
          <ItemTemplate>
            <asp:Label ID="LabelFirstAttended" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("FirstAttendedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Closed" SortExpression="ClosedOn">
          <ItemTemplate>
            <asp:Label ID="LabelClosed" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("ClosedOn") %>'></asp:Label>
            <asp:Button ID="cmdClosed" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text="Close" CssClass="mytxt" Enabled='<%#EVal("Enabled") %>' Visible='<%#EVal("Visible") %>' CommandName="lgClose" CommandArgument='<%#EVal("CallID")%>' OnClientClick="return confirm('Close the call ?');" />
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
      <RowStyle BackColor="PaleGoldenrod" />
      <PagerStyle BackColor="DarkGoldenrod" Font-Bold="True" HorizontalAlign="Center" />
      <HeaderStyle BackColor="DarkGoldenrod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" />
      <AlternatingRowStyle BackColor="Bisque" />
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ADM.admITRegisterComplaint"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admITRegisterComplaint"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_EndUserID" PropertyName="Text" Name="EndUserID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_CallTypeID" PropertyName="SelectedValue" Name="CallTypeID" Type="String" Size="20" />
        <asp:ControlParameter ControlID="F_AssignedTo" PropertyName="Text" Name="AssignedTo" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_CallStatusID" PropertyName="SelectedValue" Name="CallStatusID" Type="String" Size="20" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVadmITRegisterComplaint" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_EndUserID" />
    <asp:AsyncPostBackTrigger ControlID="F_CallTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_AssignedTo" />
    <asp:AsyncPostBackTrigger ControlID="F_CallStatusID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
