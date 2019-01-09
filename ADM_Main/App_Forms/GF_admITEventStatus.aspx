<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admITEventStatus.aspx.vb" Inherits="GF_admITEventStatus" title="Maintain List: IT Event Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "admITEventStatus"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITEventStatus" runat="server" Text="List IT Event Status" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EventID" runat="server" Text="Event :" /></b>
				</td>
        <td>
          <input type="text" 
					<asp:TextBox
						ID = "F_EventID"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("EventID") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
					  AutoPostBack="true"
						Runat="Server" />
					<asp:Label
						ID = "F_EventID_Display"
						Text='<%# Eval("EventIDADM_ITEventTransactions.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEventID"
            BehaviorID="B_ACEEventID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EventIDCompletionList"
            TargetControlID="F_EventID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEventID_Selected"
            OnClientPopulating="ACEEventID_Populating"
            OnClientPopulated="ACEEventID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ITServiceID" runat="server" Text="IT Service :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ITServiceID"
						CssClass = "mypktxt"
            Width="105px"
						Text='<%# Bind("ITServiceID") %>'
						onfocus = "return this.select();"
						AutoCompleteType = "None"
					  AutoPostBack="true"
						Runat="Server" />
					<asp:Label
						ID = "F_ITServiceID_Display"
						Text='<%# Eval("ITServiceIDADM_ITServices.DisplayField") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEITServiceID"
            BehaviorID="B_ACEITServiceID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ITServiceIDCompletionList"
            TargetControlID="F_ITServiceID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEITServiceID_Selected"
            OnClientPopulating="ACEITServiceID_Populating"
            OnClientPopulated="ACEITServiceID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
    </table>
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="EventID, ITServiceID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
									<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("EventID") & "," & EVal("ITServiceID")%>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Event" SortExpression="ADM_ITEventTransactions1_Description">
          <ItemTemplate>
             <asp:Label ID="L_EventID" runat="server" Text='<%# Eval("FK_ADM_ITEventStatus_ADM_ITEventTransactions.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IT Service" SortExpression="ADM_ITServices2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ITServiceID" runat="server" Text='<%# Eval("FK_ADM_ITEventStatus_ADM_ITServices.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action Not Required" SortExpression="ActionNotRequired">
          <ItemTemplate>
            <asp:Label ID="LabelActionNotRequired" runat="server" Text='<%# Bind("ActionNotRequired") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action Taken" SortExpression="ActionTaken">
          <ItemTemplate>
            <asp:Label ID="LabelActionTaken" runat="server" Text='<%# Bind("ActionTaken") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded" SortExpression="Responded">
          <ItemTemplate>
            <asp:Label ID="LabelResponded" runat="server" Text='<%# Bind("Responded") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded By" SortExpression="HRM_Employees3_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_RespondedBy" runat="server" Text='<%# Eval("FK_ADM_ITEventStatus_HRM_Employees.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded On" SortExpression="RespondedOn">
          <ItemTemplate>
            <asp:Label ID="LabelRespondedOn" runat="server" Text='<%# Bind("RespondedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Alerted On" SortExpression="AlertedOn">
          <ItemTemplate>
            <asp:Label ID="LabelAlertedOn" runat="server" Text='<%# Bind("AlertedOn") %>'></asp:Label>
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
      DataObjectTypeName = "SIS.ADM.admITEventStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admITEventStatus"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_EventID" PropertyName="Text" Name="EventID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ITServiceID" PropertyName="Text" Name="ITServiceID" Type="String" Size="15" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_EventID" />
    <asp:AsyncPostBackTrigger ControlID="F_ITServiceID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
