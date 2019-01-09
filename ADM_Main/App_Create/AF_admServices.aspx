<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admServices.aspx.vb" Inherits="AF_admServices" title="Add: Administrative Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ServiceID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admServices"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmServices" runat="server" Text="Add Administrative Services" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ServiceID" ForeColor="#CC6633" runat="server" Text="Service :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ServiceID"
						Text='<%# Bind("ServiceID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="admServices"
            onblur= "validate_ServiceID(this);"
            ToolTip="Enter value for Service."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVServiceID"
						runat = "server"
						ControlToValidate = "F_ServiceID"
						Text = "Service is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admServices"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admServices"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admServices"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_OfficeID" runat="server" Text="Location :" /></b>
				</td>
        <td>
          <LGM:LC_admOffices
            ID="F_OfficeID"
            SelectedValue='<%# Bind("OfficeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "admServices"
            RequiredFieldErrorMessage = "Location is required."
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
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "admServices"
            RequiredFieldErrorMessage = "Schedule is required."
            Runat="Server" />
          </td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admServices"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admServices"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
