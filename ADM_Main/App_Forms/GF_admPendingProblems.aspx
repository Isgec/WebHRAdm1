<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admPendingProblems.aspx.vb" Inherits="GF_admPendingProblems" title="Maintain List: Pending Problems" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      EnableAdd = "False"
      ValidationGroup = "admPendingProblems"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmPendingProblems" runat="server" Text="List Pending Problems" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ServiceID" runat="server" Text="Service :" /></b>
				</td>
        <td>
          <LGM:LC_admServices
            ID="F_ServiceID"
            SelectedValue='<%# Bind("ServiceID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="ServiceID"
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
					<b><asp:Label ID="L_CheckPointID" runat="server" Text="Check Point :" /></b>
				</td>
        <td>
          <LGM:LC_admCheckPoints
            ID="F_CheckPointID"
            SelectedValue='<%# Bind("CheckPointID") %>'
            OrderBy="Descriptions"
            DataTextField="Descriptions"
            DataValueField="CheckPointID"
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
    <asp:GridView ID="GridView1" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="SheetID, SerialNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("SheetID") & "," & EVal("SerialNo")%>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sheet Date" SortExpression="SheetDate">
          <ItemTemplate>
            <asp:Label ID="LabelSheetDate" runat="server" Text='<%# Bind("SheetDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Service" SortExpression="ADM_Services4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ServiceID" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_Services.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Check Point" SortExpression="ADM_CheckPoints1_Descriptions">
          <ItemTemplate>
             <asp:Label ID="L_CheckPointID" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_CheckPoints.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Measure/ Mechanism" SortExpression="ADM_Measures2_Description">
          <ItemTemplate>
						<table>
							<tr>
								<td><asp:Label ID="L_MeasureID" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.DisplayField") %>'></asp:Label>
								</td>
							</tr>
							<tr>
								<td><b><asp:Label ID="L_MonitoringMechanism" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.MonitoringMechanism") %>'></asp:Label></b>
								</td>
							</tr>
						</table>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Initiated" SortExpression="HRM_Employees6_EmployeeName">
          <ItemTemplate>
						 <table>
							<tr>
								<td><b>By:&nbsp;</b>
								</td>
								<td><asp:Label ID="L_InitiatedBy" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_HRM_Employees.DisplayField") %>'></asp:Label>
								</td>
							</tr>
							<tr>
								<td><b>On:&nbsp;</b>
								</td>
								<td><asp:Label ID="LabelInitiatedOn" runat="server" Text='<%# Bind("InitiatedOn") %>'></asp:Label>
								</td>
							</tr>
							<tr>
								<td><b>Rem:&nbsp;</b>
								</td>
								<td><asp:Label ID="LabelInitiatorRemarks" runat="server" Text='<%# Bind("InitiatorRemarks") %>'></asp:Label>
								</td>
							</tr>
						 </table>
          </ItemTemplate>
          <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Monitored" SortExpression="HRM_Employees7_EmployeeName">
          <ItemTemplate>
						 <table>
							<tr>
								<td><b>By:&nbsp;</b>
								</td>
								<td><asp:Label ID="L_MonitoredBy" runat="server" Text='<%# Eval("FK_ADM_ServiceSheetDetails_HRM_Employees1.DisplayField") %>'></asp:Label>
								</td>
							</tr>
							<tr>
								<td><b>On:&nbsp;</b>
								</td>
								<td><asp:Label ID="LabelMonitoredOn" runat="server" Text='<%# Bind("MonitoredOn") %>'></asp:Label>
								</td>
							</tr>
							<tr>
								<td><b>Rem:&nbsp;</b>
								</td>
								<td><asp:Label ID="LabelMonitorRemarks" runat="server" Text='<%# Bind("MonitorRemarks") %>'></asp:Label>
								</td>
							</tr>
						 </table>
          </ItemTemplate>
          <HeaderStyle Width="150px" />
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
      DataObjectTypeName = "SIS.ADM.admPendingProblems"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admPendingProblems"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ServiceID" PropertyName="SelectedValue" Name="ServiceID" Type="String" Size="10" />
        <asp:ControlParameter ControlID="F_CheckPointID" PropertyName="SelectedValue" Name="CheckPointID" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ServiceID" />
    <asp:AsyncPostBackTrigger ControlID="F_CheckPointID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
