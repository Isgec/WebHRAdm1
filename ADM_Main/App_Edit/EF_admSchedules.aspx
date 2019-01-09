<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admSchedules.aspx.vb" Inherits="EF_admSchedules" title="Edit: Schedules" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ScheduleID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admSchedules"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmSchedules" runat="server" Text="Edit Schedules" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ScheduleID" runat="server" ForeColor="#CC6633" Text="Schedule :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ScheduleID"
						Text='<%# Bind("ScheduleID") %>'
            Width="140px"
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
            Width="140px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admSchedules"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="20"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admSchedules"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FixDate" runat="server" Text="FixDate :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_FixDate"
						  Checked='<%# Bind("FixDate") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DaysOrDate" runat="server" Text="DaysOrDate :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DaysOrDate"
						Text='<%# Bind("DaysOrDate") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="admSchedules"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEDaysOrDate"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_DaysOrDate" />
					<AJX:MaskedEditValidator 
						ID = "MEVDaysOrDate"
						runat = "server"
						ControlToValidate = "F_DaysOrDate"
						ControlExtender = "MEEDaysOrDate"
						InvalidValueMessage = "Invalid value for DaysOrDate."
						EmptyValueMessage = "DaysOrDate is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for DaysOrDate."
						EnableClientScript = "true"
						ValidationGroup = "admSchedules"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "DaysOrDate should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IncludeHolidays" runat="server" Text="IncludeHolidays :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_IncludeHolidays"
						  Checked='<%# Bind("IncludeHolidays") %>'
              runat="server" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admSchedules"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admSchedules"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ScheduleID" Name="ScheduleID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
