<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admITCallSubTypes.aspx.vb" Inherits="AF_admITCallSubTypes" title="Add: Sub Call Types" %>
<asp:Content ID="CPHadmITCallSubTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDDriver" runat="server" Text="&nbsp;Add: Sub Call Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLadmITCallSubTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLadmITCallSubTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "admITCallSubTypes"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVadmITCallSubTypes"
	runat = "server"
	DataKeyNames = "CallTypeID,CallSubTypeID"
	DataSourceID = "ODSadmITCallSubTypes"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <asp:Label ID="L_ErrMsgadmITCallSubTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallTypeID" ForeColor="#CC6633" runat="server" Text="Call Type :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallTypes
            ID="F_CallTypeID"
            SelectedValue='<%# Bind("CallTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "admITCallSubTypes"
            RequiredFieldErrorMessage = "Call Type is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallSubTypeID" ForeColor="#CC6633" runat="server" Text="Call Sub Type :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CallSubTypeID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="admITCallSubTypes"
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
						ValidationGroup = "admITCallSubTypes"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSadmITCallSubTypes"
  DataObjectTypeName = "SIS.ADM.admITCallSubTypes"
  InsertMethod="UZ_admITCallSubTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITCallSubTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
