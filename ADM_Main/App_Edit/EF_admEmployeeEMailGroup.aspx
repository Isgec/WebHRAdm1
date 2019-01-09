<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admEmployeeEMailGroup.aspx.vb" Inherits="EF_admEmployeeEMailGroup" title="Edit: Employee EMail Group" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CardNo,EMailGroup"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admEmployeeEMailGroup"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmEmployeeEMailGroup" runat="server" Text="Edit Employee EMail Group" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="CardNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CardNo"
            Width="56px"
						Text='<%# Bind("CardNo") %>'
						AutoCompleteType = "None"
						CssClass = "mypktxt"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_CardNo_Display"
						Text='<%# Eval("FK_HRM_EmployeeEMailGroup_HRM_Employees.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EMailGroup" runat="server" ForeColor="#CC6633" Text="EMailGroup :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_EMailGroup"
            Width="350px"
						Text='<%# Bind("EMailGroup") %>'
						AutoCompleteType = "None"
						CssClass = "mypktxt"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_EMailGroup_Display"
						Text='<%# Eval("FK_HRM_EmployeeEMailGroup_HRM_EMailGroups.DisplayField") %>'
						Runat="Server" />
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admEmployeeEMailGroup"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admEmployeeEMailGroup"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="EMailGroup" Name="EMailGroup" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
