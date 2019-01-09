<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admMonitors.aspx.vb" Inherits="EF_admMonitors" title="Edit: Monitors" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ServiceID,MonitorID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admMonitors"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmMonitors" runat="server" Text="Edit Monitors" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ServiceID" runat="server" ForeColor="#CC6633" Text="Service :" /></b>
				</td>
        <td>
          <LGM:LC_admServices
            ID="F_ServiceID"
            SelectedValue='<%# Bind("ServiceID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Enabled = "False"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MonitorID" runat="server" ForeColor="#CC6633" Text="Monitor :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_MonitorID"
            Width="56px"
						Text='<%# Bind("MonitorID") %>'
						AutoCompleteType = "None"
						CssClass = "mypktxt"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_MonitorID_Display"
						Text='<%# Eval("FK_ADM_Monitors_HRM_Employees.DisplayField") %>'
						Runat="Server" />
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admMonitors"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admMonitors"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ServiceID" Name="ServiceID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MonitorID" Name="MonitorID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
