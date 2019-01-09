<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admComplaintResponse.aspx.vb" Inherits="AF_admComplaintResponse" title="Add: Complaint Response" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDDriver" runat="server" Text="&nbsp;Add: Complaint Response"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLadmITRegisterComplaint" runat="server" >
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admComplaintResponse"
      InsertAndStay="false"
      runat = "server" />
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CallID,SerialNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallID" ForeColor="#CC6633" runat="server" Text="CallID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CallID"
						CssClass = "mypktxt"
            Width="70px"
						ValidationGroup = "admComplaintResponse"
					  Enabled="false"
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="SerialNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admComplaintResponse"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
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
	</InsertItemTemplate>
</asp:FormView>
</ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admComplaintResponse"
  InsertMethod="UZ_Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admComplaintResponse"
  SelectMethod = "GetNewRecord"
  runat = "server" >
<SelectParameters>
	<asp:QueryStringParameter QueryStringField="CallID" Name="CallID" Type="Int32" Size="10" DefaultValue="-1" />
</SelectParameters>
<InsertParameters>
  <asp:Parameter Name="SerialNo" Type="Int32" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
