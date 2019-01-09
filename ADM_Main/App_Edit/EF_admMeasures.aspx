<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admMeasures.aspx.vb" Inherits="EF_admMeasures" title="Edit: Measures and Monitoring Mechanism" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "MeasureID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admMeasures"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmMeasures" runat="server" Text="Edit Measures and Monitoring Mechanism" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MeasureID" runat="server" ForeColor="#CC6633" Text="Measure :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MeasureID"
						Text='<%# Bind("MeasureID") %>'
						style="text-align: right"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admMeasures"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admMeasures"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MonitoringMechanism" runat="server" Text="Monitoring Mechanism :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MonitoringMechanism"
						Text='<%# Bind("MonitoringMechanism") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admMeasures"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Monitoring Mechanism."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVMonitoringMechanism"
						runat = "server"
						ControlToValidate = "F_MonitoringMechanism"
						Text = "Monitoring Mechanism is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admMeasures"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admMeasures"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admMeasures"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MeasureID" Name="MeasureID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
