<%@ Page Title="" Language="VB" MasterPageFile="~/Plain.master" AutoEventWireup="false" CodeFile="FeedBack.aspx.vb" Inherits="FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<table id="tblF" runat="server" style="width:50%; margin: 40px auto">
	<tr>
		<td style="text-align:center; color: #FFFFFF; font-weight: bold; font-size: medium;" bgcolor="#3333FF">Your feedback is important to us, to serve you better</td>
	</tr>
	<tr>
		<td style="text-align:center; color: #000000;" bgcolor="#6699FF"> Click on the option below to rate:-
		<asp:Label ID="F_CallID" runat="server" style="display:none" text="" />
		</td>
		</tr>
		<tr>
			<td bgcolor="#6699FF" style="padding-left: 25px; height: 50px;">
				<asp:RadioButtonList ID="F_FeedBack" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" BackColor="#6699FF" Font-Bold="True" ForeColor="White">
				<asp:ListItem Value="1">Poor</asp:ListItem>
				<asp:ListItem Value="2">Good</asp:ListItem>
				<asp:ListItem Value="3">Excellent</asp:ListItem>
			</asp:RadioButtonList>
    </td>
	</tr>
</table>
<table id="tblS" runat="server" style="width:50%; margin: 40px auto">
	<tr>
		<td style="text-align:center; color: #FFFFFF; font-weight: bold; font-size: medium; height: 50px;" bgcolor="#3333FF">Your feedback is already recorded.</td>
	</tr>
</table>
<table id="tblT" runat="server" style="width:50%; margin: 40px auto">
	<tr>
		<td style="text-align:center; color: #FFFFFF; font-weight: bold; font-size: medium; height: 50px;" bgcolor="#3333FF">Thanks for Your valuable feedback</td>
	</tr>
</table>
</asp:Content>

