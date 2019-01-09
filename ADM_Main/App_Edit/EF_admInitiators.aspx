<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admInitiators.aspx.vb" Inherits="EF_admInitiators" title="Edit: Initiators" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ServiceID,InitiatorID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admInitiators"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmInitiators" runat="server" Text="Edit Initiators" CssClass="sis_formheading"></asp:Label>
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
					<b><asp:Label ID="L_InitiatorID" runat="server" ForeColor="#CC6633" Text="Initiator :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_InitiatorID"
            Width="56px"
						Text='<%# Bind("InitiatorID") %>'
						AutoCompleteType = "None"
						CssClass = "mypktxt"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_InitiatorID_Display"
						Text='<%# Eval("FK_ADM_Initiators_HRM_Employees.DisplayField") %>'
						Runat="Server" />
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admInitiators"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admInitiators"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ServiceID" Name="ServiceID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="InitiatorID" Name="InitiatorID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
