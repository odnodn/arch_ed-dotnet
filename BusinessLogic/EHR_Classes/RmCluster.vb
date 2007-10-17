'
'
'	component:   "openEHR Archetype Project"
'	description: "$DESCRIPTION"
'	keywords:    "Archetype, Clinical, Editor"
'	author:      "Sam Heard"
'	support:     "Ocean Informatics <support@OceanInformatics.biz>"
'	copyright:   "Copyright (c) 2004,2005,2006 Ocean Informatics Pty Ltd"
'	license:     "See notice at bottom of class"
'
'	file:        "$URL$"
'	revision:    "$LastChangedRevision$"
'	last_change: "$LastChangedDate$"
'
'

Public Class RmCluster
    Inherits RmStructureCompound

    Public Overrides Function Copy() As RmStructure
        Dim ac As New RmCluster(Me.NodeId)
        ac.cOccurrences = Me.cOccurrences
        ac.mRunTimeConstraint = Me.mRunTimeConstraint
        Return ac
    End Function

    Sub New(ByVal archetype_node As ArchetypeComposite)
        MyBase.New(archetype_node)
    End Sub

    Sub New(ByVal rm As RmStructure)
        MyBase.New(rm)
    End Sub

    Sub New(ByVal NodeId As String)
        MyBase.New(NodeId, StructureType.Cluster)
    End Sub

#Region "ADL and XML Processing"

    Sub New(ByVal EIF_Cluster As openehr.openehr.am.archetype.constraint_model.C_COMPLEX_OBJECT, ByVal a_filemanager As FileManagerLocal)
        MyBase.New(EIF_Cluster, a_filemanager)
        ProcessTree(EIF_Cluster, a_filemanager)
        ArchetypeEditor.ADL_Classes.ADL_Tools.HighestLevelChildren = Me.Children
        ArchetypeEditor.ADL_Classes.ADL_Tools.PopulateReferences(Me)
    End Sub

    Sub New(ByVal XML_Cluster As XMLParser.C_COMPLEX_OBJECT, ByVal a_filemanager As FileManagerLocal)
        MyBase.New(XML_Cluster, a_filemanager)
        ProcessTree(XML_Cluster, a_filemanager)
        ArchetypeEditor.ADL_Classes.ADL_Tools.HighestLevelChildren = Me.Children
        ArchetypeEditor.ADL_Classes.ADL_Tools.PopulateReferences(Me)
    End Sub

#End Region
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
'The Original Code is RmCluster.vb.
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