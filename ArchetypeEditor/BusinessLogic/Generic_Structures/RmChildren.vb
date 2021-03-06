'
'
'	component:   "openEHR Archetype Project"
'	description: "$DESCRIPTION"
'	keywords:    "Archetype, Clinical, Editor"
'	author:      "Sam Heard"
'	support:     https://openehr.atlassian.net/browse/AEPR
'	copyright:   "Copyright (c) 2004,2005,2006 Ocean Informatics Pty Ltd"
'	license:     "See notice at bottom of class"
'
'

Option Strict On

Public MustInherit Class RmChildren
    Inherits CollectionBase

    Public ReadOnly Property Fixed() As Boolean
        Get
            Return Not mCardinality.IsUnbounded
        End Get
    End Property

    Protected mCardinality As New RmCardinality(0)
    Protected mExistence As New RmExistence

    Public Property Cardinality() As RmCardinality
        Get
            'SRH: 11 Jan 2009 - EDT-502 - added check for cardinality to be set to minimum
            Dim minCardinalityCount As Integer = 0

            For Each child As RmStructure In List
                If Not TypeOf child Is RmReference AndAlso child.Occurrences.MinCount > 0 Then
                    minCardinalityCount += child.Occurrences.MinCount
                End If
            Next

            If mCardinality.MinCount < minCardinalityCount Then
                mCardinality.MinCount = minCardinalityCount
            End If

            Return mCardinality
        End Get
        Set(ByVal Value As RmCardinality)
            mCardinality = Value
        End Set
    End Property

    Public Property Existence() As RmExistence
        Get
            ' HKF: Revert EDT-502 - allowing this to remain as 1..1 results in a null statement about existence in the ADL but results in incorrect XML, which must be ignored 
            'SRH: 11 Jan 2009 - EDT-502 - added check for existence to be mandatory if contains any mandatory children (only relevant for structures as protocol or state)
            'Try
            '    If mExistence.MinCount = 0 Then
            '        For Each child As RmStructure In List
            '            If TypeOf child Is RmStructureCompound Then
            '                If CType(child, RmStructureCompound).Children.Cardinality.MinCount > 0 Then
            '                    mExistence.MinCount = 1
            '                    Exit For
            '                End If
            '            Else ' a slot
            '                If child.Occurrences.MinCount > 0 Then
            '                    mExistence.MinCount = 1
            '                    Exit For
            '                End If
            '            End If

            '        Next
            '    End If
            'Catch
            '    Debug.Assert(False, "Error in setting existence")
            'End Try
            Return mExistence
        End Get
        Set(ByVal value As RmExistence)
            mExistence = value
        End Set
    End Property

    Public Sub Add(ByVal an_RM_Structure As RmStructure)
        List.Add(an_RM_Structure)
    End Sub

    Public Function GetChildByNodeId(ByVal aNodeId As String) As RmStructure
        For Each child As RmStructure In List
            If child.NodeId = aNodeId Then
                Return child
            End If

            If TypeOf child Is RmStructureCompound Then
                Dim compoundChild As RmStructureCompound = CType(child, RmStructureCompound)
                Dim deepChild As RmStructure = compoundChild.GetChildByNodeId(aNodeId)

                If Not deepChild Is Nothing Then
                    Return deepChild
                End If
            End If
        Next

        Return Nothing
    End Function

End Class

Public Class Children
    Inherits RmChildren

    Private boolOrdered As Boolean = True
    Private mParentStructureType As StructureType

    Public ReadOnly Property Items() As RmStructure()
        Get
            Dim result(List.Count - 1) As RmStructure
            Dim i As Integer

            For i = 0 To List.Count - 1
                result(i) = CType(List.Item(i), RmStructure)
            Next

            Return result
        End Get
    End Property

    ReadOnly Property FirstElementOrElementSlot() As RmStructure
        Get
            Dim result As RmStructure = Nothing
            Dim i As Integer = 0

            While i < Count And result Is Nothing
                Select Case Items(i).Type
                    Case StructureType.Element
                        result = CType(Items(i), RmElement)
                    Case StructureType.Cluster
                        result = CType(Items(i), RmCluster).Children.FirstElementOrElementSlot
                    Case StructureType.Slot
                        Dim slot As RmSlot = CType(Items(i), RmSlot)

                        If slot.SlotConstraint.RM_ClassType = StructureType.Element Then
                            result = slot
                        End If
                End Select

                i = i + 1
            End While

            Return result
        End Get
    End Property

    Public Function Copy() As Children
        Dim result As New Children(mParentStructureType)

        For Each rm As RmStructure In Items
            result.Add(rm.Copy)
        Next

        Return result
    End Function

    Public Shadows Sub Add(ByVal an_RM_Structure As RmStructure)
        If an_RM_Structure IsNot Nothing AndAlso ReferenceModel.IsValidChild(mParentStructureType, an_RM_Structure.Type) Then
            'Is valid child traps post condition of false as should not arise
            List.Add(an_RM_Structure)
        End If
    End Sub

    Sub New(ByVal parentStructureType As StructureType)
        mParentStructureType = parentStructureType

        ' HKF: Revert EDT-502 - allowing this to remain as 1..1 results in a null statement about existence in the ADL but results in incorrect XML, which must be ignored 
        ''SRH: 11 Jan 2009 - EDT-502 - added check for existence to be mandatory if contains any mandatory children (only relevant for structures as protocol or state)
        'If ParentStructureType = StructureType.Protocol Or ParentStructureType = StructureType.State Then
        '    Me.Existence.MinCount = 0
        'End If
        If parentStructureType = StructureType.Cluster Or parentStructureType = StructureType.SECTION Then
            'Default to 1..*
            If Cardinality.MinCount < 1 Then
                Cardinality.MinCount = 1
            End If
        End If
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
'The Original Code is RmChildren.vb.
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

