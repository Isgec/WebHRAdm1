<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admSchedules.aspx.vb" Inherits="AF_admSchedules" title="Add: Schedules" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ScheduleID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admSchedules"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmSchedules" runat="server" Text="Add Schedules" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ScheduleID" ForeColor="#CC6633" runat="server" Text="Schedule :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ScheduleID"
						Text='<%# Bind("ScheduleID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="admSchedules"
            onblur= "validate_ScheduleID(this);"
            ToolTip="Enter value for Schedule."
						MaxLength="20"
            Width="140px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVScheduleID"
						runat = "server"
						ControlToValidate = "F_ScheduleID"
						Text = "Schedule is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admSchedules"
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
						ValidationGroup="admSchedules"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="20"
            Width="140px"
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
            Width="70px"
						style="text-align: right"
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
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admSchedules"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admSchedules"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
