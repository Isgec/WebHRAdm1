<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admCheckPoints.aspx.vb" Inherits="EF_admCheckPoints" title="Edit: Check Points" %>
<asp:Content ID="CPHadmCheckPoints" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLadmCheckPoints" runat="server" >
<ContentTemplate>
  <LGM:ToolBar 
    ID = "TBLadmCheckPoints"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "admCheckPoints"
    runat = "server" />
  <hr />
<asp:FormView ID="FVadmCheckPoints"
	runat = "server"
	DataKeyNames = "CheckPointID"
	DataSourceID = "ODSadmCheckPoints"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <asp:Label ID="LabeladmCheckPoints" runat="server" Text="Edit Check Points" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" runat="server" ForeColor="#CC6633" Text="Check Point :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CheckPointID"
						Text='<%# Bind("CheckPointID") %>'
            ToolTip="Value of Check Point."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Descriptions" runat="server" Text="Descriptions :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Descriptions"
						Text='<%# Bind("Descriptions") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admCheckPoints"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Descriptions."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescriptions"
						runat = "server"
						ControlToValidate = "F_Descriptions"
						Text = "Descriptions is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admCheckPoints"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ScheduleID" runat="server" Text="Schedule :" /></b>
				</td>
        <td>
          <LGM:LC_admSchedules
            ID="F_ScheduleID"
            SelectedValue='<%# Bind("ScheduleID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "admCheckPoints"
            RequiredFieldErrorMessage = "Schedule is required."
            onblur= "validate_ScheduleID(this);"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_StartDate" runat="server" Text="Start Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_StartDate"
						Text='<%# Bind("StartDate") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonStartDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEStartDate"
            TargetControlID="F_StartDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonStartDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEStartDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_StartDate" />
					<AJX:MaskedEditValidator 
						ID = "MEVStartDate"
						runat = "server"
						ControlToValidate = "F_StartDate"
						ControlExtender = "MEEStartDate"
						InvalidValueMessage = "Invalid value for Start Date."
						EmptyValueMessage = "Start Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Start Date."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DayOfSchedule" runat="server" Text="Day Of Schedule :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DayOfSchedule"
						Text='<%# Bind("DayOfSchedule") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEDayOfSchedule"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_DayOfSchedule" />
					<AJX:MaskedEditValidator 
						ID = "MEVDayOfSchedule"
						runat = "server"
						ControlToValidate = "F_DayOfSchedule"
						ControlExtender = "MEEDayOfSchedule"
						InvalidValueMessage = "Invalid value for Day Of Schedule."
						EmptyValueMessage = "Day Of Schedule is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Day Of Schedule."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Floating" runat="server" Text="Floating :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_Floating"
					  Checked='<%# Bind("Floating") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Initiator" runat="server" Text="Initiator :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_Initiator"
						CssClass = "myfktxt"
						Text='<%# Bind("Initiator") %>'
						AutoCompleteType = "None"
            Width="56px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Initiator."
            onblur= "validate_Initiator(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_Initiator_Display"
						Text='<%# Eval("FK_ADM_CheckPoints_aspnet_Users.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEInitiator"
            BehaviorID="B_ACEInitiator"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="InitiatorCompletionList"
            TargetControlID="F_Initiator"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEInitiator_Selected"
            OnClientPopulating="ACEInitiator_Populating"
            OnClientPopulated="ACEInitiator_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
  ID = "ODSadmCheckPoints"
  DataObjectTypeName = "SIS.ADM.admCheckPoints"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admCheckPoints"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CheckPointID" Name="CheckPointID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
