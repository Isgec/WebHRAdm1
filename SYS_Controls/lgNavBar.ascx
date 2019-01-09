<%@ Control Language="VB" AutoEventWireup="false" CodeFile="lgNavBar.ascx.vb" Inherits="lgNavBar" %>
<table class="g_tbl" >
	<tr>
		<td style="width: 30px">
			<asp:Label ID="Label1" runat="server" Font-Size="9px" Text="Page:"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="g_cPage" runat="server" Width="40px" Font-Size="9px" Style="text-align: right" CssClass="mytxt" AutoPostBack="true"></asp:TextBox>
			<AJX:MaskedEditExtender ID="MEEg_cPage" runat="server" Mask="99999" AcceptNegative="None" MaskType="Number" MessageValidatorTip="false" ErrorTooltipEnabled="false" TargetControlID="g_cPage" PromptCharacter="" />
			<AJX:MaskedEditValidator ID="MEVg_cPage" runat="server" ControlToValidate="g_cPage" ControlExtender="MEEg_cPage" InvalidValueMessage="" EmptyValueMessage="" EmptyValueBlurredText="" Display="Dynamic" TooltipMessage="" EnableClientScript="true" IsValidEmpty="false" MinimumValue="1" SetFocusOnError="true" />
		</td>
		<td style="width: 40px">
			<asp:Label ID="Label2" runat="server" Font-Size="9px" Text=" of: "></asp:Label>
		</td>
		<td style="width: 80px">
			<asp:Label ID="g_Pages" runat="server" Font-Size="9px" Width="40px"></asp:Label>
		</td>
		<td width="40px">
			<asp:ImageButton ID="cmdFirst" runat="server" ToolTip="First" CommandName="Page" CommandArgument="First" AlternateText="First" ImageUrl="~/TblImages/first0.png" />
		</td>
		<td width="40px">
			<asp:ImageButton ID="cmdPrev" runat="server" ToolTip="Prev" CommandName="Page" CommandArgument="Prev" AlternateText="Prev" ImageUrl="~/TblImages/prev0.png" />
		</td>
		<td width="40px">
			<asp:ImageButton ID="cmdNext" runat="server" ToolTip="Next" CommandName="Page" CommandArgument="Next" AlternateText="Next" ImageUrl="~/TblImages/next0.png" />
		</td>
		<td width="40px">
			<asp:ImageButton ID="cmdLast" runat="server" ToolTip="Last" CommandName="Page" CommandArgument="Last" AlternateText="Last" ImageUrl="~/TblImages/last0.png" />
		</td>
		<td style="width: 80px; text-align:right">
			<asp:Label ID="Label4" runat="server" Font-Size="9px" Text="Records"></asp:Label>
		</td>
		<td style="width: 50px">
			<asp:TextBox ID="g_cSize" runat="server" Font-Size="9px" Width="40px" Style="text-align: right" CssClass="mytxt" AutoPostBack="true"></asp:TextBox>
			<AJX:MaskedEditExtender ID="MEEg_cSize" runat="server" Mask="99999" AcceptNegative="None" MaskType="Number" MessageValidatorTip="false" ErrorTooltipEnabled="false" TargetControlID="g_cSize" PromptCharacter="" />
			<AJX:MaskedEditValidator ID="MEVg_cSize" runat="server" ControlToValidate="g_cSize" ControlExtender="MEEg_cSize" InvalidValueMessage="" EmptyValueMessage="" EmptyValueBlurredText="" Display="Dynamic" TooltipMessage="" EnableClientScript="true" IsValidEmpty="false" MinimumValue="1" SetFocusOnError="true" />
		</td>
		<td style="width: 50px">
			<asp:LinkButton ID="cmdSize" runat="server" Font-Size="9px" Font-Bold="true" Text="/Page"></asp:LinkButton>
		</td>
		<td  style="text-align: right; padding-right: 5px; width: 500px">
			<table>
				<tr>
					<td style="vertical-align: middle; text-align: center">
						<asp:CheckBox ID="lg_End" runat="server" Enabled="false" AutoPostBack="true" ToolTip="Uncheck for normal view." />
					</td>
					<td style="vertical-align: middle; text-align: center">
						<asp:TextBox ID="lg_Search" runat="server" CssClass="mytxt" ToolTip="Enter keywords to search." ValidationGroup="lg_vgsearch" Width="80px" Font-Size="9px" MaxLength="250" />
						<AJX:TextBoxWatermarkExtender ID="lg_wm" runat="server" TargetControlID="lg_Search" WatermarkText="[Search]">
						</AJX:TextBoxWatermarkExtender>
						<asp:RequiredFieldValidator ID="lg_rfvst" runat="server" ControlToValidate="lg_Search" Display="none" EnableClientScript="true" ValidationGroup="lg_vgsearch" SetFocusOnError="true" />
					</td>
					<td style="vertical-align: middle; width: 34px; text-align: center">
						<asp:ImageButton ID="cmdSearch" runat="server" ImageUrl="~/TblImages/srh0.png" AlternateText="Search" ToolTip="Click to search" ValidationGroup="lg_vgsearch" />
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
