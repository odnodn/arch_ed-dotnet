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

Option Explicit On 

Public Class TabPageComposition
    Inherits System.Windows.Forms.UserControl

    Private mIsloading As Boolean
    Private mSectionConstraint As TabPageSection
    Private mContextConstraint As TabPageStructure


#Region " Windows Form Designer generated code "

    Public Sub New() 'ByVal aEditor As Designer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        'Try
        InitializeComponent()
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents TabControlInstruction As Crownwood.Magic.Controls.TabControl
    Friend WithEvents PanelBaseTop As System.Windows.Forms.Panel
    Friend WithEvents HelpProviderInstruction As System.Windows.Forms.HelpProvider
    Friend WithEvents tpContext As Crownwood.Magic.Controls.TabPage
    Friend WithEvents tpSectionConstraint As Crownwood.Magic.Controls.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControlInstruction = New Crownwood.Magic.Controls.TabControl
        Me.tpContext = New Crownwood.Magic.Controls.TabPage
        Me.tpSectionConstraint = New Crownwood.Magic.Controls.TabPage
        Me.PanelBaseTop = New System.Windows.Forms.Panel
        Me.HelpProviderInstruction = New System.Windows.Forms.HelpProvider
        Me.SuspendLayout()
        '
        'TabControlInstruction
        '
        Me.TabControlInstruction.BackColor = System.Drawing.Color.CornflowerBlue
        Me.TabControlInstruction.BoldSelectedPage = True
        Me.TabControlInstruction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HelpProviderInstruction.SetHelpKeyword(Me.TabControlInstruction, "Screens/pathway_screen.html")
        Me.HelpProviderInstruction.SetHelpNavigator(Me.TabControlInstruction, System.Windows.Forms.HelpNavigator.Topic)
        Me.TabControlInstruction.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways
        Me.TabControlInstruction.Location = New System.Drawing.Point(0, 24)
        Me.TabControlInstruction.Name = "TabControlInstruction"
        Me.TabControlInstruction.PositionTop = True
        Me.TabControlInstruction.SelectedIndex = 1
        Me.TabControlInstruction.SelectedTab = Me.tpSectionConstraint
        Me.HelpProviderInstruction.SetShowHelp(Me.TabControlInstruction, True)
        Me.TabControlInstruction.Size = New System.Drawing.Size(848, 400)
        Me.TabControlInstruction.TabIndex = 0
        Me.TabControlInstruction.TabPages.AddRange(New Crownwood.Magic.Controls.TabPage() {Me.tpContext, Me.tpSectionConstraint})
        Me.TabControlInstruction.TextInactiveColor = System.Drawing.Color.Black
        '
        'tpContext
        '
        Me.HelpProviderInstruction.SetHelpKeyword(Me.tpContext, "Screens/action_screen.html")
        Me.HelpProviderInstruction.SetHelpNavigator(Me.tpContext, System.Windows.Forms.HelpNavigator.Topic)
        Me.tpContext.Location = New System.Drawing.Point(0, 0)
        Me.tpContext.Name = "tpContext"
        Me.tpContext.Selected = False
        Me.HelpProviderInstruction.SetShowHelp(Me.tpContext, True)
        Me.tpContext.Size = New System.Drawing.Size(848, 375)
        Me.tpContext.TabIndex = 2
        Me.tpContext.Title = "Context"
        '
        'tpSectionConstraint
        '
        Me.tpSectionConstraint.Location = New System.Drawing.Point(0, 0)
        Me.tpSectionConstraint.Name = "tpSectionConstraint"
        Me.tpSectionConstraint.Size = New System.Drawing.Size(848, 375)
        Me.tpSectionConstraint.TabIndex = 0
        Me.tpSectionConstraint.Title = "Sections"
        '
        'PanelBaseTop
        '
        Me.PanelBaseTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBaseTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelBaseTop.Name = "PanelBaseTop"
        Me.PanelBaseTop.Size = New System.Drawing.Size(848, 24)
        Me.PanelBaseTop.TabIndex = 1
        '
        'TabPageComposition
        '
        Me.BackColor = System.Drawing.Color.LemonChiffon
        Me.Controls.Add(Me.TabControlInstruction)
        Me.Controls.Add(Me.PanelBaseTop)
        Me.Name = "TabPageComposition"
        Me.Size = New System.Drawing.Size(848, 424)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TabPageComposition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mIsloading = True
        If Me.tpSectionConstraint.Controls.Count = 0 Then
            ' nothing loaded from archetype
            mSectionConstraint = New TabPageSection
            tpSectionConstraint.Controls.Add(mSectionConstraint)
            mSectionConstraint.Dock = DockStyle.Fill
        End If
        If Me.tpContext.Controls.Count = 0 Then
            ' nothing loaded from archetype
            mContextConstraint = New TabPageStructure
            tpContext.Controls.Add(mContextConstraint)
            mContextConstraint.Dock = DockStyle.Fill
        End If

        mSectionConstraint.IsRootOfComposition = True
        Me.HelpProviderInstruction.HelpNamespace = ArchetypeEditor.Instance.Options.HelpLocationPath

        mIsloading = False

    End Sub


    Public ReadOnly Property ComponentType() As StructureType
        Get
            Return StructureType.COMPOSITION
        End Get
    End Property

    Public Function toRichText(ByRef text As IO.StringWriter, ByVal level As Integer) As String

    End Function

    Public Sub Reset()
        Me.tpContext.Controls.Clear()
        mContextConstraint = New TabPageStructure
        tpContext.Controls.Add(mContextConstraint)
        mContextConstraint.Dock = DockStyle.Fill

        Me.tpSectionConstraint.Controls.Clear()
        mSectionConstraint = New TabPageSection
        mSectionConstraint.IsRootOfComposition = True
        tpSectionConstraint.Controls.Add(mSectionConstraint)
        mSectionConstraint.Dock = DockStyle.Fill
    End Sub

    Public Sub ProcessComposition(ByVal Struct As Children)

        Me.Reset()

        For Each rm As RmStructureCompound In Struct
            Select Case rm.Type
                Case StructureType.SECTION
                    mSectionConstraint.IsRootOfComposition = True
                    mSectionConstraint.ProcessSection(CType(rm, RmSection))
                Case StructureType.List, StructureType.Single, StructureType.Tree, StructureType.Table
                    mContextConstraint.ProcessStructure(CType(rm, RmStructureCompound))
                Case Else
                    Debug.Assert(False, "Not handled yet")
            End Select
        Next
    End Sub

    Public Sub BuildInterface(ByVal aContainer As Control, ByRef pos As Point)
        Dim spacer As Integer = 1

        'leftmargin = pos.X
        If aContainer.Name <> "tpInterface" Then
            aContainer.Size = New Size
        End If

        mContextConstraint.BuildInterface(aContainer, pos)

    End Sub

    Public Function SaveAsComposition() As RmComposition
        Dim rm As New RmComposition
        If Not mContextConstraint Is Nothing Then
            rm.Data.Add(mContextConstraint.SaveAsStructure)
        End If
        If Not mSectionConstraint Is Nothing Then
            rm.Data.Add(mSectionConstraint.SaveAsSection)
        End If
        Return rm
    End Function

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
'The Original Code is TabPageInstruction.vb.
'
'The Initial Developer of the Original Code is
'Sam Heard, Ocean Informatics (www.oceaninformatics.biz).
'Portions created by the Initial Developer are Copyright (C) 2004
'the Initial Developer. All Rights Reserved.
'
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
