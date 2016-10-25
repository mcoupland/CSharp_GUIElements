Another attempt at my "Swiss Army Button"

Opacity, flexibility, docking, borders, events, etc. I want this to do it all.
It doesn't.  :)  But, it's getting there and it was fun to write and a good excercise to keep me fresh on delegates and WPF-ish things.

GUIESamples: Form to test button flexibility and functionality (TestGUITogglePanel is not yet implemented, ie. it does nothing)

GUIElements: Code for the buttons.  
GUIButtonStateInfo: this is sad and I am not proud of it, but I was trying to simplify setting button states for the end user.
	
Highlights: Opacity of frame and other visuals, Borders, toggle, events, docking (middle not there yet), text length handling options.

1. Reasons
  1. A standard WPF UIElement inherits its opacity from its parent.

GUIButton Elements

1. Button
  1. Picture
  2. Caption
  3. Border
2. Frame (Virtual parent of the Button, configuration independent of Button)
  1. Optional
  2. Size
  3. Color
  4. Opacity
  5. Border

GUIButton Requirements

1. Control types
  1. Momentary
  2. Toggle
2. Constructors
  1. Enough to be usable w/o being unmanageable & confusing
  2. Overload & implement optional arguments where appropriate
3. Public Members
  1. Set values inaccessible via constructors
  2. Update Button values
  3. Update Frame values
    1. Struct to update Frame in order to reduce complexity
4. Button
  1. Element opacity unaffected by parent container
  2. Display Caption & Picture, Caption only, or Picture only
  3. Dock image relative to text
    1. Top, Bottom, Left, Right, Middle
    2. Still need to implement "middle" docking
  4. Configurable border
5. Frame
  1. Configuration independent of the Button
  2. Visual properties
    1. Size
    2. Color
    3. Opacity
    4. Border
6. Events
  1. LeftClick
  2. RightClick
  3. DoubleLeftClick
  4. DoubleRightClick
  5. MouseEnter
  6. MouseLeave
  7. ButtonStateChanged

Issues

1. Caption is longer than Picture in Portrait mode
  1. Creates visually unappealing whitespace
    1. Vertical whitespace doesn&#39;t match horizontal
2. Toggle vs. Momentary Visual
  1. Click events
  2. Mouse events
