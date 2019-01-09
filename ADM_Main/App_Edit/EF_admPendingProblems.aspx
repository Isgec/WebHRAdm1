<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admPendingProblems.aspx.vb" Inherits="EF_admPendingProblems" title="Edit: Pending Problems" %>
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
      ValidationGroup = "admPendingProblems"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmPendingProblems" runat="server" Text="Edit Pending Problems" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SheetID" runat="server" ForeColor="#CC6633" Text="Sheet :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SheetID"
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
					<asp:TextBox ID="F_SerialNo"
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
<%--					<asp:TextBox
						ID = "F_ServiceID"
            Width="70px"
						Text='<%# Bind("ServiceID") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
--%>					<asp:Label
						ID = "F_ServiceID_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_Services.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ScheduleID" runat="server" Text="Schedule :" /></b>
				</td>
        <td>
<%--					<asp:TextBox
						ID = "F_ScheduleID"
            Width="140px"
						Text='<%# Bind("ScheduleID") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
--%>					<asp:Label
						ID = "F_ScheduleID_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_Schedules.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" runat="server" Text="Check Point :" /></b>
				</td>
        <td>
<%--					<asp:TextBox
						ID = "F_CheckPointID"
            Width="70px"
						Text='<%# Bind("CheckPointID") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
--%>					<asp:Label
						ID = "F_CheckPointID_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_CheckPoints.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MeasureID" runat="server" Text="Measure :" /></b>
				</td>
        <td>
<%--					<asp:TextBox
						ID = "F_MeasureID"
            Width="70px"
						Text='<%# Bind("MeasureID") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
--%>					<asp:Label
						ID = "F_MeasureID_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" runat="server" Text="Monitoring Mechanism :" /></b>
				</td>
        <td><asp:Label
						ID = "Label2"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.MonitoringMechanism") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_InitiatedBy" runat="server" Text="Initiated By :" /></b>
				</td>
        <td>
<%--					<asp:TextBox
						ID = "F_InitiatedBy"
            Width="56px"
						Text='<%# Bind("InitiatedBy") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
--%>					<asp:Label
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
					<b><asp:Label ID="L_MonitoredBy" runat="server" Text="Monitored By :" /></b>
				</td>
        <td>
<%--					<asp:TextBox
						ID = "F_MonitoredBy"
            Width="56px"
						Text='<%# Bind("MonitoredBy") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
--%>					<asp:Label
						ID = "F_MonitoredBy_Display"
						Text='<%# Eval("FK_ADM_ServiceSheetDetails_HRM_Employees1.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MonitoredOn" runat="server" Text="Monitored On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_MonitoredOn"
						Text='<%# Bind("MonitoredOn") %>'
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MonitorRemarks" runat="server" Text="Monitor Remarks :" /></b>
				</td>
				<td>
					<asp:Label ID="F_MonitorRemarks"
						Text='<%# Bind("MonitorRemarks") %>'
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProblemClosed" runat="server" Text="Problem Closed :" /></b>
				</td>
				<td>
            <asp:CheckBox ID="F_ProblemClosed"
						  Checked='<%# Bind("ProblemClosed") %>'
              runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ClosingRemarks" runat="server" Text="Closing Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ClosingRemarks"
						Text='<%# Bind("ClosingRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admPendingProblems"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Closing Remarks."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVClosingRemarks"
						runat = "server"
						ControlToValidate = "F_ClosingRemarks"
						Text = "Closing Remarks is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admPendingProblems"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admPendingProblems"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admPendingProblems"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SheetID" Name="SheetID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
