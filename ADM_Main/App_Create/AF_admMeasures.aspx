<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admMeasures.aspx.vb" Inherits="AF_admMeasures" title="Add: Measures and Monitoring Mechanism" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "MeasureID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admMeasures"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmMeasures" runat="server" Text="Add Measures and Monitoring Mechanism" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MeasureID" ForeColor="#CC6633" runat="server" Text="Measure :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MeasureID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="admMeasures"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="admMeasures"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Monitoring Mechanism."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admMeasures"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admMeasures"
  SelectMethod = "GetNewRecord"
  runat = "server" >
<InsertParameters>
  <asp:Parameter Name="MeasureID" Type="Int32" Direction="Output" />
</InsertParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
