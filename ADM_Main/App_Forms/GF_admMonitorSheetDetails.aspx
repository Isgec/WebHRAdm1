<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admMonitorSheetDetails.aspx.vb" Inherits="GF_admMonitorSheetDetails" title="Maintain List: Sheet Detail By Monitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      EnableAdd = "False"
      ValidationGroup = "admMonitorSheetDetails"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmMonitorSheetDetails" runat="server" Text="List Sheet Detail By Monitor" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <table>
    </table>
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="SheetID, SerialNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
									<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("SheetID") & "," & EVal("SerialNo")%>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sheet" SortExpression="SheetID">
          <ItemTemplate>
            <asp:Label ID="LabelSheetID" runat="server" Text='<%# Bind("SheetID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Check Point" SortExpression="ADM_CheckPoints1_Descriptions">
          <ItemTemplate>
             <asp:Label ID="L_CheckPointID" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_CheckPoints.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Measure" SortExpression="ADM_Measures2_Description">
          <ItemTemplate>
             <asp:Label ID="L_MeasureID" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Initiator Remarks" SortExpression="InitiatorRemarks">
          <ItemTemplate>
            <asp:Label ID="LabelInitiatorRemarks" runat="server" Text='<%# Bind("InitiatorRemarks") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Monitor Remarks" SortExpression="MonitorRemarks">
          <ItemTemplate>
            <asp:Label ID="LabelMonitorRemarks" runat="server" Text='<%# Bind("MonitorRemarks") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Monitored By" SortExpression="HRM_Employees7_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_MonitoredBy" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_HRM_Employees1.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Monitored On" SortExpression="MonitoredOn">
          <ItemTemplate>
            <asp:Label ID="LabelMonitoredOn" runat="server" Text='<%# Bind("MonitoredOn") %>'></asp:Label>
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
      DataObjectTypeName = "SIS.ADM.admMonitorSheetDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admMonitorSheetDetails"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
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
