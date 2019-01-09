<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admCheckPointMeasures.aspx.vb" Inherits="EF_admCheckPointMeasures" title="Edit: Check Point Measures" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CheckPointID,MeasureID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMEdit"
      ValidationGroup = "admCheckPointMeasures"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmCheckPointMeasures" runat="server" Text="Edit Check Point Measures" CssClass="sis_formheading"></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" runat="server" ForeColor="#CC6633" Text="Check Point :" /></b>
				</td>
        <td>
          <LGM:LC_admCheckPoints
            ID="F_CheckPointID"
            SelectedValue='<%# Bind("CheckPointID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="500px"
            CssClass="myddl"
            Enabled = "False"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MeasureID" runat="server" ForeColor="#CC6633" Text="Measure :" /></b>
				</td>
        <td>
          <LGM:LC_admMeasures
            ID="F_MeasureID"
            SelectedValue='<%# Bind("MeasureID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="500px"
            CssClass="myddl"
            Enabled = "False"
            Runat="Server" />
          </td>
			</tr>
		</table>
	</EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admCheckPointMeasures"
  SelectMethod = "GetByID"
  UpdateMethod="Update"
  DeleteMethod="Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admCheckPointMeasures"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CheckPointID" Name="CheckPointID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MeasureID" Name="MeasureID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
