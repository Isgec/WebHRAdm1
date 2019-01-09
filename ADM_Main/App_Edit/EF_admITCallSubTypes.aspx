<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admITCallSubTypes.aspx.vb" Inherits="EF_admITCallSubTypes" title="Edit: Sub Call Types" %>
<asp:Content ID="CPHadmITCallSubTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDExpense" runat="server" Text="&nbsp;Edit: Sub Call Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLadmITCallSubTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLadmITCallSubTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "admITCallSubTypes"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVadmITCallSubTypes"
	runat = "server"
	DataKeyNames = "CallTypeID,CallSubTypeID"
	DataSourceID = "ODSadmITCallSubTypes"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallTypeID" runat="server" ForeColor="#CC6633" Text="Call Type :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CallTypeID"
            Width="140px"
						Text='<%# Bind("CallTypeID") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Call Type."
						Runat="Server" />
					<asp:Label
						ID = "F_CallTypeID_Display"
						Text='<%# Eval("ADM_ITCallTypes1_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallSubTypeID" runat="server" ForeColor="#CC6633" Text="Call Sub Type :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CallSubTypeID"
						Text='<%# Bind("CallSubTypeID") %>'
            ToolTip="Value of Call Sub Type."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITCallSubTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITCallSubTypes"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSadmITCallSubTypes"
  DataObjectTypeName = "SIS.ADM.admITCallSubTypes"
  SelectMethod = "admITCallSubTypesGetByID"
  UpdateMethod="UZ_admITCallSubTypesUpdate"
  DeleteMethod="UZ_admITCallSubTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITCallSubTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CallTypeID" Name="CallTypeID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CallSubTypeID" Name="CallSubTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
