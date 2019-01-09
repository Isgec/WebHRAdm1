<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admMonitorSheetDetails.aspx.vb" Inherits="EF_admMonitorSheetDetails" title="Edit: Sheet Detail By Monitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "SheetID,SerialNo"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      EnableDelete = "False"
      ValidationGroup = "admMonitorSheetDetails"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmMonitorSheetDetails" runat="server" Text="Edit Sheet Detail By Monitor" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SheetID" runat="server" ForeColor="#CC6633" Text="Sheet :" /></b>
				</td>
				<td>
					<asp:Label ID="F_SheetID"
						Text='<%# Bind("SheetID") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mypktxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:Label ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mypktxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SheetDate" runat="server" Text="Sheet Date :" /></b>
				</td>
				<td>
					<asp:Label ID="F_SheetDate"
						Text='<%# Bind("SheetDate") %>'
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ServiceID" runat="server" Text="Service :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_ServiceID_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_Services.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ScheduleID" runat="server" Text="Schedule :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_ScheduleID_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_Schedules.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" runat="server" Text="Check Point :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_CheckPointID_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_CheckPoints.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MeasureID" runat="server" Text="Measure :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_MeasureID_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" runat="server" Text="Monitoring Mechanism :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "Label2"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.MonitoringMechanism") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_InitiatedBy" runat="server" Text="Initiated By :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_InitiatedBy"
						Text='<%# Bind("InitiatedBy") %>'
						Runat="Server" />
					<asp:Label
						ID = "F_InitiatedBy_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_HRM_Employees.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_InitiatedOn" runat="server" Text="Initiated On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_InitiatedOn"
						Text='<%# Bind("InitiatedOn") %>'
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_InitiatorRemarks" runat="server" Text="Initiator Remarks :" /></b>
				</td>
				<td>
					<asp:Label ID="F_InitiatorRemarks"
						Text='<%# Bind("InitiatorRemarks") %>'
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProblemIdentified" runat="server" Text="Problem Identified :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_ProblemIdentified"
						  Checked='<%# Bind("ProblemIdentified") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MonitorRemarks" runat="server" Text="Monitor Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MonitorRemarks"
						Text='<%# Bind("MonitorRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admMonitorSheetDetails"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Monitor Remarks."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVMonitorRemarks"
						runat = "server"
						ControlToValidate = "F_MonitorRemarks"
						Text = "Monitor Remarks is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admMonitorSheetDetails"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admMonitorSheetDetails"
  SelectMethod = "GetByID"
  UpdateMethod="UZ_Update"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admMonitorSheetDetails"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SheetID" Name="SheetID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
