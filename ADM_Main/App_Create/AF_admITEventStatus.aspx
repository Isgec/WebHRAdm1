<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admITEventStatus.aspx.vb" Inherits="AF_admITEventStatus" title="Add: HRIS Event Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "EventID,ITServiceID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admITEventStatus"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITEventStatus" runat="server" Text="Add HRIS Event Status" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EventID" ForeColor="#CC6633" runat="server" Text="Event :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_EventID"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("EventID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Event."
						ValidationGroup = "admITEventStatus"
						Runat="Server" />
					<asp:Label
						ID = "F_EventID_Display"
						Text='<%# Eval("FK_ADM_ITEventStatus_ADM_ITEventTransactions.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEventID"
						runat = "server"
						ControlToValidate = "F_EventID"
						Text = "Event is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITEventStatus"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEEventID"
            BehaviorID="B_ACEEventID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EventIDCompletionList"
            TargetControlID="F_EventID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEventID_Selected"
            OnClientPopulating="ACEEventID_Populating"
            OnClientPopulated="ACEEventID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ITServiceID" ForeColor="#CC6633" runat="server" Text="Service :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ITServiceID"
						CssClass = "mypktxt"
            Width="105px"
						Text='<%# Bind("ITServiceID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for IT Service."
						ValidationGroup = "admITEventStatus"
						Runat="Server" />
					<asp:Label
						ID = "F_ITServiceID_Display"
						Text='<%# Eval("FK_ADM_ITEventStatus_ADM_ITServices.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVITServiceID"
						runat = "server"
						ControlToValidate = "F_ITServiceID"
						Text = "IT Service is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITEventStatus"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEITServiceID"
            BehaviorID="B_ACEITServiceID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ITServiceIDCompletionList"
            TargetControlID="F_ITServiceID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEITServiceID_Selected"
            OnClientPopulating="ACEITServiceID_Populating"
            OnClientPopulated="ACEITServiceID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admITEventStatus"
  InsertMethod="UZ_Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITEventStatus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
