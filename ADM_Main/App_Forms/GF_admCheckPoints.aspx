<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admCheckPoints.aspx.vb" Inherits="GF_admCheckPoints" title="Maintain List: Check Points" %>
<asp:Content ID="CPHadmCheckPoints" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLadmCheckPoints" runat="server">
  <ContentTemplate>
    <LGM:ToolBar 
      ID = "TBLadmCheckPoints"
      ToolType = "lgNMGrid"
      ValidationGroup = "admCheckPoints"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmCheckPoints" runat="server" Text="List Check Points" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UPGSadmCheckPoints" runat="server" AssociatedUpdatePanelID="UPNLadmCheckPoints" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <table>
    </table>
    <asp:GridView ID="GVadmCheckPoints" SkinID="gridviewSkin" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSadmCheckPoints" DataKeyNames="CheckPointID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
								<asp:ImageButton ID="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("CheckPointID")%>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Check Point" SortExpression="CheckPointID">
          <ItemTemplate>
            <asp:Label ID="LabelCheckPointID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CheckPointID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descriptions" SortExpression="Descriptions">
          <ItemTemplate>
            <asp:Label ID="LabelDescriptions" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Descriptions") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Schedule" SortExpression="ADM_Schedules1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ScheduleID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ScheduleID") %>' Text='<%# Eval("ADM_Schedules1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate">
          <ItemTemplate>
            <asp:Label ID="LabelStartDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StartDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Day Of Schedule" SortExpression="DayOfSchedule">
          <ItemTemplate>
            <asp:Label ID="LabelDayOfSchedule" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DayOfSchedule") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Floating" SortExpression="Floating">
          <ItemTemplate>
            <asp:Label ID="LabelFloating" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Floating") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Initiator" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_Initiator" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("Initiator") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSadmCheckPoints"
      runat = "server"
      DataObjectTypeName = "SIS.ADM.admCheckPoints"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admCheckPoints"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVadmCheckPoints" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
