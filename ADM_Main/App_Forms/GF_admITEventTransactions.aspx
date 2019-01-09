<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admITEventTransactions.aspx.vb" Inherits="GF_admITEventTransactions" title="List: HRIS Event Transactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "admITEventTransactions"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITEventTransactions" runat="server" Text="List HRIS Event Transactions" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
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
    <script type="text/javascript">
    	function findpos(e) {
    		var left = 0;
    		var top = 0;
    		while (e.offsetParent) {
    			left += e.offsetLeft;
    			top += e.offsetTop;
    			e = e.offsetParent;
    		}
    		left += e.offsetLeft;
    		top += e.offsetTop;
    		return { x: left, y: top };
    	}
    	function show_tt(o) {
    		var p = o.id.split('_');
    		var q = $get('tt' + p[0]);
    		q.innerHTML = p[1];
    		var r = findpos(o);
    		q.style.top = r.y - 50;
    		q.style.left = r.x - 80;
    		q.style.display = 'block';
    	}
    	function hide_tt(o) {
    		var p = o.id.split('_');
    		var q = $get('tt' + p[0]);
    		q.innerHTML = '';
    		q.style.display = 'none';
    	}
    </script>
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="EventID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("EventID")%>' />
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
             <asp:Label ID="L_CardNo" runat="server" Text='<%# Eval("FK_ADM_ITEventTransactions_HRM_Employees.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="500px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Completed" SortExpression="CompletedOn">
          <ItemTemplate>
						<div id='<%# "tt" & Eval("EventID")%>' style="display:none; height:50px; width:137px; padding-top:15px; padding-left:12px; position:absolute; background-image:url('../../App_Themes/Default/Images/tt.png'); background-repeat:no-repeat" ></div>
<%--						<div id='<%# "tt" & Eval("EventID")%>' style="display:none; position:absolute; padding:5px; background-color:Yellow" ></div>
--%>            <asp:Label ID="LabelCompletedOn" runat="server" Text='<%# Bind("CompletedOn") %>'></asp:Label>
            <div><%#Eval("DashBoardStatus")%></div>
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
      SelectMethod = "SelectList"
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
