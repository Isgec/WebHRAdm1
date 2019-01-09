<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admITAttendComplaint.aspx.vb" Inherits="EF_admITAttendComplaint" title="Edit: Attend Complaints" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CallID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      EnableDelete = "False"
      ValidationGroup = "admITAttendComplaint"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmITAttendComplaint" runat="server" Text="Edit Attend Complaints" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallID" runat="server" ForeColor="#CC6633" Text="Call ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CallID"
						Text='<%# Bind("CallID") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mypktxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EndUserID" runat="server" Text="End User :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_EndUserID"
            Width="56px"
						Text='<%# Bind("EndUserID") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_EndUserID_Display"
						Text='<%# Eval("FK_ADM_ITComplaints_HRM_Employees.DisplayField") %>'
						Runat="Server" />
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallTypeID" runat="server" Text="Call Type :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallTypes
            ID="F_CallTypeID"
            SelectedValue='<%# Bind("CallTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Enabled = "False"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallStatusID" runat="server" Text="Call Status :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallStatus
            ID="F_CallStatusID"
            SelectedValue='<%# Bind("CallStatusID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Enabled = "False"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LoggedOn" runat="server" Text="Logged On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LoggedOn"
						Text='<%# Bind("LoggedOn") %>'
            Width="70px"
						CssClass = "mytxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LoggedBy" runat="server" Text="Logged By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_LoggedBy"
            Width="56px"
						Text='<%# Bind("LoggedBy") %>'
						AutoCompleteType = "None"
						CssClass = "myfktxt"
						onfocus = "return this.select();"
            Enabled = "False"
						Runat="Server" />
					<asp:Label
						ID = "F_LoggedBy_Display"
						Text='<%# Eval("FK_ADM_ITComplaints_ADM_Users.DisplayField") %>'
						Runat="Server" />
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admITAttendComplaint"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admITAttendComplaint"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CallID" Name="CallID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
