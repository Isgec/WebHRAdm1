<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admQlfUpdate.aspx.vb" Inherits="GF_admQlfUpdate" title="Maintain List: Qualification Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "admQlfUpdate"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmQlfUpdate" runat="server" Text="List Qualification Update" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <script type="text/javascript">
    	var L_FCardNo = '';
    	function fromcardno_change(o) {
    		if (o.value != L_FCardNo) {
    			$get('<%=To_CardNo.ClientID %>').value = o.value;
    			L_FCardNo = o.value;
    		}
    	}
    </script>
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" runat="server" Text="Send Mail to ALL :" /></b>
				</td>
        <td>
					<table>
						<tr>
							<td>
								<asp:TextBox ID="From_CardNo" CssClass="mytxt" Width="40px" onfocus="return this.select();" onblur="fromcardno_change(this);"  MaxLength="4" runat="server" Text=""></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="To_CardNo" CssClass="mytxt" Width="40px" MaxLength="4" onfocus="return this.select();" runat="server" Text=""></asp:TextBox>
							</td>
							<td>
								<asp:ImageButton ID="Fwd" runat="server" AlternateText="Fwd" ToolTip="Send Mail" CssClass="ok_button" style="height:30px; width:30px; cursor:pointer" ImageUrl="~/App_Themes/Default/Images/forward.png" OnClick="FwdAll_Click" OnClientClick="return confirm('Send mail to all ?');" />
							</td>
						</tr>
					</table>
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CardNo" runat="server" Text="CardNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CardNo"
						CssClass = "mypktxt"
            Width="56px"
						Text='<%# Bind("CardNo") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_CardNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_CardNo_Display"
						Text='<%# Eval("CardNoHRM_Employees.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
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
					<b><asp:Label ID="L_DepartmentID" runat="server" Text="Department :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DepartmentID"
						CssClass = "myfktxt"
            Width="42px"
						Text='<%# Bind("DepartmentID") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_DepartmentID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_DepartmentID_Display"
						Text='<%# Eval("DepartmentIDHRM_Departments.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDepartmentID"
            BehaviorID="B_ACEDepartmentID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DepartmentIDCompletionList"
            TargetControlID="F_DepartmentID"
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
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="QualificationID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
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
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="QualificationID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
          </td>
			</tr>
    </table>
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="CardNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("CardNo")%>' />
						<asp:ImageButton ID="Fwd" runat="server" AlternateText="Fwd" ToolTip="Send Mail" ImageUrl="~/App_Themes/Default/Images/forward.png" OnClick="Fwd_Click" CommandArgument='<%#EVal("CardNo")%>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CardNo" SortExpression="HRM_Employees2_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" Text='<%# Eval("FK_HRM_QlfUpdate_HRM_Employees.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="emailid" SortExpression="emailid">
          <ItemTemplate>
            <asp:Label ID="Labelemailid" runat="server" Text='<%# Bind("emailid") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Department" SortExpression="HRM_Departments1_Description">
          <ItemTemplate>
             <asp:Label ID="L_DepartmentID" runat="server" Text='<%# Eval("FK_HRM_QlfUpdate_HRM_Departments.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="QLF-1" SortExpression="HRM_Qualifications3_Description">
          <ItemTemplate>
             <asp:Label ID="L_Qlf1ID" runat="server" Text='<%# Eval("FK_HRM_QlfUpdate_HRM_Qualifications.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Yr-1" SortExpression="Qlf1Yr">
          <ItemTemplate>
            <asp:Label ID="LabelQlf1Yr" runat="server" Text='<%# Bind("Qlf1Yr") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="QLF-2" SortExpression="HRM_Qualifications4_Description">
          <ItemTemplate>
             <asp:Label ID="L_Qlf2ID" runat="server" Text='<%# Eval("FK_HRM_QlfUpdate_HRM_Qualifications1.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Yr-2" SortExpression="Qlf2Yr">
          <ItemTemplate>
            <asp:Label ID="LabelQlf2Yr" runat="server" Text='<%# Bind("Qlf2Yr") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Father Name" SortExpression="FatherName">
          <ItemTemplate>
            <asp:Label ID="LabelFatherName" runat="server" Text='<%# Bind("FatherName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Changed" SortExpression="Changed">
          <ItemTemplate>
            <asp:Label ID="LabelChanged" runat="server" Text='<%# Bind("Changed") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
      <RowStyle BackColor="PaleGoldenrod" />
      <PagerStyle BackColor="DarkGoldenrod" Font-Bold="True" HorizontalAlign="Center" />
      <HeaderStyle BackColor="DarkGoldenrod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" />
      <AlternatingRowStyle BackColor="Bisque" />
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ADM.admQlfUpdate"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admQlfUpdate"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_DepartmentID" PropertyName="Text" Name="DepartmentID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_Qlf1ID" PropertyName="SelectedValue" Name="Qlf1ID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Qlf2ID" PropertyName="SelectedValue" Name="Qlf2ID" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
    <asp:AsyncPostBackTrigger ControlID="F_DepartmentID" />
    <asp:AsyncPostBackTrigger ControlID="F_Qlf1ID" />
    <asp:AsyncPostBackTrigger ControlID="F_Qlf2ID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
