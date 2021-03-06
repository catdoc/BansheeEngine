﻿//********************************** Banshee Engine (www.banshee3d.com) **************************************************//
//**************** Copyright (c) 2016 Marko Pintera (marko.pintera@gmail.com). All rights reserved. **********************//
using bs;

namespace bs.Editor
{
    /** @addtogroup Inspector
     *  @{
     */

    /// <summary>
    /// Displays GUI for a serializable property containing a 2D vector.
    /// </summary>
    public class InspectableVector2 : InspectableField
    {
        private GUIVector2Field guiField;
        private InspectableState state;

        /// <summary>
        /// Creates a new inspectable 2D vector GUI for the specified property.
        /// </summary>
        /// <param name="context">Context shared by all inspectable fields created by the same parent.</param>
        /// <param name="title">Name of the property, or some other value to set as the title.</param>
        /// <param name="path">Full path to this property (includes name of this property and all parent properties).</param>
        /// <param name="depth">Determines how deep within the inspector nesting hierarchy is this field. Some fields may
        ///                     contain other fields, in which case you should increase this value by one.</param>
        /// <param name="layout">Parent layout that all the field elements will be added to.</param>
        /// <param name="property">Serializable property referencing the field whose contents to display.</param>
        public InspectableVector2(InspectableContext context, string title, string path, int depth, InspectableFieldLayout layout, 
            SerializableProperty property)
            : base(context, title, path, SerializableProperty.FieldType.Vector2, depth, layout, property)
        {

        }

        /// <inheritoc/>
        protected internal override void Initialize(int layoutIndex)
        {
            if (property.Type == SerializableProperty.FieldType.Vector2)
            {
                guiField = new GUIVector2Field(new GUIContent(title));
                guiField.OnValueChanged += OnFieldValueChanged;
                guiField.OnConfirm += x => OnFieldValueConfirm();
                guiField.OnFocusLost += OnFieldValueConfirm;
                guiField.OnFocusGained += RecordStateForUndoRequested;

                layout.AddElement(layoutIndex, guiField);
            }
        }

        /// <inheritdoc/>
        public override InspectableState Refresh(int layoutIndex)
        {
            if (guiField != null && !guiField.HasInputFocus)
                guiField.Value = property.GetValue<Vector2>();

            InspectableState oldState = state;
            if (state.HasFlag(InspectableState.Modified))
                state = InspectableState.NotModified;

            return oldState;
        }

        /// <inheritdoc />
        public override void SetHasFocus(string subFieldName = null)
        {
            guiField.Focus = true;
        }

        /// <summary>
        /// Triggered when the user changes the field value.
        /// </summary>
        /// <param name="newValue">New value of the 2D vector field.</param>
        private void OnFieldValueChanged(Vector2 newValue)
        {
            RecordStateForUndoIfNeeded();

            property.SetValue(newValue);
            state |= InspectableState.ModifyInProgress;
        }

        /// <summary>
        /// Triggered when the user confirms input in the 2D vector field.
        /// </summary>
        private void OnFieldValueConfirm()
        {
            if (state.HasFlag(InspectableState.ModifyInProgress))
                state |= InspectableState.Modified;
        }
    }

    /** @} */
}
