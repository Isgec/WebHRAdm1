<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admCreateSheet.aspx.vb" Inherits="GF_admCreateSheet" title="Create Sheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <hr />
    <asp:Label ID="LabeladmServices" runat="server" Text="Create Sheet" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <table>
			<tr>
				<td colspan="3">
					<asp:Label ID="errMsg" runat="server" Visible="false" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="L_ForDate" runat="server" Text="For Date: " style="font-weight:bold" ></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="F_ForDate"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="admCmdCreate"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonForDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEForDate"
            TargetControlID="F_ForDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonForDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEForDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ForDate" />
					<AJX:MaskedEditValidator 
						ID = "MEVForDate"
						runat = "server"
						ControlToValidate = "F_ForDate"
						ControlExtender = "MEEForDate"
						InvalidValueMessage = "Invalid Date."
						EmptyValueMessage = "Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter Date."
						EnableClientScript = "true"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
					
				</td>
				<td>
					<asp:Button ID="cmdCreate" runat="server" Text="Create" ValidationGroup="admCmdCreate" />
				</td>
			</tr>
    </table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="cmdCreate" EventName="Click" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
