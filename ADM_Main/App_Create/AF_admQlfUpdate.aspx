<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admQlfUpdate.aspx.vb" Inherits="AF_admQlfUpdate" title="Add: Qualification Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CardNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admQlfUpdate"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmQlfUpdate" runat="server" Text="Add Qualification Update" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CardNo" ForeColor="#CC6633" runat="server" Text="CardNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CardNo"
						CssClass = "mypktxt"
            Width="56px"
						Text='<%# Bind("CardNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for CardNo."
						ValidationGroup = "admQlfUpdate"
            onblur= "validate_CardNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_CardNo_Display"
						Text='<%# Eval("FK_HRM_QlfUpdate_HRM_Employees.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCardNo"
						runat = "server"
						ControlToValidate = "F_CardNo"
						Text = "CardNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admQlfUpdate"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECardNo_Selected"
            OnClientPopulating="ACECardNo_Populating"
            OnClientPopulated="ACECardNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_emailid" runat="server" Text="emailid :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_emailid"
						Text='<%# Bind("emailid") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for emailid."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
						CssClass = "myfktxt"
            Width="42px"
						Text='<%# Bind("DepartmentID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Department."
						ValidationGroup = "admQlfUpdate"
            onblur= "validate_DepartmentID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DepartmentID_Display"
						Text='<%# Eval("FK_HRM_QlfUpdate_HRM_Departments.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDepartmentID"
            BehaviorID="B_ACEDepartmentID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DepartmentIDCompletionList"
            TargetControlID="F_DepartmentID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEDepartmentID_Selected"
            OnClientPopulating="ACEDepartmentID_Populating"
            OnClientPopulated="ACEDepartmentID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Yr-1."
						MaxLength="4"
            Width="28px"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Specify QLF 2."
						MaxLength="50"
            Width="350px"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Yr-2."
						MaxLength="4"
            Width="28px"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Specifiy QLF 2."
						MaxLength="50"
            Width="350px"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Father Name."
						MaxLength="50"
            Width="350px"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admQlfUpdate"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Blood Group."
						MaxLength="5"
            Width="35px"
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
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admQlfUpdate"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admQlfUpdate"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
