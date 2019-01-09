<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admRegisterComplaint.aspx.vb" Inherits="AF_admRegisterComplaint" title="Add: Register Complaints" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CallID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admRegisterComplaint"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmRegisterComplaint" runat="server" Text="Add Register Complaints" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallID" ForeColor="#CC6633" runat="server" Text="Call ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CallID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
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
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for End User."
						ValidationGroup = "admRegisterComplaint"
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
						ValidationGroup = "admRegisterComplaint"
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
          <LGM:LC_admCallTypes
            ID="F_CallTypeID"
            SelectedValue='<%# Bind("CallTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "admRegisterComplaint"
            RequiredFieldErrorMessage = "Call Type is required."
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admRegisterComplaint"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="2500"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admRegisterComplaint"
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
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("AssignedTo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Assigned To."
						ValidationGroup = "admRegisterComplaint"
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
						ValidationGroup = "admRegisterComplaint"
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
					<b><asp:Label ID="L_SendMail" runat="server" Text="Send Mail :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_SendMail"
						  Checked='<%# Bind("SendMail") %>'
              runat="server" />
				</td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admRegisterComplaint"
  InsertMethod="UZ_Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admRegisterComplaint"
  SelectMethod = "GetNewRecord"
  runat = "server" >
<InsertParameters>
  <asp:Parameter Name="CallID" Type="Int32" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
