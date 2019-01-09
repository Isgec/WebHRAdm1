<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admCheckPointMeasures.aspx.vb" Inherits="AF_admCheckPointMeasures" title="Add: Check Point Measures" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CheckPointID,MeasureID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admCheckPointMeasures"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmCheckPointMeasures" runat="server" Text="Add Check Point Measures" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CheckPointID" ForeColor="#CC6633" runat="server" Text="Check Point :" /></b>
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
						ValidationGroup = "admCheckPointMeasures"
            RequiredFieldErrorMessage = "Check Point is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MeasureID" ForeColor="#CC6633" runat="server" Text="Measure :" /></b>
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
						ValidationGroup = "admCheckPointMeasures"
            RequiredFieldErrorMessage = "Measure is required."
            Runat="Server" />
          </td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admCheckPointMeasures"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admCheckPointMeasures"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
