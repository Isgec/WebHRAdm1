<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admServiceCheckPoints.aspx.vb" Inherits="EF_admServiceCheckPoints" title="Edit: Service Check Points" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ServiceID,CheckPointID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admServiceCheckPoints"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmServiceCheckPoints" runat="server" Text="Edit Service Check Points" CssClass="sis_formheading"></asp:Label>
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
            Width="300px"
            CssClass="myddl"
            Enabled = "False"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" runat="server" ForeColor="#CC6633" Text="Check Point :" /></b>
				</td>
        <td>
          <LGM:LC_admCheckPoints
            ID="F_CheckPointID"
            SelectedValue='<%# Bind("CheckPointID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="500px"
            CssClass="myddl"
            Enabled = "False"
            Runat="Server" />
          </td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admServiceCheckPoints"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admServiceCheckPoints"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ServiceID" Name="ServiceID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CheckPointID" Name="CheckPointID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
