<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admComplaintResponse.aspx.vb" Inherits="EF_admComplaintResponse" title="Edit: Complaint Response" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CallID,SerialNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admComplaintResponse"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmComplaintResponse" runat="server" Text="Edit Complaint Response" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallID" runat="server" ForeColor="#CC6633" Text="CallID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CallID"
            Width="70px"
						Text='<%# Bind("CallID") %>'
						AutoCompleteType = "None"
						CssClass = "mypktxt"
            Enabled = "False"
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="SerialNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mypktxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admComplaintResponse"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
						MaxLength="250"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRemarks"
						runat = "server"
						ControlToValidate = "F_Remarks"
						Text = "Remarks is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admComplaintResponse"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admComplaintResponse"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admComplaintResponse"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CallID" Name="CallID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
