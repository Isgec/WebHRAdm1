<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admRegisterComplaint.aspx.vb" Inherits="EF_admRegisterComplaint" title="Edit: Register Complaints" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CallID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admRegisterComplaint"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmRegisterComplaint" runat="server" Text="Edit Register Complaints" CssClass="sis_formheading"></asp:Label>
    <hr />
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
						ValidationGroup = "admRegisterComplaint"
            onblur= "validate_EndUserID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_EndUserID_Display"
						Text='<%# Eval("FK_ADM_Complaints_HRM_Employees.DisplayField") %>'
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admRegisterComplaint"
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
            Width="56px"
						Text='<%# Bind("AssignedTo") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            ToolTip="Enter value for Assigned To."
						ValidationGroup = "admRegisterComplaint"
            onblur= "validate_AssignedTo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_AssignedTo_Display"
						Text='<%# Eval("FK_ADM_Complaints_ADM_Users1.DisplayField") %>'
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
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admRegisterComplaint"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="UZ_Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admRegisterComplaint"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CallID" Name="CallID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
