<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_admITCallSubTypes.aspx.vb" Inherits="GF_admITCallSubTypes" title="Maintain List: Sub Call Types" %>
<asp:Content ID="CPHadmITCallSubTypes" ContentPlaceHolderID=cph1 Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;List: Sub Call Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLadmITCallSubTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLadmITCallSubTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/ADM_Main/App_Edit/EF_admITCallSubTypes.aspx"
      AddUrl = "~/ADM_Main/App_Create/AF_admITCallSubTypes.aspx"
      ValidationGroup = "admITCallSubTypes"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSadmITCallSubTypes" runat="server" AssociatedUpdatePanelID="UPNLadmITCallSubTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
		<asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
			<div style="padding: 5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left;">Filter Records </div>
				<div style="float: left; margin-left: 20px;">
					<asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
				</div>
				<div style="float: right; vertical-align: middle;">
					<asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
				</div>
			</div>
		</asp:Panel>
		<asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CallTypeID" runat="server" Text="Call Type :" /></b>
				</td>
        <td>
          <LGM:LC_admITCallTypes
            ID="F_CallTypeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CallTypeID"
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
		</asp:Panel>
		<AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVadmITCallSubTypes" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSadmITCallSubTypes" DataKeyNames="CallTypeID,CallSubTypeID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Call Type" SortExpression="ADM_ITCallTypes1_Description">
          <ItemTemplate>
             <asp:Label ID="L_CallTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CallTypeID") %>' Text='<%# Eval("ADM_ITCallTypes1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Call Sub Type" SortExpression="CallSubTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelCallSubTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CallSubTypeID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
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
      ID = "ODSadmITCallSubTypes"
      runat = "server"
      DataObjectTypeName = "SIS.ADM.admITCallSubTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "admITCallSubTypesSelectList"
      TypeName = "SIS.ADM.admITCallSubTypes"
      SelectCountMethod = "admITCallSubTypesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CallTypeID" PropertyName="SelectedValue" Name="CallTypeID" Type="String" Size="20" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVadmITCallSubTypes" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CallTypeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
