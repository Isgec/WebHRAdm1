<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admServices.aspx.vb" Inherits="EF_admServices" title="Edit: Administrative Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ServiceID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admServices"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmServices" runat="server" Text="Edit Administrative Services" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ServiceID" runat="server" ForeColor="#CC6633" Text="Service :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ServiceID"
						Text='<%# Bind("ServiceID") %>'
            Width="70px"
						CssClass = "mypktxt"
            Enabled = "False"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admServices"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
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
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admServices"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admServices"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ServiceID" Name="ServiceID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
