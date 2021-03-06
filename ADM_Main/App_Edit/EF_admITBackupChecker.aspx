<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admITBackupChecker.aspx.vb" Inherits="EF_admITBackupChecker" title="Edit: Backup Checker" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate>
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "BackupID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admITBackupChecker"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITBackupChecker" runat="server" Text="Edit Backup Checker" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BackupID" runat="server" ForeColor="#CC6633" Text="ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BackupID"
						Text='<%# Bind("BackupID") %>'
            ToolTip="Value of ID."
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
						ValidationGroup="admITBackupChecker"
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
						ValidationGroup = "admITBackupChecker"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SourcePath" runat="server" Text="Source Path :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SourcePath"
						Text='<%# Bind("SourcePath") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITBackupChecker"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Source Path."
						MaxLength="250"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSourcePath"
						runat = "server"
						ControlToValidate = "F_SourcePath"
						Text = "Source Path is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITBackupChecker"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TargetPath" runat="server" Text="Target Path :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TargetPath"
						Text='<%# Bind("TargetPath") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITBackupChecker"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Target Path."
						MaxLength="250"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTargetPath"
						runat = "server"
						ControlToValidate = "F_TargetPath"
						Text = "Target Path is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITBackupChecker"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_USBPath" runat="server" Text="USB Path :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_USBPath"
						Text='<%# Bind("USBPath") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITBackupChecker"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for USB Path."
						MaxLength="250"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVUSBPath"
						runat = "server"
						ControlToValidate = "F_USBPath"
						Text = "USB Path is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITBackupChecker"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SourceDrive" runat="server" Text="Source Drive :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SourceDrive"
						Text='<%# Bind("SourceDrive") %>'
            Width="7px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITBackupChecker"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Source Drive."
						MaxLength="1"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSourceDrive"
						runat = "server"
						ControlToValidate = "F_SourceDrive"
						Text = "Source Drive is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITBackupChecker"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TargetDrive" runat="server" Text="Target Drive :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TargetDrive"
						Text='<%# Bind("TargetDrive") %>'
            Width="7px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITBackupChecker"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Target Drive."
						MaxLength="1"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTargetDrive"
						runat = "server"
						ControlToValidate = "F_TargetDrive"
						Text = "Target Drive is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITBackupChecker"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_USBDrive" runat="server" Text="USB Drive :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_USBDrive"
						Text='<%# Bind("USBDrive") %>'
            Width="7px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admITBackupChecker"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for USB Drive."
						MaxLength="1"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVUSBDrive"
						runat = "server"
						ControlToValidate = "F_USBDrive"
						Text = "USB Drive is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admITBackupChecker"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" runat="server" Text="Check Point :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CheckPointID"
						Text='<%# Bind("CheckPointID") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="admITBackupChecker"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEECheckPointID"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_CheckPointID" />
					<AJX:MaskedEditValidator 
						ID = "MEVCheckPointID"
						runat = "server"
						ControlToValidate = "F_CheckPointID"
						ControlExtender = "MEECheckPointID"
						InvalidValueMessage = "Invalid value for Check Point."
						EmptyValueMessage = "Check Point is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Check Point."
						EnableClientScript = "true"
						ValidationGroup = "admITBackupChecker"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Check Point should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Active" runat="server" Text="Active :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_Active"
					  Checked='<%# Bind("Active") %>'
            runat="server" />
				</td>
			</tr>
		</table>
		<table>
		</table>
	</EditItemTemplate>
</asp:FormView>
</ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admITBackupChecker"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITBackupChecker"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BackupID" Name="BackupID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
