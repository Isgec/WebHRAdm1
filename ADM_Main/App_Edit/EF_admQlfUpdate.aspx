<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admQlfUpdate.aspx.vb" Inherits="EF_admQlfUpdate" title="Edit: Qualification Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CardNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admQlfUpdate"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmQlfUpdate" runat="server" Text="Edit Qualification Update" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CardNo" runat="server" ForeColor="#CC6633" Text="CardNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CardNo"
            Width="56px"
						Text='<%# Bind("CardNo") %>'
						AutoCompleteType = "None"
						CssClass = "mypktxt"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_CardNo_Display"
						Text='<%# Eval("FK_HRM_QlfUpdate_HRM_Employees.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_emailid" runat="server" Text="emailid :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_emailid"
						Text='<%# Bind("emailid") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for emailid."
						MaxLength="100"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DepartmentID" runat="server" Text="Department :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DepartmentID"
            Width="42px"
						Text='<%# Bind("DepartmentID") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_DepartmentID_Display"
						Text='<%# Eval("FK_HRM_QlfUpdate_HRM_Departments.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Qlf1ID" runat="server" Text="QLF-1 :" /></b>
				</td>
        <td>
          <LGM:LC_admQualifications
            ID="F_Qlf1ID"
            SelectedValue='<%# Bind("Qlf1ID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Qlf1Yr" runat="server" Text="Yr-1 :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Qlf1Yr"
						Text='<%# Bind("Qlf1Yr") %>'
            Width="28px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Yr-1."
						MaxLength="4"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Qlf1NotInList" runat="server" Text="QLF 1 Not In List :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_Qlf1NotInList"
						  Checked='<%# Bind("Qlf1NotInList") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Qlf1Specified" runat="server" Text="Specify QLF 2 :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Qlf1Specified"
						Text='<%# Bind("Qlf1Specified") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Specify QLF 2."
						MaxLength="50"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Qlf2ID" runat="server" Text="QLF-2 :" /></b>
				</td>
        <td>
          <LGM:LC_admQualifications
            ID="F_Qlf2ID"
            SelectedValue='<%# Bind("Qlf2ID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Qlf2Yr" runat="server" Text="Yr-2 :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Qlf2Yr"
						Text='<%# Bind("Qlf2Yr") %>'
            Width="28px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Yr-2."
						MaxLength="4"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Qlf2NotInList" runat="server" Text="OLF 2 Not In List :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_Qlf2NotInList"
						  Checked='<%# Bind("Qlf2NotInList") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Qlf2Specified" runat="server" Text="Specifiy QLF 2 :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Qlf2Specified"
						Text='<%# Bind("Qlf2Specified") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Specifiy QLF 2."
						MaxLength="50"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FatherName" runat="server" Text="Father Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FatherName"
						Text='<%# Bind("FatherName") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Father Name."
						MaxLength="50"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DateOfBirth" runat="server" Text="Date Of Birth :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DateOfBirth"
						Text='<%# Bind("DateOfBirth") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="admQlfUpdate"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonDateOfBirth" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDateOfBirth"
            TargetControlID="F_DateOfBirth"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDateOfBirth" />
					<AJX:MaskedEditExtender 
						ID = "MEEDateOfBirth"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_DateOfBirth" />
					<AJX:MaskedEditValidator 
						ID = "MEVDateOfBirth"
						runat = "server"
						ControlToValidate = "F_DateOfBirth"
						ControlExtender = "MEEDateOfBirth"
						InvalidValueMessage = "Invalid value for Date Of Birth."
						EmptyValueMessage = "Date Of Birth is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Date Of Birth."
						EnableClientScript = "true"
						ValidationGroup = "admQlfUpdate"
						IsValidEmpty = "true"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BloodGroupID" runat="server" Text="Blood Group :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BloodGroupID"
						Text='<%# Bind("BloodGroupID") %>'
            Width="35px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Blood Group."
						MaxLength="5"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_N_CellNo" runat="server" Text="Mobile No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_N_CellNo"
						Text='<%# Bind("N_CellNo") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Mobile No."
						MaxLength="50"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_sendmail" runat="server" Text="sendmail :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_sendmail"
						  Checked='<%# Bind("sendmail") %>'
              runat="server" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admQlfUpdate"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admQlfUpdate"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CardNo" Name="CardNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
