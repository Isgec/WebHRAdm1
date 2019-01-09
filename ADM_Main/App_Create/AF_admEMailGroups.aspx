<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admEMailGroups.aspx.vb" Inherits="AF_admEMailGroups" title="Add: EMailGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "EMailGroup"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admEMailGroups"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmEMailGroups" runat="server" Text="Add EMailGroups" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EMailGroup" ForeColor="#CC6633" runat="server" Text="EMailGroup :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EMailGroup"
						Text='<%# Bind("EMailGroup") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="admEMailGroups"
            onblur= "validate_EMailGroup(this);"
            ToolTip="Enter value for EMailGroup."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEMailGroup"
						runat = "server"
						ControlToValidate = "F_EMailGroup"
						Text = "EMailGroup is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admEMailGroups"
						SetFocusOnError="true" />
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
						ValidationGroup="admEMailGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admEMailGroups"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admEMailGroups"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admEMailGroups"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
