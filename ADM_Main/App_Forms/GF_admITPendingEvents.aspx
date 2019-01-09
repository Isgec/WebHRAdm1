<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admITPendingEvents.aspx.vb" Inherits="GF_admITPendingEvents" title="Pending HRIS Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<LGM:LGMessageBox
	 ID="LGMessage1"
	 runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "admITEventTransactions"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITEventTransactions" runat="server" Text="List Pending HRIS Events" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
     <script type="text/javascript">
     	function showInfoPopup(o) {
     		var aval = o.alt.split('|');
     		lgMessageBox.Execute('ID:' + aval[0] + '-EMP:' + aval[1] + '-' + aval[2],'GetCircularText',aval[0]);
     		return false;
     	}

    	function showPopup(o) {
    		var aval = o.alt.split('|');
    		lgMessageBox.ExecuteURL('ID:' + aval[0] + '-EMP:' + aval[1] + '-' + aval[2],'<%=ResolveUrl("GF_admITEventProgress.aspx")%>?EventID=' + aval[0]);
    		return false;
    	}
    	function showProgressPopup(o) {
    		var aval = o.id.split('|');
    		lgMessageBox.ExecuteURL('ID:' + aval[0] + '-SERVICE:' + aval[1] + '-EMP:' + aval[2], '../App_Edit/EF_admITEventProgress.aspx?EventID=' + aval[0] + '&ITServiceID=' + aval[3] + '&DC=1');
    		return false;
    	}
    	function hideProgressPopup(o) {
    		lgMessageBox.close();
    		__doPostBack('ctl00$ContentPlaceHolder1$cmd', '');
    		return false;
    	}
		</script>
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CardNo" runat="server" Text="Generated For :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CardNo"
						CssClass = "myfktxt"
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
    </table>
    <asp:button ID="cmd" runat="server" Text="." style="display:none" />
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="EventID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<table>
							<tr>
								<td>
									<asp:ImageButton ID="Edit" runat="server" AlternateText='<%#EVal("EventID") & "|" & Eval("FK_ADM_ITEventTransactions_HRM_Employees.DisplayField") & "|" & EVal("Description")%>' ToolTip="Edit the record." SkinID="Edit" OnClientClick="return showPopup(this);" CommandArgument='<%#EVal("EventID")%>' />
								</td>
								<td>
									<asp:ImageButton ID="Info" runat="server" AlternateText='<%#EVal("EventID") & "|" & Eval("FK_ADM_ITEventTransactions_HRM_Employees.DisplayField") & "|" & EVal("Description")%>' ToolTip="Click to view circular." SkinID="Info" OnClientClick="return showInfoPopup(this);" CommandArgument='<%#EVal("EventID")%>' />
								</td>
							</tr>
						</table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Event ID" SortExpression="EventID">
          <ItemTemplate>
            <asp:Label ID="LabelEventID" runat="server" Text='<%# Bind("EventID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Entry Date" SortExpression="EntryDate">
          <ItemTemplate>
            <asp:Label ID="LabelEntryDate" runat="server" Text='<%# Bind("EntryDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Generated For" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <span style="cursor:pointer" id="LinkButton1" onclick="lgMessageBox.Execute('Employee Detail','GetEmployeeInfo',<%#EVal("CardNo") %>);"><%# Eval("FK_ADM_ITEventTransactions_HRM_Employees.DisplayField") %></span>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="500px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
          <ItemTemplate>
            <div><%#Eval("EditDashBoardStatus")%></div>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
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
      DataObjectTypeName = "SIS.ADM.admITEventTransactions"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectPendingList"
      TypeName = "SIS.ADM.admITEventTransactions"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
