<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admQualifications.aspx.vb" Inherits="AF_admQualifications" title="Add: Qualifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "QualificationID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admQualifications"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmQualifications" runat="server" Text="Add Qualifications" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_QualificationID" ForeColor="#CC6633" runat="server" Text="QualificationID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_QualificationID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="admQualifications"
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
						ValidationGroup = "admQualifications"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admQualifications"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admQualifications"
  SelectMethod = "GetNewRecord"
  runat = "server" >
<InsertParameters>
  <asp:Parameter Name="QualificationID" Type="Int32" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
