<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admITRegisterComplaint.aspx.vb" Inherits="EF_admITRegisterComplaint" title="Edit: Register Complaints" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDExpense" runat="server" Text="&nbsp;Edit: Register Complaints"></asp:Label>
</div>
<div id="div3" class="pagedata">
    <LGM:ToolBar0 
      ID = "TBLadmITRegisterComplaint"
      ToolType = "lgNMEdit"
      ValidationGroup = "admITRegisterComplaint"
      runat = "server" />
<asp:FormView ID="FVadmITRegisterComplaint"
	runat = "server"
	DataKeyNames = "CallID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallID" runat="server" ForeColor="#CC6633" Text="Call ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CallID"
						Text='<%# Bind("CallID") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mypktxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EndUserID" runat="server" Text="End User :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_EndUserID"
            Width="56px"
						Text='<%# Bind("EndUserID") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            ToolTip="Enter value for End User."
						ValidationGroup = "admITRegisterComplaint"
            onblur= "validate_EndUserID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_EndUserID_Display"
						Text='<%# Eval("FK_ADM_ITComplaints_HRM_Employees.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEndUserID"
						runat = "server"
						ControlToValidate = "F_EndUserID"
						Text = "End User is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITRegisterComplaint"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEEndUserID"
            BehaviorID="B_ACEEndUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EndUserIDCompletionList"
            TargetControlID="F_EndUserID"
            EnableCaching="false"
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
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallTypeID" runat="server" Text="Call Type :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallTypes
            ID="F_CallTypeID"
            SelectedValue='<%# Bind("CallTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "admITRegisterComplaint"
            RequiredFieldErrorMessage = "Call Type is required."
            AutoPostBack="true"
            OnSelectedIndexChanged="reload_subtype"
            Runat="Server" />
          </td>
			</tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CallSubTypeID" runat="server" Text="Call Sub Type :" /></b>
        </td>
        <td>
          <LGM:LC_admITCallSubTypes
            ID="F_CallSubTypeID"
            SelectedValue='<%# Bind("CallSubTypeID") %>'
            DataTextField="DisplayField"
            DataValueField="CallSubTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "admITRegisterComplaint"
            RequiredFieldErrorMessage = "Call Sub Type is required."
            Runat="Server" />
          </td>
      </tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITRegisterComplaint"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="2500"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITRegisterComplaint"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_AssignedTo" runat="server" Text="Assigned To :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_AssignedTo"
            Width="56px"
						Text='<%# Bind("AssignedTo") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            ToolTip="Enter value for Assigned To."
						ValidationGroup = "admITRegisterComplaint"
            onblur= "validate_AssignedTo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_AssignedTo_Display"
						Text='<%# Eval("FK_ADM_ITComplaints_ADM_Users1.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVAssignedTo"
						runat = "server"
						ControlToValidate = "F_AssignedTo"
						Text = "Assigned To is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITRegisterComplaint"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEAssignedTo"
            BehaviorID="B_ACEAssignedTo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="AssignedToCompletionList"
            TargetControlID="F_AssignedTo"
            EnableCaching="false"
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
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallReceivedOn" runat="server" Text="Call Received On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CallReceivedOn"
						Text='<%# Bind("CallReceivedOn") %>'
            Width="140px"
						CssClass = "mytxt"
						ValidationGroup="admITRegisterComplaint"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonCallReceivedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CECallReceivedOn"
            TargetControlID="F_CallReceivedOn"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonCallReceivedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEECallReceivedOn"
						runat = "server"
						mask = "99/99/9999 99:99"
						MaskType="DateTime"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_CallReceivedOn" />
					<AJX:MaskedEditValidator 
						ID = "MEVCallReceivedOn"
						runat = "server"
						ControlToValidate = "F_CallReceivedOn"
						ControlExtender = "MEECallReceivedOn"
						InvalidValueMessage = "Invalid value for CallReceivedOn."
						EmptyValueMessage = "CallReceivedOn is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for CallReceivedOn."
						EnableClientScript = "true"
						ValidationGroup = "admITRegisterComplaint"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallConverted" runat="server" Text="Converted to SCE Request :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_CallConverted"
					  Checked='<%# Bind("CallConverted") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ConvertedReference" runat="server" Text="SCE Request No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ConvertedReference"
						Text='<%# Bind("ConvertedReference") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITRegisterComplaint"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SCE Request No."
						MaxLength="50"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ConvertedRemarks" runat="server" Text="SCE Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ConvertedRemarks"
						Text='<%# Bind("ConvertedRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITRegisterComplaint"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SCE Remarks."
						MaxLength="500"
						runat="server" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admITRegisterComplaint"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="UZ_Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITRegisterComplaint"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CallID" Name="CallID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
