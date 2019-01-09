<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_admInitiatorSheetHeader.aspx.vb" Inherits="EF_admInitiatorSheetHeader" title="Edit: Sheet By Initiator" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 runat="Server">
	<div id="div1" class="page">
		<asp:FormView ID="FormView1" runat="server" DataKeyNames="SheetID" DataSourceID="ObjectDataSource1" DefaultMode="Edit" CssClass="sis_formview">
			<EditItemTemplate>
				<LGM:ToolBar0 ID="ToolBar0_1" ToolType="lgNMEdit" EnableDelete="False" ValidationGroup="admInitiatorSheetHeader" runat="server" />
				<hr />
				<asp:Label ID="LabeladmInitiatorSheetHeader" runat="server" Text="Edit Sheet By Initiator" CssClass="sis_formheading"></asp:Label>
				<hr />
				<table width="100%">
					<tr>
						<td>
							<table width="100%">
								<tr>
									<td class="alignright">
										<b>
											<asp:Label ID="L_SheetID" runat="server" ForeColor="#CC6633" Text="Sheet ID :" /></b>
									</td>
									<td>
										<asp:Label ID="F_SheetID" Text='<%# Bind("SheetID") %>' Style="text-align: right" Width="70px" CssClass="mypktxt" Enabled="False" runat="server" />
									</td>
								</tr>
								<tr>
									<td class="alignright">
										<b>
											<asp:Label ID="L_SheetDate" runat="server" Text="Sheet Date :" /></b>
									</td>
									<td>
										<asp:Label ID="F_SheetDate" Text='<%# EVal("SheetDate") %>' runat="server" />
									</td>
								</tr>
								<tr>
									<td class="alignright">
										<b>
											<asp:Label ID="L_ServiceID" runat="server" Text="Service :" /></b>
									</td>
									<td>
										<asp:Label ID="F_ServiceID" Text='<%# EVal("FK_ADM_ServiceSheetHeader_ADM_Services.DisplayField") %>' runat="Server" />
									</td>
								</tr>
							</table>
						</td>
						<td style="vertical-align: bottom">
							<table>
								<tr>
									<td class="alignright">
										<b>
											<asp:Label ID="L_ScheduleID" runat="server" Text="Schedule :" /></b>
									</td>
									<td>
										<asp:Label ID="F_ScheduleID" Text='<%# Eval("FK_ADM_ServiceSheetHeader_ADM_Schedules.DisplayField") %>' runat="Server" />
									</td>
								</tr>
								<tr>
									<td class="alignright">
										<b>
											<asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
									</td>
									<td>
										<asp:Label ID="F_Description" Text='<%# Bind("Description") %>' Width="350px" runat="server" />
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				</br>
				<asp:UpdatePanel ID="UpdatePanel1" runat="server">
					<ContentTemplate>
						<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
							<ProgressTemplate>
								<span style="color: #ff0033">Loading...</span>
							</ProgressTemplate>
						</asp:UpdateProgress>
						<asp:Panel ID="pnlH" runat="server" CssClass="collapsePanelHeader" Height="30px">
							<div style="padding: 5px; cursor: pointer; vertical-align: middle;">
								<div style="float: left;">
									Checkpoint Measures</div>
								<div style="float: left; margin-left: 20px;">
									<asp:Label ID="lblH" runat="server">(Show Details...)</asp:Label>
								</div>
								<div style="float: right; vertical-align: middle;">
									<asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
								</div>
							</div>
						</asp:Panel>
						<asp:Panel ID="pnlD" runat="server" CssClass="collapsePanel" Height="0">
							<LGM:NavBar ID="NavBar1" runat="server" ValidationGroup="GridView1" />
							<asp:GridView ID="GridView1" Width="100%" SkinID="gridviewSkin" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" DataKeyNames="SheetID, SerialNo">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<asp:ImageButton ID="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" OnClick="Edit_Click" CommandArgument='<%#EVal("SheetID") & "," & EVal("SerialNo")%>' />
										</ItemTemplate>
										<HeaderStyle Width="30px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Sheet" SortExpression="SheetID">
										<ItemTemplate>
											<asp:Label ID="LabelSheetID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SheetID") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle CssClass="alignright" />
										<ItemStyle CssClass="alignright" />
										<HeaderStyle Width="40px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
										<ItemTemplate>
											<asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle CssClass="alignright" />
										<ItemStyle CssClass="alignright" />
										<HeaderStyle Width="40px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="CheckPoint" SortExpression="ADM_CheckPoints1_Descriptions">
										<ItemTemplate>
											<asp:Label ID="L_CheckPointID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_CheckPoints.DisplayField") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="100px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Responsibility" SortExpression="aspnet_users9_UserFullName">
										<ItemTemplate>
											<asp:Label ID="L_Responsibility" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("aspnet_users9_UserFullName") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="100px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Measure" SortExpression="ADM_Measures2_Description">
										<ItemTemplate>
											<asp:Label ID="L_MeasureID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.DisplayField") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="100px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Monitoring Mechanism" SortExpression="ADM_Measures2_MonitoringMechanism">
										<ItemTemplate>
											<asp:Label ID="L_MonitoringMechanism" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.MonitoringMechanism") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="100px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Initiator Remarks" SortExpression="InitiatorRemarks">
										<ItemTemplate>
											<asp:Label ID="L_Remarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("InitiatorRemarks") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="100px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Initiated By" SortExpression="HRM_Employees6_EmployeeName">
										<ItemTemplate>
											<asp:Label ID="L_InitiatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("FK_ADM_ServiceSheetDetails_HRM_Employees.DisplayField") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="100px" />
									</asp:TemplateField>
								</Columns>
								<EmptyDataTemplate>
									<asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
								</EmptyDataTemplate>
							</asp:GridView>
						</asp:Panel>
						<AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="False" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" SkinID="CollapsiblePanelDemo" />
						<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="SIS.ADM.admInitiatorSheetDetails" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectList" TypeName="SIS.ADM.admInitiatorSheetDetails" SelectCountMethod="SelectCount" SortParameterName="OrderBy" EnablePaging="True">
							<SelectParameters>
								<asp:QueryStringParameter DefaultValue="0" QueryStringField="SheetID" Name="SheetID" Type="Int32" />
								<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
								<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
							</SelectParameters>
						</asp:ObjectDataSource>
						</br>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
					</Triggers>
				</asp:UpdatePanel>
			</EditItemTemplate>
		</asp:FormView>
		<asp:ObjectDataSource ID="ObjectDataSource1" DataObjectTypeName="SIS.ADM.admInitiatorSheetHeader" SelectMethod="GetByID" UpdateMethod="Update" OldValuesParameterFormatString="original_{0}" TypeName="SIS.ADM.admInitiatorSheetHeader" runat="server">
			<SelectParameters>
				<asp:QueryStringParameter DefaultValue="0" QueryStringField="SheetID" Name="SheetID" Type="Int32" />
			</SelectParameters>
		</asp:ObjectDataSource>
	</div>
</asp:Content>
