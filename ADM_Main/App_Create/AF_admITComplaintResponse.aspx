<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admITComplaintResponse.aspx.vb" Inherits="AF_admITComplaintResponse" title="Add: Complaint Response" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabeltaBDDriver" runat="server" Text="&nbsp;Add: Complaint Response"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLtaBDDriver" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLadmITComplaintResponse"
            ToolType="lgNMAdd"
            ValidationGroup="admITComplaintResponse"
            InsertAndStay="false"
            runat="server" />
          <asp:FormView ID="FVadmITComplaintResponse"
            runat="server"
            DataKeyNames="CallID,SerialNo"
            DataSourceID="ObjectDataSource1"
            DefaultMode="Insert" 
            CssClass="sis_formview">
            <InsertItemTemplate>
              <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
              <table>
                <tr>
                  <td class="alignright">
                    <b>
                      <asp:Label ID="L_CallID" ForeColor="#CC6633" runat="server" Text="CallID :" /></b>
                  </td>
                  <td>
                    <asp:TextBox
                      ID="F_CallID"
                      CssClass="mypktxt"
                      Width="70px"
                      ValidationGroup="admITComplaintResponse"
                      Enabled="false"
                      runat="Server" />
                  </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b>
                      <asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="SerialNo :" /></b>
                  </td>
                  <td>
                    <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="70px" runat="server" Text="0" />
                  </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b>
                      <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
                  </td>
                  <td>
                    <asp:TextBox ID="F_Remarks"
                      Text='<%# Bind("Remarks") %>'
                      CssClass="mytxt"
                      onfocus="return this.select();"
                      ValidationGroup="admITComplaintResponse"
                      onblur="this.value=this.value.replace(/\'/g,'');"
                      ToolTip="Enter value for Remarks."
                      MaxLength="250"
                      Width="350px" Height="40px" TextMode="MultiLine"
                      runat="server" />
                    <asp:RequiredFieldValidator
                      ID="RFVRemarks"
                      runat="server"
                      ControlToValidate="F_Remarks"
                      Text="Remarks is required."
                      ErrorMessage="[Required!]"
                      Display="Dynamic"
                      EnableClientScript="true"
                      ValidationGroup="admITComplaintResponse"
                      SetFocusOnError="true" />
                  </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b>
                      <asp:Label ID="L_SendMail" runat="server" Text="Call Forwarded/Escalated:" /></b>
                  </td>
                  <td>
                    <asp:CheckBox ID="F_SendMail"
                      Checked='<%# Bind("F_SendMail") %>'
                      runat="server" />
                  </td>
                </tr>
                <tr>
                  <td class="alignright">
                    <b>
                      <asp:Label ID="L_AssignedTo" runat="server" Text="Escalated/Forwarded To :" /></b>
                  </td>
                  <td>
                    <asp:TextBox
                      ID="F_AssignedTo"
                      CssClass="myfktxt"
                      Width="56px"
                      Text='<%# Bind("F_AssignedTo") %>'
                      AutoCompleteType="None"
                      onfocus="return this.select();"
                      ToolTip="Enter value for Assigned To."
                      ValidationGroup="admITRegisterComplaint"
                      onblur="validate_AssignedTo(this);"
                      runat="Server" />
                    <asp:Label
                      ID="F_AssignedTo_Display"
                      Text=""
                      runat="Server" />
                    <asp:RequiredFieldValidator
                      ID="RFVAssignedTo"
                      runat="server"
                      ControlToValidate="F_AssignedTo"
                      Text="Assigned To is required."
                      ErrorMessage="[Required!]"
                      Display="Dynamic"
                      EnableClientScript="true"
                      ValidationGroup="admITRegisterComplaint"
                      SetFocusOnError="true" />
                    <AJX:AutoCompleteExtender
                      ID="ACEAssignedTo"
                      BehaviorID="B_ACEAssignedTo"
                      ContextKey=""
                      UseContextKey="true"
                      ServiceMethod="AssignedToCompletionList"
                      TargetControlID="F_AssignedTo"
                      EnableCaching="false"
                      CompletionInterval="100"
                      FirstRowSelected="true"
                      MinimumPrefixLength="1"
                      OnClientItemSelected="ACEAssignedTo_Selected"
                      OnClientPopulating="ACEAssignedTo_Populating"
                      OnClientPopulated="ACEAssignedTo_Populated"
                      CompletionSetCount="10"
                      CompletionListCssClass="autocomplete_completionListElement"
                      CompletionListItemCssClass="autocomplete_listItem"
                      CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                      runat="Server" />
                  </td>
                </tr>

              </table>
            </InsertItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ObjectDataSource1"
        DataObjectTypeName="SIS.ADM.admITComplaintResponse"
        InsertMethod="UZ_Insert"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.ADM.admITComplaintResponse"
        SelectMethod="GetNewRecord"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter QueryStringField="CallID" Name="CallID" Type="Int32" Size="10" DefaultValue="-1" />
        </SelectParameters>
        <InsertParameters>
          <asp:Parameter Name="SerialNo" Type="Int32" Direction="Output" />
        </InsertParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
