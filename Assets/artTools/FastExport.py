import bpy
import os
import webbrowser

fold_dst = ""

#http://www.blender.org/documentation/blender_python_api_2_59_0/bpy.path.html
  
from bpy.props import (StringProperty,
                       BoolProperty,
                       IntProperty,
                       FloatProperty,
                       FloatVectorProperty,
                       EnumProperty,
                       PointerProperty,
                       )

from bpy.types import (Panel,
                       Operator,
                       AddonPreferences,
                       PropertyGroup,
                       )


def getFbxExportParams():
    return {
        'check_existing': True,
        'axis_forward': '-Z', 'axis_up': 'Y',
        'filter_glob': "*.fbx",
        #'version':'BIN7400',
        'use_selection': True,
        'global_scale': 1,
        'apply_unit_scale': False,
        'apply_scale_options': 'FBX_SCALE_ALL',
        'bake_space_transform': True,
        'object_types': {'EMPTY', 'ARMATURE', 'MESH', 'OTHER'},
        'use_mesh_modifiers': True, 'use_mesh_modifiers_render': True,
        'mesh_smooth_type': 'OFF', 'use_mesh_edges': False, 'use_tspace': False,
        'use_custom_props': False,
        'add_leaf_bones': False,
        'primary_bone_axis': 'Y', 'secondary_bone_axis': 'X',
        'use_armature_deform_only': True,
        'armature_nodetype': 'NULL',
        'bake_anim': True,
        'bake_anim_use_all_bones': True,
        'bake_anim_use_nla_strips': True,
        'bake_anim_use_all_actions': True,
        'bake_anim_force_startend_keying': True,
        'bake_anim_step': 1,
        'bake_anim_simplify_factor': 1,
        #'use_anim': True,
        #'use_anim_action_all': True,
        #'use_default_take': True,
        #'use_anim_optimize': True,
        #'anim_optimize_precision': 6,
        'path_mode': 'AUTO',
        'embed_textures': False,
        'batch_mode': 'OFF',
        'use_batch_own_dir': True,
        'use_metadata': True
    }

##################
## Rotation Fix ##
##################
def FixRotate(obj):
    # Rotating mesh if needed
    if obj.rotation_euler.x == 0.0:
        obj.rotation_euler.x = 1.5707964897155762
        if obj.type != 'EMPTY':
            bpy.ops.object.mode_set(mode='EDIT')
            bpy.ops.mesh.select_all(action='SELECT')
        else:
            for child in obj.children:
                child.select = True
            bpy.ops.object.transform_apply(location=False, rotation=True, scale=False)
        bpy.context.scene.cursor_location = (0.0, 0.0, 0.0)
        bpy.context.space_data.pivot_point = 'CURSOR'
        bpy.ops.transform.rotate(value = 1.5707964897155762, axis=(-1, 0, 0), constraint_orientation='GLOBAL')
        bpy.ops.object.mode_set(mode='OBJECT')
        if obj.type == 'EMPTY':
            bpy.ops.object.transform_apply(location=False, rotation=True, scale=False)


###################
##  Open Manual  ##
###################
def openManual():
    webbrowser.open('')

########################
# Single Export Rigged #
########################
# Save a single object to fold_dst.
def singleExport(obj):
    bpy.ops.object.select_all(action='DESELECT')
    obj.select_set(True)
    SelectAllChildren(obj)

    export_params = getFbxExportParams()
    export_params['filepath'] = fold_dst + obj.name + ".fbx"
    bpy.ops.export_scene.fbx(**export_params)

    print(export_params['filepath'])

#######################
# Select All Children #
#######################   
def SelectAllChildren(obj):
    for N in obj.children:
        if len(N.children) > 0:
            #print(str(N)+" I have Child")
            bpy.data.objects[N.name].select_set(True)
            SelectAllChildren(N)
        else:
            # Do something
            bpy.data.objects[N.name].select_set(True)
            print(N)

#######################
# Multi Export Rigged #
#######################
# Save all selected objects to fold_dst.
def exportAllSelected():
    all_selected = bpy.context.selected_objects

    for obj in all_selected:
        singleExport(obj)

#
#    Menu in UI region
#

class View3DPanel:
    bl_space_type = 'VIEW_3D'
    bl_region_type = 'UI'
    bl_category = "FastExpot"
    bl_context = "objectmode"

    @classmethod
    def poll(cls, context):
        return (context.object is not None)

class FastExpotPanel(View3DPanel, bpy.types.Panel):
    #"""A FastExpot Panel in the Viewport Toolbar"""
    bl_idname = "VIEW3D_PT_FastExpot_Exporter"
    bl_label = "FastExpot Panel"

    def draw(self, context):
        layout = self.layout

        obj = context.object
        global fold_dst
        fold_dst = context.scene.destination

        row = layout.row(align=False)
        row.label(text="Export to Unity:")
        row.alignment = 'RIGHT'
        #row.operator("open.manual", text="",icon='QUESTION')
        row = layout.row()
        row.prop(bpy.context.scene,"destination")

        fold_dst = context.scene.destination
        fold_dst = bpy.path.abspath(fold_dst)
        fold_dst = fold_dst.replace("\\","/")

        split = layout.split(align=True)
        col = split.column(align=True)
        scene = context.scene

        col.operator("export.smartmulti", text="Export", icon='MESH_ICOSPHERE')

        split = layout.split(align=True)
        col = split.column(align=True)

class SmartMultiExport(bpy.types.Operator):
    "Export multiple meshes to the selected folder"
    bl_idname = "export.smartmulti"
    bl_label = "Smart Multi Export"
 
    def execute(self, context):
        exportAllSelected()
        return{'FINISHED'}  

class OpenManual(bpy.types.Operator):
    bl_idname = "open.manual"
    bl_label = "Open Manual"
 
    def execute(self, context):
        openManual()
        return{'FINISHED'}   

bpy.types.Scene.destination = bpy.props.StringProperty(  name="Destination", description = "Directory file to go", subtype='DIR_PATH' )
bpy.types.Scene.fbxFile = bpy.props.StringProperty(  name="FBX File", description = "File You want to Fix", subtype='FILE_PATH' )

bpy.utils.register_class(SmartMultiExport)
bpy.utils.register_class(OpenManual)
bpy.utils.register_class(FastExpotPanel)