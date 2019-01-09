<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admCheckPoints.aspx.vb" Inherits="AF_admCheckPoints" title="Add: Check Points" %>
<asp:Content ID="CPHadmCheckPoints" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLadmCheckPoints" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLadmCheckPoints"
    ToolType = "lgNMAdd"
    InsertAndStay = "True"
    ValidationGroup = "admCheckPoints"
    runat = "server" />
  <hr />
<asp:FormView ID="FVadmCheckPoints"
	runat = "server"
	DataKeyNames = "CheckPointID"
	DataSourceID = "ODSadmCheckPoints"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <asp:Label ID="LabeladmCheckPoints" runat="server" Text="Add Check Points" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsgadmCheckPoints" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" ForeColor="#CC6633" runat="server" Text="Check Point :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CheckPointID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Descriptions" runat="server" Text="Descriptions :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Descriptions"
						Text='<%# Bind("Descriptions") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admCheckPoints"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Descriptions."
						MaxLength="50"
            Width="350px"
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
            Width="70px"
						style="text-align: right"
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
            Width="56px"
						Text='<%# Bind("Initiator") %>'
						AutoCompleteType = "None"
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
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSadmCheckPoints"
  DataObjectTypeName = "SIS.ADM.admCheckPoints"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admCheckPoints"
  SelectMethod = "GetNewRecord"
  runat = "server" >
<InsertParameters>
  <asp:Parameter Name="CheckPointID" Type="Int32" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
