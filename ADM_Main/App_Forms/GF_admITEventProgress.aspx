<%@ Page Language="VB" MasterPageFile="~/Plain.master" AutoEventWireup="false" CodeFile="GF_admITEventProgress.aspx.vb" Inherits="GF_admITEventProgress" title="Maintain List: IT Event Progress" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" style="width:800px" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
		</br>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="EventID, ITServiceID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("EventID") & "," & EVal("ITServiceID")%>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IT Service" SortExpression="ADM_ITServices2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ITServiceID" ForeColor='<%#EVal("ForeColor") %>' Font-Bold="true" runat="server" Text='<%# Eval("FK_ADM_ITEventStatus_ADM_ITServices.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action Not Required" SortExpression="ActionNotRequired">
          <ItemTemplate>
            <asp:Label ID="LabelActionNotRequired" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("ActionNotRequired") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action Taken" SortExpression="ActionTaken">
          <ItemTemplate>
            <asp:Label ID="LabelActionTaken" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("ActionTaken") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded By" SortExpression="HRM_Employees3_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_RespondedBy" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Eval("FK_ADM_ITEventStatus_HRM_Employees.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responded On" SortExpression="RespondedOn">
          <ItemTemplate>
            <asp:Label ID="LabelRespondedOn" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("RespondedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Alerted On" SortExpression="AlertedOn">
          <ItemTemplate>
            <asp:Label ID="LabelAlertedOn" ForeColor='<%#EVal("ForeColor") %>' runat="server" Text='<%# Bind("AlertedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
      <RowStyle BackColor="PaleGoldenrod" />
      <PagerStyle BackColor="DarkGoldenrod" Font-Bold="True" HorizontalAlign="Center" />
      <HeaderStyle BackColor="DarkGoldenrod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1pt" Font-Size="8pt" Font-Names="vardana" />
      <AlternatingRowStyle BackColor="Bisque" />
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ADM.admITEventProgress"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admITEventProgress"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:QueryStringParameter QueryStringField="EventID" Name="EventID" DefaultValue="-1" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
