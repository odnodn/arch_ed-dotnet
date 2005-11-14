'
'
'	component:   "openEHR Archetype Project"
'	description: "$DESCRIPTION"
'	keywords:    "Archetype, Clinical, Editor"
'	author:      "Sam Heard"
'	support:     "Ocean Informatics <support@OceanInformatics.biz>"
'	copyright:   "Copyright (c) 2004 Ocean Informatics Pty Ltd"
'	license:     "See notice at bottom of class"
'
'	file:        "$Source$"
'	revision:    "$Revision$"
'	last_change: "$Date$"
'
'

Public Class InputForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents lblInput As System.Windows.Forms.Label
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents txtInput2 As System.Windows.Forms.TextBox
    Friend WithEvents LblInput2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InputForm))
        Me.txtInput = New System.Windows.Forms.TextBox
        Me.lblInput = New System.Windows.Forms.Label
        Me.butOK = New System.Windows.Forms.Button
        Me.butCancel = New System.Windows.Forms.Button
        Me.txtInput2 = New System.Windows.Forms.TextBox
        Me.LblInput2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(16, 64)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(320, 20)
        Me.txtInput.TabIndex = 0
        Me.txtInput.Text = ""
        '
        'lblInput
        '
        Me.lblInput.Location = New System.Drawing.Point(16, 8)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(256, 48)
        Me.lblInput.TabIndex = 1
        Me.lblInput.Text = "Enter:"
        Me.lblInput.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(288, 6)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(56, 24)
        Me.butOK.TabIndex = 2
        Me.butOK.Text = "OK"
        '
        'butCancel
        '
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(288, 37)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(56, 24)
        Me.butCancel.TabIndex = 3
        Me.butCancel.Text = "Cancel"
        '
        'txtInput2
        '
        Me.txtInput2.Location = New System.Drawing.Point(16, 111)
        Me.txtInput2.Name = "txtInput2"
        Me.txtInput2.Size = New System.Drawing.Size(320, 20)
        Me.txtInput2.TabIndex = 4
        Me.txtInput2.Text = ""
        Me.txtInput2.Visible = False
        '
        'LblInput2
        '
        Me.LblInput2.Location = New System.Drawing.Point(17, 92)
        Me.LblInput2.Name = "LblInput2"
        Me.LblInput2.Size = New System.Drawing.Size(271, 16)
        Me.LblInput2.TabIndex = 5
        Me.LblInput2.Text = "Label2"
        Me.LblInput2.Visible = False
        '
        'InputForm
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(350, 92)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblInput2)
        Me.Controls.Add(Me.txtInput2)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.txtInput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InputForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.txtInput.Text = ""
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub LblInput2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblInput2.TextChanged
        If LblInput2.Text <> "" Then
            Me.Size = New System.Drawing.Size(Me.Size.Width, 176)
        End If
        Me.LblInput2.Visible = True
        Me.txtInput2.Visible = True
    End Sub
End Class

'
'***** BEGIN LICENSE BLOCK *****
'Version: MPL 1.1/GPL 2.0/LGPL 2.1
'
'The contents of this file are subject to the Mozilla Public License Version 
'1.1 (the "License"); you may not use this file except in compliance with 
'the License. You may obtain a copy of the License at 
'http://www.mozilla.org/MPL/
'
'Software distributed under the License is distributed on an "AS IS" basis,
'WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
'for the specific language governing rights and limitations under the
'License.
'
'The Original Code is InputForm.vb.
'
'The Initial Developer of the Original Code is
'Sam Heard, Ocean Informatics (www.oceaninformatics.biz).
'Portions created by the Initial Developer are Copyright (C) 2004
'the Initial Developer. All Rights Reserved.
'
'Contributor(s):
'	Heath Frankel
'
'Alternatively, the contents of this file may be used under the terms of
'either the GNU General Public License Version 2 or later (the "GPL"), or
'the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
'in which case the provisions of the GPL or the LGPL are applicable instead
'of those above. If you wish to allow use of your version of this file only
'under the terms of either the GPL or the LGPL, and not to allow others to
'use your version of this file under the terms of the MPL, indicate your
'decision by deleting the provisions above and replace them with the notice
'and other provisions required by the GPL or the LGPL. If you do not delete
'the provisions above, a recipient may use your version of this file under
'the terms of any one of the MPL, the GPL or the LGPL.
'
'***** END LICENSE BLOCK *****
'