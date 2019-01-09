<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admServiceCheckPoints.aspx.vb" Inherits="GF_admServiceCheckPoints" title="Maintain List: Service Check Points" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      ValidationGroup = "admServiceCheckPoints"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmServiceCheckPoints" runat="server" Text="List Service Check Points" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <table>
    </table>
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="ServiceID, CheckPointID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
									<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("ServiceID") & "," & EVal("CheckPointID")%>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Service" SortExpression="ADM_Services2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ServiceID" runat="server" Text='<%# Eval("FK_ADM_ServiceCheckPoints_ADM_Services.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Check Point" SortExpression="ADM_CheckPoints1_Descriptions">
          <ItemTemplate>
             <asp:Label ID="L_CheckPointID" runat="server" Text='<%# Eval("FK_ADM_ServiceCheckPoints_ADM_CheckPoints.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
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
      DataObjectTypeName = "SIS.ADM.admServiceCheckPoints"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admServiceCheckPoints"
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
