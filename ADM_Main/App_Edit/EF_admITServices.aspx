<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admITServices.aspx.vb" Inherits="EF_admITServices" title="Edit: IT Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ITServiceID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admITServices"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITServices" runat="server" Text="Edit IT Services" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ITServiceID" runat="server" ForeColor="#CC6633" Text="IT Service ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ITServiceID"
						Text='<%# Bind("ITServiceID") %>'
            Width="105px"
						CssClass = "mypktxt"
            Enabled = "False"
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
						ValidationGroup="admITServices"
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
						ValidationGroup = "admITServices"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_AlertAfterDays" runat="server" Text="Alert After Days :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_AlertAfterDays"
						Text='<%# Bind("AlertAfterDays") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="admITServices"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEAlertAfterDays"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_AlertAfterDays" />
					<AJX:MaskedEditValidator 
						ID = "MEVAlertAfterDays"
						runat = "server"
						ControlToValidate = "F_AlertAfterDays"
						ControlExtender = "MEEAlertAfterDays"
						InvalidValueMessage = "Invalid value for Alert After Days."
						EmptyValueMessage = "Alert After Days is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Alert After Days."
						EnableClientScript = "true"
						ValidationGroup = "admITServices"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Alert After Days should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EMailGroup" runat="server" Text="E-Mail Group :" /></b>
				</td>
        <td>
          <LGM:LC_admEMailGroups
            ID="F_EMailGroup"
            SelectedValue='<%# Bind("EMailGroup") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "admITServices"
            RequiredFieldErrorMessage = "E-Mail Group is required."
            Runat="Server" />
          </td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admITServices"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITServices"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ITServiceID" Name="ITServiceID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
