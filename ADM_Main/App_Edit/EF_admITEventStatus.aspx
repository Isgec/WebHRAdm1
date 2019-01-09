<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admITEventStatus.aspx.vb" Inherits="EF_admITEventStatus" title="Edit: HRIS Event Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "EventID,ITServiceID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admITEventStatus"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITEventStatus" runat="server" Text="Edit HRIS Event Status" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EventID" runat="server" ForeColor="#CC6633" Text="Event :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_EventID"
            Width="70px"
						Text='<%# Bind("EventID") %>'
						AutoCompleteType = "None"
						CssClass = "mypktxt"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_EventID_Display"
						Text='<%# Eval("FK_ADM_ITEventStatus_ADM_ITEventTransactions.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ITServiceID" runat="server" ForeColor="#CC6633" Text="Service :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ITServiceID"
            Width="105px"
						Text='<%# Bind("ITServiceID") %>'
						AutoCompleteType = "None"
						CssClass = "mypktxt"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_ITServiceID_Display"
						Text='<%# Eval("FK_ADM_ITEventStatus_ADM_ITServices.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ActionNotRequired" runat="server" Text="Action Not Required :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_ActionNotRequired"
						  Checked='<%# Bind("ActionNotRequired") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ActionTaken" runat="server" Text="Action Taken :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_ActionTaken"
						  Checked='<%# Bind("ActionTaken") %>'
              runat="server" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admITEventStatus"
  SelectMethod = "GetByID"
  UpdateMethod="UZ_Update"
  DeleteMethod="UZ_Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITEventStatus"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="EventID" Name="EventID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ITServiceID" Name="ITServiceID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
