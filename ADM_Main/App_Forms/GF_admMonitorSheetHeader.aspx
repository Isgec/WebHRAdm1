<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admMonitorSheetHeader.aspx.vb" Inherits="GF_admMonitorSheetHeader" title="Maintain List: Sheet By Monitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMGrid"
      EnableAdd = "False"
      ValidationGroup = "admMonitorSheetHeader"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmMonitorSheetHeader" runat="server" Text="List Sheet By Monitor" CssClass="sis_formheading"></asp:Label>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <hr />
		<script type="text/javascript">
			var cnt = 0;
			function print_Report(o) {
				cnt = cnt + 1;
				var nam = 'wReport' + cnt;
				var url = self.location.href.replace('aspx', 'rptx');
				url = url + '?reportname=monitorsheet';
				url = url + '&sheetid=' + o.id;
				window.open(url, nam, 'left=20,top=20,width=750,height=700,toolbar=1,resizable=1,scrollbars=1');
				return false;
			}
		</script>
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
					<b><asp:Label ID="L_ScheduleID" runat="server" Text="Schedule :" /></b>
				</td>
        <td>
          <LGM:LC_admSchedules
            ID="F_ScheduleID"
            SelectedValue='<%# Bind("ScheduleID") %>'
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="ScheduleID"
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
    <asp:GridView ID="GridView1" width="100%" SkinID="gridviewSkin" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="SheetID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <table>
							<tr>
								<td style="width: 30px">
									<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("SheetID")%>' />
								</td>
								<td  style="width: 30px">
								  <input type="image" id='<%# EVal("SheetID") %>' onclick="return print_Report(this);" alt="Print" title="Click to print." src="../../App_Themes/Default/Images/print0.png" />
								</td>
							</tr>
            </table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sheet" SortExpression="SheetID">
          <ItemTemplate>
            <asp:Label ID="LabelSheetID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SheetID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sheet Date" SortExpression="SheetDate">
          <ItemTemplate>
            <asp:Label ID="LabelSheetDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SheetDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Service" SortExpression="ADM_Services2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ServiceID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("FK_ADM_ServiceSheetHeader_ADM_Services.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Schedule" SortExpression="ADM_Schedules1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ScheduleID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("FK_ADM_ServiceSheetHeader_ADM_Schedules.DisplayField") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ObjectDataSource1"
      runat = "server"
      DataObjectTypeName = "SIS.ADM.admMonitorSheetHeader"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "SelectList"
      TypeName = "SIS.ADM.admMonitorSheetHeader"
      SelectCountMethod = "SelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ServiceID" PropertyName="SelectedValue" Name="ServiceID" Type="String" Size="10" />
        <asp:ControlParameter ControlID="F_ScheduleID" PropertyName="SelectedValue" Name="ScheduleID" Type="String" Size="20" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ServiceID" />
    <asp:AsyncPostBackTrigger ControlID="F_ScheduleID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
