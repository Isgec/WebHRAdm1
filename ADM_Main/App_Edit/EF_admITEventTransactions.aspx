<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admITEventTransactions.aspx.vb" Inherits="EF_admITEventTransactions" title="Edit: HRIS Event Transactions" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "EventID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admITEventTransactions"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITEventTransactions" runat="server" Text="Edit HRIS Event Transactions" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EventID" runat="server" ForeColor="#CC6633" Text="Event ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EventID"
						Text='<%# Bind("EventID") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mypktxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EventDate" runat="server" Text="Event Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EventDate"
						Text='<%# Bind("EventDate") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="admITEventTransactions"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonEventDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEEventDate"
            TargetControlID="F_EventDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonEventDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEEventDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_EventDate" />
					<AJX:MaskedEditValidator 
						ID = "MEVEventDate"
						runat = "server"
						ControlToValidate = "F_EventDate"
						ControlExtender = "MEEEventDate"
						InvalidValueMessage = "Invalid value for Event Date."
						EmptyValueMessage = "Event Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Event Date."
						EnableClientScript = "true"
						ValidationGroup = "admITEventTransactions"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CardNo" runat="server" Text="Generated For :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CardNo"
            Width="56px"
						Text='<%# Bind("CardNo") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            ToolTip="Enter value for Generated For."
						ValidationGroup = "admITEventTransactions"
            onblur= "validate_CardNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_CardNo_Display"
						Text='<%# Eval("FK_ADM_ITEventTransactions_HRM_Employees.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCardNo"
						runat = "server"
						ControlToValidate = "F_CardNo"
						Text = "Generated For is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITEventTransactions"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECardNo_Selected"
            OnClientPopulating="ACECardNo_Populating"
            OnClientPopulated="ACECardNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
						ValidationGroup="admITEventTransactions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITEventTransactions"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright" style="font-weight: bold">
					<b>
					<asp:Label ID="L_Description0" runat="server" Text="Paste Circular:" />
					</b>
				</td>
				<td>
					<CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Height="200" >
					</CKEditor:CKEditorControl>
				</td>
				</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admITEventTransactions"
  SelectMethod = "GetByID"
  UpdateMethod="UZ_Update"
  DeleteMethod="UZ_Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITEventTransactions"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="EventID" Name="EventID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
