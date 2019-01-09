<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admServiceCheckPoints.aspx.vb" Inherits="AF_admServiceCheckPoints" title="Add: Service Check Points" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ServiceID,CheckPointID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admServiceCheckPoints"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmServiceCheckPoints" runat="server" Text="Add Service Check Points" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ServiceID" ForeColor="#CC6633" runat="server" Text="Service :" /></b>
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
						ValidationGroup = "admServiceCheckPoints"
            RequiredFieldErrorMessage = "Service is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" ForeColor="#CC6633" runat="server" Text="Check Point :" /></b>
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
						ValidationGroup = "admServiceCheckPoints"
            RequiredFieldErrorMessage = "Check Point is required."
            Runat="Server" />
          </td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admServiceCheckPoints"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admServiceCheckPoints"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
