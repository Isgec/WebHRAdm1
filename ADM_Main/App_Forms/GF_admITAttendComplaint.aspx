<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admITAttendComplaint.aspx.vb" Inherits="GF_admITAttendComplaint" title="Maintain List: Attend Complaints" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      EnableAdd = "False"
      ValidationGroup = "admITAttendComplaint"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITAttendComplaint" runat="server" Text="List Attend Complaints" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <hr />
    <asp:Panel ID="PnlPopup" Height="490px" Width="1000px" runat="server" CssClass="modalPopup" style="display:none"  >
    <table height="100%" width="100%">
    <tr>
      <td style="background-color: ActiveCaption; height: 20px; cursor: move; vertical-align:top">
        <table id="TitleBar1" runat="server" style="width: 100%; height: 100%; border: none" >
          <tr>
            <td align="left">
              <asp:Label ID="LabelCaption" runat="server" Text="Title" Font-Bold="True" Font-Size="12px" ForeColor="White"></asp:Label></td>
            <td align="right" style="text-align: right"><asp:ImageButton ID="CloseWindow" runat="server" ToolTip="Close" style="cursor:pointer" Height="20px" Width="20px" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" /></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr><td style="vertical-align:top; height:467px">
    <iframe runat="server" enableviewstate="false" id="IfBd1" frameborder="0" scrolling="auto" style="height:100%; width:100%" class="ifbd_bg">
    </iframe>
    </td></tr>
    </table>
    </asp:Panel>
    <asp:Button ID="cmdDummy" runat="server" Style="display: none" Text="Dummy" />
    <AJX:ModalPopupExtender 
      ID="mpe99" 
      runat="server" 
      BackgroundCssClass="modalBackground"
      BehaviorID="mpe99bid" 
      DropShadow="True" 
      OkControlID="CloseWindow"
      PopupControlID="PnlPopup" 
      PopupDragHandleControlID="TitleBar1" 
      TargetControlID="CmdDummy">
    </AJX:ModalPopupExtender>
    <script type="text/javascript">
    	function showPopup(o) {
    		$find('mpe99bid').show();
    		var aval = o.alt.split('|');
    		$get('<%=LabelCaption.ClientID %>').innerHTML = 'ID:'+aval[0]+'-EMP:'+aval[1]+'-'+aval[2];
    		$get('<%=IfBd1.ClientID %>').src = 'GF_admITComplaintResponse.aspx?CallID=' + aval[0];
    		return false;
    	}
    	function hidePopup() {
    		$find('mpe99bid').hide();
    		return false;
    	}
    </script>
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EndUserID" runat="server" Text="End User :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_EndUserID"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("EndUserID") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_EndUserID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_EndUserID_Display"
						Text='<%# Eval("EndUserIDHRM_Employees.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEndUserID"
            BehaviorID="B_ACEEndUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EndUserIDCompletionList"
            TargetControlID="F_EndUserID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEndUserID_Selected"
            OnClientPopulating="ACEEndUserID_Populating"
            OnClientPopulated="ACEEndUserID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallTypeID" runat="server" Text="Call Type :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallTypes
            ID="F_CallTypeID"
            SelectedValue='<%# Bind("CallTypeID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CallTypeID"
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
					<b><asp:Label ID="L_CallStatusID" runat="server" Text="Call Status :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallStatus
            ID="F_CallStatusID"
            SelectedValue='<%# Bind("CallStatusID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CallStatusID"
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
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="CallID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<asp:ImageButton ID="Edit" runat="server" AlternateText='<%#EVal("CallID") & "|" & Eval("FK_ADM_ITComplaints_HRM_Employees.DisplayField") & "|" & Eval("EndUserID") %>' ToolTip="Click to maintain response." SkinID="Edit" OnClientClick="return showPopup(this);" CommandArgument='<%#EVal("CallID")%>' />
						<asp:ImageButton ID="Info" runat="server" AlternateText="Info" ToolTip="Click to view call details." SkinID="info" OnClick="Edit_Click" CommandArgument='<%#EVal("CallID")%>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Call ID" SortExpression="CallID">
          <ItemTemplate>
            <asp:Label ID="LabelCallID" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("CallID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="End User" SortExpression="HRM_Employees5_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_EndUserID" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("FK_ADM_ITComplaints_HRM_Employees.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Call Type" SortExpression="ADM_ITCallTypes2_Description">
          <ItemTemplate>
             <asp:Label ID="L_CallTypeID" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("FK_ADM_ITComplaints_ADM_ITCallTypes.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="300px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Logged On" SortExpression="LoggedOn">
          <ItemTemplate>
            <asp:Label ID="LabelLoggedOn" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("LoggedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Logged By" SortExpression="aspnet_users3_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_LoggedBy" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("FK_ADM_ITComplaints_ADM_Users.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="First Attended" SortExpression="FirstAttendedOn">
          <ItemTemplate>
            <asp:Label ID="LabelFirstAttended" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("FirstAttendedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Closed" SortExpression="ClosedOn">
          <ItemTemplate>
            <asp:Label ID="LabelClosed" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("ClosedOn") %>' ></asp:Label>
            <asp:Button ID="cmdClosed" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text="Close" CssClass="mytxt" Enabled='<%#EVal("Enabled") %>' Visible='<%#EVal("Visible") %>' CommandName="Close" CommandArgument='<%#EVal("CallID")%>' OnClientClick="return confirm('Close the call ?');" />
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
      DataObjectTypeName = "SIS.ADM.admITAttendComplaint"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admITAttendComplaint"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_EndUserID" PropertyName="Text" Name="EndUserID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_CallTypeID" PropertyName="SelectedValue" Name="CallTypeID" Type="String" Size="20" />
        <asp:ControlParameter ControlID="F_CallStatusID" PropertyName="SelectedValue" Name="CallStatusID" Type="String" Size="20" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_EndUserID" />
    <asp:AsyncPostBackTrigger ControlID="F_CallTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_CallStatusID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
