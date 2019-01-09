<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FVPaging.aspx.vb" Inherits="FVPaging" %>

<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "admITRegisterComplaint"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITRegisterComplaint" runat="server" Text="Register / Attend Complaints" CssClass="sis_formheading"></asp:Label>
    <hr />
	<asp:FormView ID="FormView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="ObjectDataSource1" DefaultMode="Edit" HeaderText="Adimn Services">
		<PagerSettings Position="TopAndBottom" />
		<FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
		<RowStyle BackColor="#DEDFDE" ForeColor="Black" />
		<EditItemTemplate>
			ServiceID:
			<asp:TextBox ID="ServiceIDTextBox" runat="server" Text='<%# Bind("ServiceID") %>' />
			<br />
			Description:
			<asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
			<br />
			OfficeID:
			<asp:TextBox ID="OfficeIDTextBox" runat="server" Text='<%# Bind("OfficeID") %>' />
			<br />
			ScheduleID:
			<asp:TextBox ID="ScheduleIDTextBox" runat="server" Text='<%# Bind("ScheduleID") %>' />
			<br />
			LastSheetDate:
			<asp:TextBox ID="LastSheetDateTextBox" runat="server" Text='<%# Bind("LastSheetDate") %>' />
			<br />
			DisplayField:
			<asp:TextBox ID="DisplayFieldTextBox" runat="server" Text='<%# Bind("DisplayField") %>' />
			<br />
			PrimaryKey:
			<asp:TextBox ID="PrimaryKeyTextBox" runat="server" Text='<%# Bind("PrimaryKey") %>' />
			<br />
			FK_ADM_Services_HRM_Offices:
			<asp:TextBox ID="FK_ADM_Services_HRM_OfficesTextBox" runat="server" Text='<%# Bind("FK_ADM_Services_HRM_Offices") %>' />
			<br />
			FK_ADM_Services_ADM_Schedules:
			<asp:TextBox ID="FK_ADM_Services_ADM_SchedulesTextBox" runat="server" Text='<%# Bind("FK_ADM_Services_ADM_Schedules") %>' />
			<br />
			<asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
			&nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
		</EditItemTemplate>
		<InsertItemTemplate>
			ServiceID:
			<asp:TextBox ID="ServiceIDTextBox" runat="server" Text='<%# Bind("ServiceID") %>' />
			<br />
			Description:
			<asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
			<br />
			OfficeID:
			<asp:TextBox ID="OfficeIDTextBox" runat="server" Text='<%# Bind("OfficeID") %>' />
			<br />
			ScheduleID:
			<asp:TextBox ID="ScheduleIDTextBox" runat="server" Text='<%# Bind("ScheduleID") %>' />
			<br />
			LastSheetDate:
			<asp:TextBox ID="LastSheetDateTextBox" runat="server" Text='<%# Bind("LastSheetDate") %>' />
			<br />
			DisplayField:
			<asp:TextBox ID="DisplayFieldTextBox" runat="server" Text='<%# Bind("DisplayField") %>' />
			<br />
			PrimaryKey:
			<asp:TextBox ID="PrimaryKeyTextBox" runat="server" Text='<%# Bind("PrimaryKey") %>' />
			<br />
			FK_ADM_Services_HRM_Offices:
			<asp:TextBox ID="FK_ADM_Services_HRM_OfficesTextBox" runat="server" Text='<%# Bind("FK_ADM_Services_HRM_Offices") %>' />
			<br />
			FK_ADM_Services_ADM_Schedules:
			<asp:TextBox ID="FK_ADM_Services_ADM_SchedulesTextBox" runat="server" Text='<%# Bind("FK_ADM_Services_ADM_Schedules") %>' />
			<br />
			<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
			&nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
		</InsertItemTemplate>
		<ItemTemplate>
			ServiceID:
			<asp:Label ID="ServiceIDLabel" runat="server" Text='<%# Bind("ServiceID") %>' />
			<br />
			Description:
			<asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>' />
			<br />
			OfficeID:
			<asp:Label ID="OfficeIDLabel" runat="server" Text='<%# Bind("OfficeID") %>' />
			<br />
			ScheduleID:
			<asp:Label ID="ScheduleIDLabel" runat="server" Text='<%# Bind("ScheduleID") %>' />
			<br />
			LastSheetDate:
			<asp:Label ID="LastSheetDateLabel" runat="server" Text='<%# Bind("LastSheetDate") %>' />
			<br />
			DisplayField:
			<asp:Label ID="DisplayFieldLabel" runat="server" Text='<%# Bind("DisplayField") %>' />
			<br />
			PrimaryKey:
			<asp:Label ID="PrimaryKeyLabel" runat="server" Text='<%# Bind("PrimaryKey") %>' />
			<br />
			FK_ADM_Services_HRM_Offices:
			<asp:Label ID="FK_ADM_Services_HRM_OfficesLabel" runat="server" Text='<%# Bind("FK_ADM_Services_HRM_Offices") %>' />
			<br />
			FK_ADM_Services_ADM_Schedules:
			<asp:Label ID="FK_ADM_Services_ADM_SchedulesLabel" runat="server" Text='<%# Bind("FK_ADM_Services_ADM_Schedules") %>' />
			<br />
			<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
			&nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
			&nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
		</ItemTemplate>
		<PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
		<HeaderStyle BackColor="#4A3C8C" BorderColor="#6600FF" BorderStyle="Solid" BorderWidth="1pt" Font-Bold="True" ForeColor="#E7E7FF" />
		<EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
	</asp:FormView>
	<asp:ObjectDataSource 
		ID="ObjectDataSource1" 
		runat="server" DataObjectTypeName="SIS.ADM.admServices" 
		DeleteMethod="Delete" 
		InsertMethod="Insert" 
		OldValuesParameterFormatString="original_{0}" 
		SelectMethod="SelectList" 
		TypeName="SIS.ADM.admServices" 
		UpdateMethod="Update" 
		EnablePaging="True" 
		SelectCountMethod="SelectCount" 
		SortParameterName="OrderBy">
		<SelectParameters>
			<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
			<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>

