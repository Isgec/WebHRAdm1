<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admCallStatus.aspx.vb" Inherits="AF_admCallStatus" title="Add: Call Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CallStatusID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admCallStatus"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmCallStatus" runat="server" Text="Add Call Status" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallStatusID" ForeColor="#CC6633" runat="server" Text="Call Status :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CallStatusID"
						Text='<%# Bind("CallStatusID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="admCallStatus"
            onblur= "validate_CallStatusID(this);"
            ToolTip="Enter value for Call Status."
						MaxLength="20"
            Width="140px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCallStatusID"
						runat = "server"
						ControlToValidate = "F_CallStatusID"
						Text = "Call Status is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admCallStatus"
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
						ValidationGroup="admCallStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admCallStatus"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admCallStatus"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admCallStatus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
